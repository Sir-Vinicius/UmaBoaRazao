using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageOverlayController : MonoBehaviour
{
    [SerializeField] private Image damageOverlay;
    [SerializeField] private float tempoVisivel = 0.15f;
    [SerializeField] private float tempoFade = 0.3f;

    private Coroutine damageCoroutine;
    void Start()
    {
        damageOverlay.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarDano()
    {
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
        }

        damageCoroutine = StartCoroutine(EfeitoDano());
    }

    private IEnumerator EfeitoDano()
    {
        damageOverlay.color = new Color(1f, 1f, 1f, 1f);

        yield return new WaitForSeconds(tempoVisivel);

        float tempo = 0f;

        while (tempo < tempoFade)
        {
            tempo += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, tempo / tempoFade);

            damageOverlay.color = new Color(1f, 1f, 1f, alpha);

            yield return null;
        }

        damageOverlay.color = new Color(1f, 1f, 1f, 0f);

        damageCoroutine = null;
    }
}
