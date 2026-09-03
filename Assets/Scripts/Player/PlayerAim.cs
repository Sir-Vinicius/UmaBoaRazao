using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private RectTransform crosshair;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        crosshair.position = mousePosition;
    }
}
