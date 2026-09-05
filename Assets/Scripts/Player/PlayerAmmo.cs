using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] private int capacidadeCarregador = 6;
    [SerializeField] private int municaoAtual = 6;
    [SerializeField] private int municaoReserva = 999999;
    void Start()
    {
        
    }
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Recarregar();
        }
    }

    public bool TemMunicao()
    {
        return municaoAtual > 0;
    }

    public void GastarMunicao()
    {
        if (municaoAtual > 0)
        {
            municaoAtual--;

            Debug.Log(
                "[Ammo] Munição: " +
                municaoAtual + "/" +
                capacidadeCarregador +
                " | Reserva: " +
                municaoReserva
            );
        }
    }

    public void Recarregar()
    {
        if (municaoAtual >= capacidadeCarregador)
        {
            Debug.Log("[Ammo] Carregador já está cheio.");
            return;
        }

        if (municaoReserva <= 0)
        {
            Debug.Log("[Ammo] Sem munição reserva.");
            return;
        }

        int espacoDisponivel = capacidadeCarregador - municaoAtual;
        int quantidadeRecarregada = Mathf.Min(espacoDisponivel, municaoReserva);

        municaoAtual += quantidadeRecarregada;
        municaoReserva -= quantidadeRecarregada;

        Debug.Log(
            "[Ammo] Recarregou: " +
            municaoAtual + "/" +
            capacidadeCarregador +
            " | Reserva: " +
            municaoReserva
        );
    }
}
