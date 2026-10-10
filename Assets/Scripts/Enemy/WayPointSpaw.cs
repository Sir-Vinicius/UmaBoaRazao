using UnityEngine;

public class WayPointSpaw : MonoBehaviour
{
    public bool spawnAtivado = false;
    private Vector3 meuTransform;
    [SerializeField] private GameObject meuEnyme;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuTransform = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
