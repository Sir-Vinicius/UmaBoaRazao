using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{

    public FadingScript fading;
    public float readTime = 10f;
    string nextScene;

    string cenaAtual;

    private IEnumerator cutsceneRoutine()
    {
        yield return new WaitForSeconds(fading.fadeDuration);
        yield return new WaitForSeconds(readTime);
        fading.FadeOut();
        fading.FadeOutFocus();
        yield return new WaitForSeconds(fading.fadeDuration);

        //adicionar um if para cada cutscene

        if (cenaAtual == "CordelCutscene1") 
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (cenaAtual == "CordelCutscene2")
        {
            SceneManager.LoadScene("Credits");
        }       

    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cenaAtual = SceneManager.GetActiveScene().name;

        StartCoroutine(cutsceneRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
