using UnityEngine;

public class RailCamera : MonoBehaviour
{
    private Vector3[] nodes;
    private int nodeCount;
    [SerializeField] private new GameObject camera;
    [SerializeField] private int nodesNumero;
    [SerializeField] private float vel = 2f;
    [SerializeField] private float velOlhar = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nodeCount = transform.childCount;
        nodes = new Vector3[nodeCount];
        camera = GameObject.Find("Main Camera");

        for (int i = 0; i < nodeCount; i++)
        {
            nodes[i] = transform.GetChild(i).position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();

        if (nodeCount > 1)
        {
            for (int i = 0; i < nodeCount - 1; i++)
            {
                Debug.DrawLine(nodes[i], nodes[i + 1], Color.red);
            }
        }
    }

    private void MoveCamera()
    {
        // tem que criar o Empty "Rail" e criar os filhos "Waypoint", e colocar o script no Empty GameObject.
        Vector3 railAlvo = nodes[nodesNumero];
        Vector3 posicaoAtual = camera.transform.position;
        var visaoAtual = camera.transform.rotation;

        Vector3 direcao = (railAlvo - posicaoAtual).normalized;
        Quaternion direcaoOlhar = Quaternion.LookRotation(direcao);

        if (Vector3.Distance(posicaoAtual, railAlvo) > 0.1f)
        {
            camera.transform.position = posicaoAtual + direcao * vel * Time.deltaTime;
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, direcaoOlhar, velOlhar * Time.deltaTime);
        }
    }
}

