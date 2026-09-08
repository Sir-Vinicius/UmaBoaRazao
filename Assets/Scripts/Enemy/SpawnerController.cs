using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private Vector3[] wayPoints;
    private int wayPointsCount;

    private bool evento = false;
    private bool horda = false;
    private float intervaloSpawn = 2f;

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
        ProximoEvento();
        IntervaloHorda();

        switch (railCamera.nodesNumero)
        {
            case 0:
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {
                    if (inimigos.Count <= 0)
                    {
                        SpawnEnemy(0);
                        SpawnEnemy(1);
                        evento = true;
                    }
                }
                break;
            case 1:
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {
                    if (inimigos.Count <= 0)
                    {
                        if(evento == false)
                        {
                            SpawnEnemy(2);
                            SpawnEnemy(3);
                            evento = true;
                            horda = true;
                            intervaloSpawn = 2f;
                        }

                        if (horda && inimigos.Count <= 0 && intervaloSpawn <= 0f)
                        {
                            SpawnEnemy(2);
                            SpawnEnemy(3);
                            SpawnEnemy(4);
                            horda = false;
                            
                        }
                    }
                }
                // Handle case 1
                break;
            // Add more cases as needed
        }

    }
    // Aqui ele vai instanciar o inimigo no ponto do waypoint que vc escolher a partidir do numero colocado, e adicionar na lista de inimigos
    void SpawnEnemy(int nodeIndex)
    {
        GameObject enemy = Instantiate(meuEnyme, wayPoints[nodeIndex], Quaternion.identity);
        inimigos.Add(enemy);
    }

    private void ProximoEvento()
    {
        if (evento && inimigos.Count <= 0 && horda == false)
        {
            railCamera.nodesNumero++;
            evento = false;
        }
    }
    private void IntervaloHorda()
    {
        if (inimigos.Count <= 0f && horda)
        {
            intervaloSpawn -= Time.deltaTime;
        }
    }
    
}
