using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Message[] messages;
    public Actor[] actors;



    public void StartDialogue()
    {
        Debug.Log("=== StartDialogue chamado ===");
        Debug.Log($"Messages no Trigger: {messages?.Length}");
        Debug.Log($"Actors no Trigger: {actors?.Length}");
        FindAnyObjectByType<DialogueManager>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorID;
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}