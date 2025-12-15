using UnityEngine;

public class DrawerOpenClose : MonoBehaviour
{
    [SerializeField] private Transform drawer;
    [SerializeField] private float rotationValue = 68.13f;
    [SerializeField] private float timing = 10f;
    [SerializeField] private AudioClip audioClip;

    private AudioSource _audioSource;
    private bool opened = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!opened) return;

        drawer.localRotation = Quaternion.Lerp(drawer.localRotation, Quaternion.Euler(0f, rotationValue, 0f), timing * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            opened = true;
            _audioSource.PlayOneShot(audioClip);
        }
    }
}
