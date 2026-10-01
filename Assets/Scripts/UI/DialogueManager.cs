using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public GameObject backgroundBox;

    public float tempoPorMensagem = 2f;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;


    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        backgroundBox.SetActive(true);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Debug.Log("=== DisplayMessage entrou ===");
        Debug.Log($"currentMessages: {currentMessages?.Length}");
        Debug.Log($"currentActors: {currentActors?.Length}");
        Debug.Log($"activeMessage: {activeMessage}");

        Message messageToDisplay = currentMessages[activeMessage];

        Debug.Log($"Mensagem obtida. actorID: {messageToDisplay.actorID}");

        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        Debug.Log($"Actor obtido: {actorToDisplay.name}");
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        StopAllCoroutines();
        StartCoroutine(AutoAdvance());
    }

    IEnumerator AutoAdvance()
    {
        yield return new WaitForSeconds(tempoPorMensagem);
        NextMessage();
    }

    public void NextMessage()
    {
        activeMessage++;

        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("fim monólogo");
            isActive = false;
            backgroundBox.SetActive(false);
        }
    }

    
}
