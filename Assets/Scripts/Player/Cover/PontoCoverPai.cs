using UnityEngine;

public class PontoCoverPai : MonoBehaviour
{
    public Vector3[] pontos;
    public GameObject[] pontosG;
    private int pontoCount;
    private int pontoCountG;
    [SerializeField] public int pontosNumero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pontoCount = transform.childCount;
        pontos = new Vector3[pontoCount];

        for (int i = 0; i < pontoCount; i++)
        {
            pontos[i] = transform.GetChild(i).position;
        }

        pontoCountG = transform.childCount;
        pontosG = new GameObject[pontoCountG];

        for (int i = 0; i < pontoCountG; i++)
        {
            pontosG[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
