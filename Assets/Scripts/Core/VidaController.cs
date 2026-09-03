using UnityEngine;
using UnityEngine.Events;

public class VidaController : MonoBehaviour
{

    [SerializeField] private int vidaAtual, maxVida;
    [SerializeField] private bool morto = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    /*public void VidaIniciada(int vidaValue)
    {
        vidaAtual = vidaValue;
        maxVida = vidaValue;
        morto = false;
    }
    Isso aqui é para quando criar scriptable object
    */
    public void ReceberDano(int dano)
    {
        if (morto) return;
 

        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            morto = true;
            Destroy(gameObject);
        }
        

    }
}
