using UnityEngine;

public class DrawerJumpScare : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    public Transform drawer;
    public float openDistance = 0.2f;
    [SerializeField] private float timing = 0.2f;

    private AudioSource _audioSource;
    private Animator _animator;
    private bool opened = false;
    private bool oneTimeMoved = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            _animator.SetTrigger("Open");
            _audioSource.PlayOneShot(audioClip);
            opened = true;
            // drawer.position += drawer.forward * openDistance;
        }
    }
}
