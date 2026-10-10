using UnityEngine;
using UnityEngine.InputSystem;

public class ArmaController : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float rotationSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (camera == null) camera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = camera.ScreenPointToRay(mousePosition);
        float dist = 20f;
        Vector3 lookPoint = ray.GetPoint(dist);

            Vector3 direcao = lookPoint - transform.position;


            if (direcao.sqrMagnitude < 0.0001f)
        {
            Vector3 fallback = ray.GetPoint(10f);
            direcao = fallback - transform.position;
           // direcao.y = 0f;
           if (direcao.sqrMagnitude < 0.0001f) return;
        }
            
                Quaternion targetRot = Quaternion.LookRotation(-direcao.normalized, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotationSpeed);
            
        
    }
}
