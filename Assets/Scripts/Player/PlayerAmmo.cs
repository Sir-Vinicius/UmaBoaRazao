using FMODUnity;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAmmo : MonoBehaviour
{
    [SerializeField] private int capacidadeCarregador = 6;
    [SerializeField] private int municaoAtual = 6;
    [SerializeField] private int municaoReserva = 999999;

    [SerializeField] private EventReference reloadSound;
    [SerializeField] private GameObject arma;
    public bool recarregando = false;
    private float espera;
    void Start()
    {
        
    }
    void Update()
    {
        espera -= Time.deltaTime;

        if (espera <= 0f)
        {
            recarregando = false;
            var direcao = (new Vector3(arma.transform.localPosition.x, -0.38f, arma.transform.localPosition.z) - arma.transform.localPosition).normalized;

            if (Vector3.Distance(arma.transform.localPosition, new Vector3(arma.transform.localPosition.x, -0.38f, arma.transform.localPosition.z)) > 0.01f)
            {
                arma.transform.localPosition = arma.transform.localPosition + direcao * 3.5f * Time.deltaTime;

            }
        }
        if (espera > 0f)
        {
            var direcao = (new Vector3(arma.transform.localPosition.x, -0.73f, arma.transform.localPosition.z) - arma.transform.localPosition).normalized;

            if (Vector3.Distance(arma.transform.localPosition, new Vector3(arma.transform.localPosition.x, -0.73f, arma.transform.localPosition.z)) > 0.01f)
            {
                arma.transform.localPosition = arma.transform.localPosition + direcao * 3.5f * Time.deltaTime;

            }
        }


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

            HUDManager.Instancia.AtualizarBalas(municaoAtual);

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
        recarregando = true;
        espera = 2.122f;

        RuntimeManager.PlayOneShot(reloadSound);
        HUDManager.Instancia.AtualizarBalas(municaoAtual);

        Debug.Log(
            "[Ammo] Recarregou: " +
            municaoAtual + "/" +
            capacidadeCarregador +
            " | Reserva: " +
            municaoReserva
        );
    }
}
