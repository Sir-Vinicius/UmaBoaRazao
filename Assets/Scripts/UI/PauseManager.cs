using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{

    //ref PausePanel
    [SerializeField] private GameObject pauseUI;

    private bool jogoPausado = false;


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (jogoPausado)
            {
                RetomarJogo();
            }
            else
            {
                PausarJogo();
            }
        }
    }

    public void PausarJogo()
    {
        if (pauseUI != null) pauseUI.SetActive(true);
        var playerAim = FindAnyObjectByType<PlayerAim>();
        var playerAmmo = FindAnyObjectByType<PlayerAmmo>();
        var armaController = FindAnyObjectByType<ArmaController>();
        if (playerAim != null && playerAmmo != null && armaController != null)
        {
            playerAim.enabled = false;
            playerAmmo.enabled = false;
            armaController.enabled = false;
        }
        Time.timeScale = 0f;
        Cursor.visible = true;
        jogoPausado = true;
    }

    public void RetomarJogo()
    {
        if (pauseUI != null) pauseUI.SetActive(false);
        var playerAim = FindAnyObjectByType<PlayerAim>();
        var playerAmmo = FindAnyObjectByType<PlayerAmmo>();
        var armaController = FindAnyObjectByType<ArmaController>();
        if (playerAim != null && playerAmmo != null && armaController != null)
        {
            playerAim.enabled = true;
            playerAmmo.enabled = true;
            armaController.enabled = true;
        }

        Time.timeScale = 1f;
        Cursor.visible = false;
        jogoPausado = false;
    }

    public void OnEnterPausePress()
    {
        PausarJogo();
    }
}
