using UnityEngine;
using UnityEngine.Video;

public class Enemy : MonoBehaviour
{
    private SpawnerController listaEnemy;

    public BoxCollider meuBox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuBox = GetComponent<BoxCollider>();
        listaEnemy = FindAnyObjectByType<SpawnerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        if (listaEnemy != null)
        {
            listaEnemy.inimigos.Remove(gameObject);
        }
    }

}
