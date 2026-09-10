using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int dano = 2;
    [SerializeField] private float intervaloAtaque;

    private float proximoAtaque;
    private VidaController vidaPlayer;
    private CoverController coverController;
    private Enemy enemy;
    public bool arrivedAtTarget = true;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        vidaPlayer = player.GetComponent<VidaController>();
        coverController = player.GetComponent<CoverController>();

        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, enemy.pontoAlvo) < 0.1f)
        {
            if (arrivedAtTarget)
            {
                enemy.meuAnimation.SetBool("Atirando", true);
                intervaloAtaque = Random.Range(1f, 3f);
                proximoAtaque = Time.time + intervaloAtaque;
                arrivedAtTarget = false;
            }

            if (Time.time >= proximoAtaque)
            {
                Atacar();
                arrivedAtTarget = true;
                enemy.indoParaAlvo = false;
            }
        }
       
    }

    private void Atacar()
    {
        if (coverController.isInCover == false)
        {
            Debug.Log("Inimigo atacou!");
            vidaPlayer.ReceberDano(dano);
        }
        else
        {
            Debug.Log("Bloqueado");
        }
        enemy.meuAnimation.SetBool("Atirando", false);
    }
}
