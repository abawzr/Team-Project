using UMA;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


//searching for a butter name
public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    [SerializeField] private GameObject[] bodyParts;
    [SerializeField] private float maxHealth = 300f;
    
    private float CurrentHealth;
   // [SerializeField] private float drainRate = 0.33f;
   // [SerializeField] private float showItemsLastSeconds = 60f;

    [SerializeField] private Slider healthSlider;

    //[SerializeField] private Volume visionEffect;

    //private MotionBlur _motionBlur;
    //private DepthOfField _depthOfField;



    //start
    private void Awake()
    {
        Instance = this;

        //if (visionEffect != null && visionEffect.profile != null)
        //{
        //    visionEffect.profile.TryGet(out _motionBlur);
        //    visionEffect.profile.TryGet(out _depthOfField);
        //}

    }

    private void Start()
    {
        CurrentHealth = maxHealth;
        HideBodyParts(false);

        if (healthSlider != null)
        {
            healthSlider.minValue = 0f;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = CurrentHealth;
        }
    }

    private void Update()
    {

        if (CurrentHealth > 0f)
        {
            CurrentHealth -= Time.deltaTime;

            if (CurrentHealth < 0f)
                CurrentHealth = 0f;
        }

        if (healthSlider != null)
        {
            healthSlider.value = CurrentHealth;
        }

        //UpdateVisualEffects();
        float m = maxHealth / 2;
       
        if (CurrentHealth <= m && CurrentHealth > 0f)
        {
            HideBodyParts(true);
        }
        else
        {
            HideBodyParts(false);
        }
    }

    

    public void AddDrug(float amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0f, maxHealth);
    
        if (healthSlider != null)
            healthSlider.value = CurrentHealth;
    }

    private void HideBodyParts(bool Hide)
    {
        foreach (var part in bodyParts)
        {
            if (part != null)
                part.SetActive(Hide); 
        }
    }

    //private void UpdateVisualEffects()
    //{
    //    if (visionEffect == null) return;

        
    //    float t = 1f - (CurrentHealth / maxHealth);
    //    t = Mathf.Clamp01(t);

        
    //    if (_motionBlur != null)
    //    {
    //        _motionBlur.intensity.overrideState = true;
    //        _motionBlur.intensity.value = Mathf.Lerp(0f, 0.8f, t);
    //    }

        
    //    if (_depthOfField != null)
    //    {
    //        _depthOfField.gaussianStart.overrideState = true;
    //        _depthOfField.gaussianEnd.overrideState = true;

    //        _depthOfField.gaussianStart.value = Mathf.Lerp(10f, 2f, t);
    //        _depthOfField.gaussianEnd.value = Mathf.Lerp(50f, 5f, t);
    //    }
    //}

}
