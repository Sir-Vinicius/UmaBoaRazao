using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float shootDistance = 100f;
    [SerializeField] private int dano = 1;

    [SerializeField] private EventReference shootSound;
    [SerializeField] private EventReference ammoSound;

    private PlayerAmmo playerAmmo;

    void Awake()
    {
        playerAmmo = GetComponent<PlayerAmmo>();
        playerCamera = FindAnyObjectByType<Camera>();
        Debug.Log("[PlayerAim] PlayerAmmo encontrado: " + playerAmmo);
    }

    void Start()
    {
        
    }

    void Update()
    {
        Cursor.visible = false;

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        crosshair.position = mousePosition;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Atirar();
        }
    }

    private void Atirar()
    {

        if (!playerAmmo.TemMunicao())
        {
            RuntimeManager.PlayOneShot(ammoSound);
            Debug.Log("[Ammo] Sem munição!");
            return;
        }

        playerAmmo.GastarMunicao();

        RuntimeManager.PlayOneShot(shootSound);

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = playerCamera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, shootDistance))
        {
            Debug.Log("Acertou: " + hit.collider.name +
                  " | VidaController: " +
                  hit.collider.GetComponentInParent<VidaController>());

            VidaController vida = hit.collider.GetComponentInParent<VidaController>();

            if (vida != null)
            {
                vida.ReceberDano(dano);
            }
        }
    }
}
