using System.Collections;
using UnityEngine;

public class FadingScript : MonoBehaviour
{

    // CG do FadeIn/Out Geral
    public CanvasGroup canvasGroup;

    // CG do card de cordel para efeito de foco
    public CanvasGroup cardCanvasGroup;
    public CanvasGroup restartButtonCanvasGroup;
    public CanvasGroup exitCanvasGroup;
    public float fadeDuration = 5.0f;
    public bool fadeIn = false;


    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0, fadeDuration));
        Debug.Log("FADEIN");
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1, fadeDuration));
        Debug.Log("FADEOUT");

    }

    public void FadeInFocus()
    {
        if (cardCanvasGroup != null)
        {
            StartCoroutine(FadeCanvasGroup(cardCanvasGroup, cardCanvasGroup.alpha, 1, fadeDuration));
            if (restartButtonCanvasGroup != null)
            {
                StartCoroutine(FadeCanvasGroup(restartButtonCanvasGroup, restartButtonCanvasGroup.alpha, 1, fadeDuration));
                StartCoroutine(FadeCanvasGroup(exitCanvasGroup, exitCanvasGroup.alpha, 1, fadeDuration));
            }

        }
    }

    public void FadeOutFocus()
    {
        if (cardCanvasGroup != null)
        {
            StartCoroutine(FadeCanvasGroup(cardCanvasGroup, cardCanvasGroup.alpha, 0, fadeDuration));
            if (restartButtonCanvasGroup != null)
            {
                StartCoroutine(FadeCanvasGroup(restartButtonCanvasGroup, restartButtonCanvasGroup.alpha, 0, fadeDuration));
                StartCoroutine(FadeCanvasGroup(exitCanvasGroup, exitCanvasGroup.alpha, 0, fadeDuration));
            }            
        }
    }


    // função para Fade Geral da cena
    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }
        cg.alpha = end;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (fadeIn)
        {
            FadeIn();
            FadeInFocus();
        }
        else
        {
            FadeOut();
            FadeOutFocus();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
