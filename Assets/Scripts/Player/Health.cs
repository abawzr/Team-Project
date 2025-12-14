using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Ending ending;
    [SerializeField] private GameObject[] bodyParts;
    [SerializeField] private float maxHealth;
    [SerializeField] private float healthDropRate;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Volume volumeProfile;

    private float _currentHealth;

    public static Health Instance { get; private set; }

    public static bool CanSeeBodyParts { get; private set; }

    //start
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _currentHealth = maxHealth;
        ShowBodyParts(false);

        if (healthSlider != null)
        {
            healthSlider.minValue = 0f;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = _currentHealth;
        }
    }

    private void Update()
    {
        if (_currentHealth > 0f)
        {
            _currentHealth -= healthDropRate * Time.deltaTime;

            if (_currentHealth < 0f)
            {
                _currentHealth = 0f;
                ending.TriggerEnding2();
            }
        }

        if (healthSlider != null)
        {
            healthSlider.value = _currentHealth;
        }

        float m = maxHealth * 0.75f;

        if (_currentHealth <= m && _currentHealth > 0f)
        {
            ShowBodyParts(true);
            CanSeeBodyParts = true;
            volumeProfile.gameObject.SetActive(true);
        }
        else
        {
            ShowBodyParts(false);
            CanSeeBodyParts = false;
            volumeProfile.gameObject.SetActive(false);
        }
    }

    public void AddDrug(float amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0f, maxHealth);

        if (healthSlider != null)
            healthSlider.value = _currentHealth;
    }

    private void ShowBodyParts(bool Hide)
    {
        foreach (var part in bodyParts)
        {
            if (playerInventory.CurrentItem == part)
                continue;

            if (part != null)
                part.SetActive(Hide);
        }
    }
}
