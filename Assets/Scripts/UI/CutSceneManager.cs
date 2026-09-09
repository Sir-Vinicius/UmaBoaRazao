using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{

    public FadingScript fading;
    public float readTime = 10f;
    string nextScene;


    private IEnumerator cutsceneRoutine()
    {
        yield return new WaitForSeconds(fading.fadeDuration);
        yield return new WaitForSeconds(readTime);
        fading.FadeOut();
        fading.FadeOutCardFocus();
        yield return new WaitForSeconds(fading.fadeDuration);
        //adicionar um if para cada cutscene
        SceneManager.LoadScene("MainMenu");
        

    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(cutsceneRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
