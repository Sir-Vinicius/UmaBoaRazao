using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //ref modal de pause
    public GameObject pauseUI;
    public GameObject continueButton;

    //Botão de resetar fase
    public void OnRestartPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Botão de continuar fase no modal de pause
    public void OnGameResumePress()
    {
        pauseUI.SetActive(false);
    }

    //Botão de Sair no Main Menu
    public void OnGameExitPress()
    {
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
        SceneManager.LoadScene("Credits");
    }

    //Botão de Sair - PauseUI
    public void OnMainMenuPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnJogarPress()
    {
        //Zera o save para começar do inicio
        PlayerPrefs.SetInt("CheckpointNode", 0);
        //Cutscene na primeira vez que for jogar
        SceneManager.LoadScene("CordelCutscene1");
    }

    public void OnContinuePress()
    {
        //TROCAR PARA CENA DA GAMEPLAY
        //Carrega a scene e mantém o save intacto
        SceneManager.LoadScene("CordelCutscene1");
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

    // Update is called once per frame
    void Update()
    {

    }
}
