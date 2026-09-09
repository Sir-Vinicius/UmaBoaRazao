using UnityEngine;
using UnityEngine.Events;

public class VidaController : MonoBehaviour
{

    [SerializeField] private int vidaAtual, maxVida;
    [SerializeField] private bool morto = false;
    [SerializeField] private bool destruirAoMorrer = true;

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

        Debug.Log($"{gameObject.name} recebeu {dano} de dano. Vida atual: {vidaAtual}/{maxVida}");

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            morto = true;

            Debug.Log($"{gameObject.name} morreu!");

            if (destruirAoMorrer) { Destroy(gameObject); }

        }


    }
    public void Curar(int cura)
    {
        if (morto) return;
        if (vidaAtual >= maxVida) return;
       
        vidaAtual += cura;
        
        
        Debug.Log($"{gameObject.name} foi curado em {cura}. Vida atual: {vidaAtual}/{maxVida}");
    }
}
