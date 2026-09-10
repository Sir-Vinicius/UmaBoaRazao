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
    [SerializeField] private GameObject meuEnemy;
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
                        SpawnEnemy(0, 1.8f, true, 1);
                        SpawnEnemy(1, -5.2f, true, 1);
                        SpawnEnemy(2, 5.5f, true, 1);
                        SpawnEnemy(3, 2f, true, 1);
                        SpawnEnemy(4, 1.4f, true, 1);
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
                            
                            SpawnEnemy(5, 12.5f, true, 3);
                            SpawnEnemy(6, 11.3f, true, 3);
                            SpawnEnemy(8, 16f, false, 3);
                            SpawnEnemy(9, 15f, false, 3);
                            evento = true;
                            horda = true;
                            intervaloSpawn = 2f;
                        }

                        if (horda && inimigos.Count <= 0 && intervaloSpawn <= 0f)
                        {
                            SpawnEnemy(5, 12.5f, true, 3);
                            SpawnEnemy(6, 11.3f, true, 3);
                            SpawnEnemy(7, 13.5f, true, 3);
                            SpawnEnemy(8, 16f, false, 3);
                            SpawnEnemy(9, 15f, false, 3);
                            SpawnEnemy(10, 12.5f, true, 3);
                            SpawnEnemy(11, 19.3f, true, 3);
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
    void SpawnEnemy(int nodeIndex, float alvo, bool voltando, int XYZ)
    {
        GameObject enemy = Instantiate(meuEnemy, wayPoints[nodeIndex], Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        inimigos.Add(enemy);
        enemyScript.pontoXYZ = XYZ;
        enemyScript.ponto = alvo;        
        enemyScript.voltandoEnemy = voltando;
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
