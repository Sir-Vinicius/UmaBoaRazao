using UnityEngine;
using UnityEngine.Video;

public class Enemy : MonoBehaviour
{
    private SpawnerController listaEnemy;

    [SerializeField] private Vector3 posicaoOriginal;
    public float pontoX;
        
    public Vector3 pontoAlvo;
    [SerializeField] private float vel = 2f;
    private float intervalo;

    public BoxCollider meuBox;

    public bool indoParaAlvo = true;
    public bool voltandoEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuBox = GetComponent<BoxCollider>();
        listaEnemy = FindAnyObjectByType<SpawnerController>();

        posicaoOriginal = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pontoAlvo = new Vector3(pontoX, posicaoOriginal.y, posicaoOriginal.z);

        if (indoParaAlvo)
        {
            PrepararAtirar();
        }

        if (!indoParaAlvo && voltandoEnemy)
        {
            VoltarPosicaoOriginal();
        }
     }

    private void OnDestroy()
    {
        if (listaEnemy != null)
        {
            listaEnemy.inimigos.Remove(gameObject);
        }
    }
    public void PrepararAtirar()
    {


        Vector3 direcao = (pontoAlvo - transform.position).normalized;

        if (Vector3.Distance(transform.position, pontoAlvo) > 0.1f)
        {
            transform.position = transform.position + direcao * vel * Time.deltaTime;
        }
        
    }
    public void VoltarPosicaoOriginal()
    {
        
        Vector3 direcao = (posicaoOriginal - transform.position).normalized;

        if (Vector3.Distance(transform.position, posicaoOriginal) > 0.1f)
        {
            transform.position = transform.position + direcao * vel * Time.deltaTime;
            
        }


        if (Vector3.Distance(transform.position, posicaoOriginal) < 0.1f)
        {
            if (intervalo == 0)
            {
                intervalo = Random.Range(1f, 3f);
                intervalo = Time.time + intervalo;
            }

            if (Time.time > intervalo)
            {
                indoParaAlvo = true;
                intervalo = 0;
            }
        }
     }
}
