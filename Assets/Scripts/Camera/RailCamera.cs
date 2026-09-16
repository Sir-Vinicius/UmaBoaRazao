using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
    [SerializeField] private float atrasoDoDialogo = 1.5f;

    private bool gameOverChamado = false;

    private int nodeAnterior = 0;


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

        nodeAnterior = nodesNumero;

        StartCoroutine(DispararDialogoCoroutine(nodesNumero));
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
        if (nodesNumero != nodeAnterior)
        {
            nodeAnterior = nodesNumero;
            StartCoroutine(DispararDialogoCoroutine(nodesNumero));
        }

        MoveCamera();

        if (nodeCount > 1)
        {
            for (int i = 0; i < nodeCount - 1; i++)
            {
                Debug.DrawLine(nodes[i], nodes[i + 1], Color.red);
            }
        }
    }

    private IEnumerator DispararDialogoCoroutine(int indexNode)
    {
        // O cronômetro que espera a câmera começar a se mover
        yield return new WaitForSeconds(atrasoDoDialogo);

        // Proteção para evitar erros caso tente ler um node que não existe
        if (indexNode < transform.childCount)
        {
            DialogueTrigger trigger = transform.GetChild(indexNode).GetComponent<DialogueTrigger>();

            if (trigger != null)
            {
                trigger.StartDialogue();
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

        // Enquanto estiver longe, se move
        if (Vector3.Distance(posicaoAtual, railAlvo) > 0.1f)
        {
            camera.transform.position = posicaoAtual + direcao * vel * Time.deltaTime;
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, direcaoOlhar, velOlhar * Time.deltaTime);
        }

        // Quando chegar no ponto (Node)
        if (Vector3.Distance(posicaoAtual, railAlvo) <= 0.1f)
        {
            if (rotacionarCamera)
            {
                camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, direcaoOlharCerta, velOlhar * Time.deltaTime);
            }

            
        }

        var player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            var direcaoMorte = (new Vector3(posicaoAtual.x, 90f, posicaoAtual.z) - posicaoAtual).normalized;
            Quaternion direcaoMorteOlhar = Quaternion.LookRotation(direcaoMorte);

         
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, direcaoMorteOlhar, velOlhar * Time.deltaTime);

            Quaternion target = Quaternion.Euler(-90f, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);

            if (!gameOverChamado)
            {
                gameOverChamado = true; 

                UIManager uiManagerDaCena = FindAnyObjectByType<UIManager>();

                if (uiManagerDaCena != null)
                {
                    uiManagerDaCena.OnGameOver();
                }
                else
                {
                    Debug.LogError("ATENÇÃO: O Prefab do UIManager não está nesta cena!");
                }
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
}

