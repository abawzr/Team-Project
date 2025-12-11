using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    [SerializeField] private GameObject[] BodyPart;
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float CurrentHealth = 0f;
    [SerializeField] private float drainRate = 2f;
    [SerializeField] private Volume visionEffect;

    private MotionBlur _motionBlur;
    private DepthOfField _depthOfField;
    private bool _isSeeing;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _motionBlur = visionEffect.GetComponent<MotionBlur>();
        _depthOfField= visionEffect.GetComponent<DepthOfField>();
    }

    private void Start()
    {
        CurrentHealth = 0f;
        SetHallucinationActive(false);
    }

    private void Update()
    {
        if (CurrentHealth > 0f)
        {
            CurrentHealth -= drainRate * Time.deltaTime;

            if (CurrentHealth <= 0f)
            {
                CurrentHealth = 0f;
                SetHallucinationActive(false);
            }
        }
    }

    public void AddDrug(float amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0f, maxHealth);

        if (CurrentHealth > 0f && !_isSeeing)
        {   
            SetHallucinationActive(true);
        }
    }

    private void SetHallucinationActive(bool isActive)
    {
        _isSeeing = isActive;

        if (BodyPart != null)
        {
            foreach (var obj in BodyPart)
            {
                if (obj != null)
                    obj.SetActive(!isActive);
            }
        }

        //Reef
        _motionBlur.intensity.value = 0f;
    }
}
