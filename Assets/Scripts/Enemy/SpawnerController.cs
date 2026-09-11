using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    private Vector3[] wayPoints;
    private int wayPointsCount;

    private bool evento = false;
    [SerializeField]private int horda;
    [SerializeField] private float intervaloSpawn = 2f;

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
                        
                        //SpawnEnemy(0, 1.8f, true, 1);
                        SpawnEnemy(1, -3f, false, 1);
                        SpawnEnemy(2, 5.5f, false, 1);
                        SpawnEnemy(3, 2f, true, 1);
                        SpawnEnemy(4, 1.1f, true, 2);
                        evento = true;
                        
                        evento = true;
                    }
                }   
                break;
            case 1:
                //railCamera.rotacionarCamera = true;
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {
                    
                    if (inimigos.Count <= 0)
                    {
                        if(evento == false)
                        {
                            
                            SpawnEnemy(5, 11.3f, true, 3);
                            SpawnEnemy(6, 6.5f, true, 3);
                            SpawnEnemy(8, 16f, false, 3);
                            SpawnEnemy(9, 15f, false, 3);
                            evento = true;
                            horda = 1;
                            intervaloSpawn = 2f;
                            
                            evento = true;
                        }

                        if (horda == 1 && inimigos.Count <= 0 && intervaloSpawn <= 0f)
                        {
                            
                            SpawnEnemy(5, 11.3f, true, 3);
                            SpawnEnemy(6, 6.5f, true, 3);
                            SpawnEnemy(7, 13.5f, true, 3);
                            SpawnEnemy(8, 16f, false, 3);
                            SpawnEnemy(9, 15f, false, 3);
                            SpawnEnemy(10, 12.5f, true, 3);
                            SpawnEnemy(11, 19.3f, true, 3);
                            horda = 0;
                            
                        }
                    }
                }
                // Handle case 1
                break;
            case 2:
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {

                    if (inimigos.Count <= 0)
                    {
                        if (evento == false)
                        {
                            
                                                      
                         SpawnEnemy(12, 1.182f, true, 2);
                         SpawnEnemy(13, 1.182f, true, 2);
                         SpawnEnemy(14, -21.1f, false, 1);
                         SpawnEnemy(15, -10.07f, false, 1);
                         SpawnEnemy(16, -24.62f, true, 1);

                         evento = true;
                         horda = 1;
                         intervaloSpawn = 2f;
                            
                            evento = true;
                        }
                        if (horda == 1 && inimigos.Count <= 0 && intervaloSpawn <= 0f)
                        {
                            
                            SpawnEnemy(12, 1.182f, true, 2);
                            SpawnEnemy(13, 1.182f, true, 2);
                            SpawnEnemy(14, -21.1f, false, 1);
                            SpawnEnemy(15, -10.07f, false, 1);
                            SpawnEnemy(16, -24.62f, true, 1);
                            horda = 0;
                            
                        }
                    }
                }
                break;
            case 3:

                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {
                    evento = true; 
                    railCamera.vel = 1f;
                }
                    break;
            case 4:
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {
                    railCamera.vel = 2f;
                    if (inimigos.Count <= 0)
                    {
                        if (evento == false)
                        {
                            
                            SpawnEnemy(17, 1.3f, true, 2);
                            SpawnEnemy(18, 5.6f, false, 1);
                            SpawnEnemy(19, 1.3f, true, 2);
                            SpawnEnemy(20, 9.9f, true, 1);
                            SpawnEnemy(21, 6.9f, true, 1);
                            
                            horda = 1;
                            intervaloSpawn = 2f;
                            
                            evento = true;
                        }
                        if (horda == 1 && inimigos.Count <= 0 && intervaloSpawn <= 0f)
                        {
                            SpawnEnemy(17, 1.3f, true, 2);
                            SpawnEnemy(18, 7.3f, false, 1);
                            SpawnEnemy(19, 1.3f, true, 2);
                            SpawnEnemy(20, 9.9f, true, 1);
                            SpawnEnemy(21, 6.9f, true, 1);
                            horda = 0;
                        }
                    }
                }
                break;
            case 5:
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {
                    evento = true;

                }
                break;
            case 6:
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {
                    evento = true;
                    //railCamera.vel = 1f;
                }
                break;
            case 7:
                if (Vector3.Distance(meuCamera.transform.position, railCamera.nodes[railCamera.nodesNumero]) < 0.1f)
                {

                    if (inimigos.Count <= 0)
                    {
                        if (evento == false)
                        {
                            SpawnEnemy(22, 1.1f, true, 2);
                            SpawnEnemy(23, 23.6f, true, 1);
                            SpawnEnemy(24, 19.3f, false, 1);
                            SpawnEnemy(25, 17.5f, false, 1);
                            SpawnEnemy(26, 23.7f, false, 1);
                            evento = true;
                            horda = 1;
                            intervaloSpawn = 2f;

                        }
                        if (horda == 1 && inimigos.Count <= 0 && intervaloSpawn <= 0f)
                        {
                            SpawnEnemy(22, 1.1f, true, 2);
                            SpawnEnemy(23, 23.6f, true, 1);
                            SpawnEnemy(24, 19.3f, false, 1);
                            SpawnEnemy(25, 17.5f, false, 1);
                            SpawnEnemy(26, 23.7f, false, 1);

                            horda = 2;
                            
                            intervaloSpawn = 2f;
                           
                        }
                        if (horda == 2 && inimigos.Count <= 0 && intervaloSpawn <= 0f)
                        {
                            Debug.Log("Spawnei");
                            SpawnEnemy(22, 1.1f, true, 2);
                            SpawnEnemy(23, 23.6f, true, 1);
                            SpawnEnemy(24, 19.3f, false, 1);
                            SpawnEnemy(25, 17.5f, false, 1);
                            SpawnEnemy(28, 17.8f, false, 1);
                            SpawnEnemy(27, 20.5f, false, 1);
                            horda = 0;
                        }


                    }
                }
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
        if (evento && inimigos.Count <= 0 && horda == 0)
        {
            railCamera.nodesNumero++;
            evento = false;
        }
    }
    private void IntervaloHorda()
    {
        if (inimigos.Count <= 0f && horda > 0)
        {
            intervaloSpawn -= Time.deltaTime;
        }
    }
    
}
