using UnityEngine;

public class FrutaController : MonoBehaviour
{
    private VidaController vidaPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        vidaPlayer = player.GetComponent<VidaController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        vidaPlayer.Curar(1);
    }
}
