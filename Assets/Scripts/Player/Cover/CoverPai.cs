using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CoverPai : MonoBehaviour
{
    public Vector3[] coversOriginal;
    public GameObject[] coversG;
    private int coverCount;
    private int coverCountG;
    [SerializeField] public int coversNumero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    
        coverCountG = transform.childCount;
        coversG = new GameObject[coverCountG];
        coversOriginal = new Vector3[coverCountG];

        for (int i = 0; i < coverCountG; i++)
        {
            coversG[i] = transform.GetChild(i).gameObject;
            coversOriginal[i] = transform.GetChild(i).position;
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
