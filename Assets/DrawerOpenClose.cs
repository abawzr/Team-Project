using UnityEngine;

public class DrawerOpenClose : MonoBehaviour
{
    public Transform drawer;
    public float openDistance = 0.2f;

    private Vector3 closedPosition;
    private bool opened = false;

    void Start()
    {
        closedPosition = drawer.localPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !opened)
        {
            opened = true;
            drawer.localPosition = closedPosition + Vector3.forward * openDistance;
        }
    }

    public void CloseDrawer()
    {
        drawer.localPosition = closedPosition;
        opened = false;
    }
}
