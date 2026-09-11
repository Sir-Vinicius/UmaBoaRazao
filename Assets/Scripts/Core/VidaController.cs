using UnityEngine;
using FMODUnity;

public class VidaController : MonoBehaviour
{

    [SerializeField] private int vidaAtual, maxVida;
    [SerializeField] private bool morto = false;
    [SerializeField] private bool destruirAoMorrer = true;

    [SerializeField] private EventReference damageSound;
    [SerializeField] private EventReference deathSound;

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

        if (gameObject.CompareTag("Player"))
        {
            HUDManager.Instancia.AtualizarVida(vidaAtual);

        }


        Debug.Log($"{gameObject.name} recebeu {dano} de dano. Vida atual: {vidaAtual}/{maxVida}");

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            morto = true;

            Debug.Log($"{gameObject.name} morreu!");

            RuntimeManager.PlayOneShot(deathSound, transform.position);

            if (destruirAoMorrer) { Destroy(gameObject); }

            return;
        }

        RuntimeManager.PlayOneShot(damageSound, transform.position);
    }
    public void Curar(int cura)
    {
        if (morto) return;
        if (vidaAtual >= maxVida) return;
       
        vidaAtual += cura;
        
        
        Debug.Log($"{gameObject.name} foi curado em {cura}. Vida atual: {vidaAtual}/{maxVida}");
    }
}
