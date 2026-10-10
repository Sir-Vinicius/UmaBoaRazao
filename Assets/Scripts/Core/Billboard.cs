using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 direction = cam.transform.position - transform.position;
        transform.forward = direction;
    }
}
