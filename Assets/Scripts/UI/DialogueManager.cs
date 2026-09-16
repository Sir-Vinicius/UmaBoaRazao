using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public GameObject backgroundBox;


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
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
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





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current == null) return;
        

        // Teste 2: Ele detectou o aperto do espaço?
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {            
            if (isActive)
            {
                NextMessage();
            }
        }

        // Teste 3: Ele detectou o clique do mouse?
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {            
            if (isActive)
            {
                NextMessage();
            }
        }
    }
}
