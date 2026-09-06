using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private Vector3[] wayPoints;
    private int wayPointsCount;

    public List<GameObject> inimigos = new List<GameObject>();
    [SerializeField] private GameObject meuEnyme;
    [SerializeField] private GameObject meuCamera;
    [SerializeField] private RailCamera railCamera;
    //[SerializeField] private GameObject wayPointSpaw;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        railCamera = FindAnyObjectByType<RailCamera>();
        wayPointsCount = transform.childCount;
        wayPoints = new Vector3[wayPointsCount];
        for (int i = 0; i < wayPointsCount; i++)
        {
            wayPoints[i] = transform.GetChild(i).position;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (railCamera.nodesNumero == 0)
        {
            if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
            {
                if (inimigos.Count <= 0)
                {
                    SpawnEnemy(0);
                }
            }
        }

    }
    // Aqui ele vai instanciar o inimigo no ponto do waypoint que vc escolher a partidir do numero colocado, e adicionar na lista de inimigos
    void SpawnEnemy(int nodeIndex)
    {
        GameObject enemy = Instantiate(meuEnyme, wayPoints[nodeIndex], Quaternion.identity);
        inimigos.Add(enemy);
    }
    
}
