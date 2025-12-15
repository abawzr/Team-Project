using UnityEngine;

public class ArtFall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioClip audioClip;

    private AudioSource _audioSource;
    private bool hasFallen = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFallen)
        {
            _audioSource.PlayOneShot(audioClip);
            hasFallen = true;
            rb.isKinematic = false;
        }
    }
}
