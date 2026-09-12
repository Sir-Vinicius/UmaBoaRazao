using FMODUnity;
using UnityEngine;

public class UISoundController : MonoBehaviour
{
    [SerializeField] private EventReference hoverSound;
    [SerializeField] private EventReference backSound;
    [SerializeField] private EventReference forwardSound;

    public void PlayHover()
    {
        RuntimeManager.PlayOneShot(hoverSound);
    }

    public void PlayBack()
    {
        RuntimeManager.PlayOneShot(backSound);
    }

    public void PlayForward()
    {
        RuntimeManager.PlayOneShot(forwardSound);
    }
}
