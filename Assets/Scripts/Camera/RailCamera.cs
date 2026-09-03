using UnityEngine;

public class RailCamera : MonoBehaviour
{
    private Vector3[] nodes;
    private int nodeCount;
    [SerializeField] private GameObject camera;
    [SerializeField] private int nodesNumero;
    [SerializeField] private float vel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nodeCount = transform.childCount;
        nodes = new Vector3[nodeCount];


        for (int i = 0; i < nodeCount; i++)
        {
            nodes[i] = transform.GetChild(i).position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // tem que criar o objeto da rail e seu filhos que são os waypoints
        Vector3 railAlvo = nodes[nodesNumero];
        Vector3 posicaoAtual = camera.transform.position;

        Vector3 direcao = (railAlvo - posicaoAtual).normalized;

        camera.transform.position = posicaoAtual + direcao * vel * Time.deltaTime;
     
        if (nodeCount > 1)
        {
            for (int i = 0; i < nodeCount - 1; i++)
            {
                Debug.DrawLine(nodes[i], nodes[i + 1], Color.red);
            }
        }
    }
}

