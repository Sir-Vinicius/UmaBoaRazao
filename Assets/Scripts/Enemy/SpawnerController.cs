using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public Vector3[] nodes;
    private int nodeCount;

    public List<GameObject> inimigos = new List<GameObject>();
    [SerializeField] private GameObject meuEnyme;
    [SerializeField] private GameObject meuCamera;
    [SerializeField]  private RailCamera railCamera;
    //[SerializeField] private GameObject wayPointSpaw;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        railCamera = FindAnyObjectByType<RailCamera>();
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


        if (railCamera.nodesNumero == 1)
        {
            if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
            {
                if (inimigos.Count <= 0)
                {
                    SpawnEnemy(0);
                    SpawnEnemy(1);




                }


            }
        }

    }
    // Aqui ele vai instanciar o inimigo no ponto do waypoint que vc escolher a partidir do numero colocado, e adicionar na lista de inimigos
    void SpawnEnemy(int nodeIndex)
    {
        Instantiate(meuEnyme, nodes[nodeIndex], Quaternion.identity);
        inimigos.Add(meuEnyme);
    }

}
