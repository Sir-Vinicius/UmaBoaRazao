using UnityEngine;
using UnityEngine.InputSystem;

public class CoverController : MonoBehaviour
{
    [SerializeField] private Vector3 posicaoOriginal;
    
    [SerializeField] private GameObject coverObject;
    public bool isInCover = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicaoOriginal = coverObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Cover();
    }

    private void Cover()
    {
        var posicaoAtual = coverObject.transform.position;
        Vector3 posicaoPonto = GameObject.Find("PontoCover").transform.position;
        var direcao = (posicaoPonto - posicaoAtual).normalized;
        var direcaoOriginal = (posicaoOriginal - posicaoAtual).normalized;
        if (Keyboard.current == null) return;
        
           bool segurando = Keyboard.current.spaceKey.isPressed;

        if (segurando)
        {
            // Debug.Log("Player is taking cover!");
            isInCover = true;
            if(Vector3.Distance(posicaoAtual, posicaoPonto) > 0.1f)
            {
                coverObject.transform.position = posicaoAtual + direcao * Time.deltaTime * 5f;
            }
            
        }
        else
        {
            isInCover = false;
            if (Vector3.Distance(posicaoAtual, posicaoOriginal) > 0.1f)
            {
                coverObject.transform.position = posicaoAtual + direcaoOriginal * Time.deltaTime * 5f;
            }
        }
    }
}
