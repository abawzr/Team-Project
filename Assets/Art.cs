using UnityEngine;

public class ArtFall : MonoBehaviour
{
    private bool hasFallen = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasFallen)
        {
            hasFallen = true;
            rb.isKinematic = false;
        }
    }
}
