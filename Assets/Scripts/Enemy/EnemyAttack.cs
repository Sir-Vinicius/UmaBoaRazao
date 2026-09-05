using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int dano = 2;
    [SerializeField] private float intervaloAtaque = 2f;

    private float proximoAtaque;
    private VidaController vidaPlayer;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        vidaPlayer = player.GetComponent<VidaController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= proximoAtaque)
        {
            Atacar();
            proximoAtaque = Time.time + intervaloAtaque;
        }
    }

    private void Atacar()
    {
        Debug.Log("Inimigo atacou!");
        vidaPlayer.ReceberDano(dano);
    }
}
