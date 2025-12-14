using UnityEngine;

public class StandJumpScare : MonoBehaviour
{
    private bool hasFallen = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
