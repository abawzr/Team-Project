using UnityEngine;

public class DrawerJumpScare : MonoBehaviour
{
    public Transform drawer;
    public float openDistance = 0.2f;

    private bool opened = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            opened = true;
            drawer.position += drawer.forward * openDistance;
        }
    }
}
