using FMODUnity;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private EventReference footstepSound;
    [SerializeField] private float stepInterval = 0.5f;
    private float stepTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void PlayFootstep()
    {
        // Impede que um passo seja tocado imediatamente depois do outro
        if (stepTimer > 0f)
            return;

        RuntimeManager.PlayOneShot(
            footstepSound,
            transform.position
        );

        stepTimer = stepInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (stepTimer > 0f)
        {
            stepTimer -= Time.deltaTime;
        }
    }
}
