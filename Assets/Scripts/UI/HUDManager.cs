using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    //Instancia da HUD
    public static HUDManager Instancia;

    //Referencia das listas de corações e balas
    public GameObject[] vidas;
    public GameObject[] balas;


    //Criação da instancia ao iniciar a cena
    void Awake()
    {
        if (Instancia == null) { Instancia = this; }
        else { Destroy(gameObject); }
    }

    //função para atualizar vidas na HUD
    public void AtualizarVida(int vidaAtual)
    {
        for (int i = 0; i < vidas.Length; i++)
        {
            if (i < vidaAtual)
            {
                vidas[i].SetActive(true);
            }
            else
            {
                vidas[i].SetActive(false);
            }
        }
    }


    //função para atualizar balas na HUD
    public void AtualizarBalas(int balasAtuais)
    {
        for (int i = 0; i < balas.Length; i++)
        {
            if (i < balasAtuais)
            {
                balas[i].SetActive(true);
            }
            else
            {
                balas[i].SetActive(false);
            }
        }
    }

}
