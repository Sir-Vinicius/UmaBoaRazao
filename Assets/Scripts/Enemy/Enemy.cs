using UnityEngine;
using UnityEngine.Video;

public class Enemy : MonoBehaviour
{
  
    public BoxCollider meuBox;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuBox = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}
