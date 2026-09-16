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
        Time.timeScale = 0f;
        jogoPausado = true;
    }

    public void RetomarJogo()
    {
        if (pauseUI != null) pauseUI.SetActive(false);
        Time.timeScale = 1f;
        jogoPausado = false;
    }

    public void OnEnterPausePress()
    {
        PausarJogo();
    }
}
