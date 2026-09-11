using Unity.VisualScripting;
using UnityEngine;

public class RailCamera : MonoBehaviour
{
    public Vector3[] nodes;
    private int nodeCount;
    [SerializeField] private new GameObject camera;
    [SerializeField] public int nodesNumero;
    [SerializeField] public float vel = 2f;
    [SerializeField] private float velOlhar = 2f;
    [SerializeField] private float direcaoY;
    [SerializeField] public bool rotacionarCamera = false;
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


        //SISTEMA DE SAVE
        /*
        
        nodesNumero = PlayerPrefs.GetInt("checkpointNode", 0);
        
        if (nodesNumero < nodeCount)
        {
            camera.transform.position = nodes[nodesNumero];
        }

        */
         
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
        Vector3 diracaoCamera = (new Vector3(posicaoAtual.x, nodes[nodesNumero].y, posicaoAtual.z) - posicaoAtual).normalized;
        Quaternion direcaoOlhar = Quaternion.LookRotation(direcao);
        Quaternion direcaoOlharCerta = Quaternion.LookRotation(diracaoCamera);

        if (Vector3.Distance(posicaoAtual, railAlvo) > 0.1f)
        {
            camera.transform.position = posicaoAtual + direcao * vel * Time.deltaTime;
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, direcaoOlhar, velOlhar * Time.deltaTime);
        }
        if(Vector3.Distance(posicaoAtual, railAlvo) <= 0.1f && rotacionarCamera)
        {
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, direcaoOlharCerta, velOlhar * Time.deltaTime);
        }

        //SISTEMA DE SAVE
        /*
        
        else
        {
            nodesNumero++; //Pula para o próximo alvo

            PlayerPrefs.SetInt("CheckpointNode", nodesNumero); //salva o novo alvo 
            PlayerPrefs.Save();
        }

        */
    }
}

