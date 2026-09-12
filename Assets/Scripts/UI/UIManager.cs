using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //ref modal de pause
    public GameObject pauseUI;
    public GameObject continueButton;

    public FadingScript fading;

    [SerializeField] private UISoundController uiSound;

    //Botão de resetar fase
    public void OnRestartPress()
    {
        StartCoroutine(TransicaoDeCena(SceneManager.GetActiveScene().name));
    }

    //Botão de continuar fase no modal de pause
    public void OnGameResumePress()
    {
        //Som do botão
        uiSound.PlayBack();
        pauseUI.SetActive(false);
    }

    //Botão de Sair no Main Menu
    public void OnGameExitPress()
    {
        //Som do botão
        uiSound.PlayBack();

        Application.Quit();
    }

    //Botão de Pause
    public void OnEnterPausePress()
    {
        pauseUI.SetActive(true);
    }

    //Botão de Créditos - Main Menu
    public void OnCreditsPress()
    {
        uiSound.PlayForward();
        StartCoroutine(TransicaoDeCena("Credits"));
    }

    //Botão de Sair - PauseUI
    public void OnMainMenuPress()
    {
        StartCoroutine(TransicaoDeCena("MainMenu"));
    }

    public void OnJogarPress()
    {
        //Sons do botão
        uiSound.PlayForward();
        //Zera o save para começar do inicio
        PlayerPrefs.SetInt("CheckpointNode", 0);
        //Música Gameplay
        MusicManager.Instance.SetEstado(MusicState.Gameplay);
        //Cutscene na primeira vez que for jogar
        StartCoroutine(TransicaoDeCena("CordelCutscene1"));
    }

    public void OnContinuePress()
    {
        //Som do botão
        uiSound.PlayForward();
        //TROCAR PARA CENA DA GAMEPLAY
        //Música Gameplay
        MusicManager.Instance.SetEstado(MusicState.Gameplay);
        //Carrega a scene e mantém o save intacto
        StartCoroutine(TransicaoDeCena("CordelCutscene1"));
    }

    public void OnGameOver()
    {
        //Música de derrota
        MusicManager.Instance.SetEstado(MusicState.Defeat);
        Debug.Log("GAMEOVER CUTSCENE");
        StartCoroutine(TransicaoDeCena("GameOverCutscene"));
    }

    private IEnumerator TransicaoDeCena(string nomeDaCena)
    {
        fading.FadeOut();

        yield return new WaitForSeconds(fading.fadeDuration);

        SceneManager.LoadScene(nomeDaCena);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vetifica se o jogador tem save (node maior que 0)
        if (PlayerPrefs.HasKey("CheckpointNode") && PlayerPrefs.GetInt("CheckpointNode") > 0) 
        {
            continueButton.SetActive(true); //Ativa continueButton
        }
        else
        {
            continueButton.SetActive(false); //Desativa continueButton
        }

    }
    //Scene de vitoria
    public void OnVictory()
    {
        // Musica de vitoria
        MusicManager.Instance.SetEstado(MusicState.Victory);
        // Futura scene de vitoria. Pode ser só ui e não uma scene no futuro.
        StartCoroutine(TransicaoDeCena("Victory"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
