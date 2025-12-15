// Script by Marcelli Michele

using UnityEngine;

public class PadLockEmissionColor : MonoBehaviour
{
    TimeBlinking tb;

    private Renderer _renderer;
    private Material _materialInstance;
    private static readonly int EmissionColorProperty = Shader.PropertyToID("_EmissionColor");

    [HideInInspector]
    public bool _isSelect;

    private void Awake()
    {
        tb = FindObjectOfType<TimeBlinking>();
        _renderer = GetComponent<Renderer>();

        if (_renderer != null)
        {
            _materialInstance = new Material(_renderer.sharedMaterial);
            _renderer.material = _materialInstance;
            _materialInstance.EnableKeyword("_EMISSION");
        }
    }

    private void Update()
    {
        BlinkingMaterial();
    }

    private void OnDestroy()
    {
        if (_materialInstance != null)
        {
            Destroy(_materialInstance);
        }
    }

    public void BlinkingMaterial()
    {
        if (_materialInstance == null) return;

        _materialInstance.EnableKeyword("_EMISSION");

        if (_isSelect)
        {
            float t = Mathf.PingPong(Time.time, tb.blinkingTime) / tb.blinkingTime;
            Color emissionColor = Color.Lerp(Color.black, Color.green * 0.2f, t);

            _materialInstance.SetColor(EmissionColorProperty, emissionColor);
        }
        else
        {
            _materialInstance.SetColor(EmissionColorProperty, Color.black);
        }
    }
}

