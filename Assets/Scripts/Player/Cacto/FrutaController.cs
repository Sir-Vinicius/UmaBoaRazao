using FMODUnity;
using UnityEngine;

public class FrutaController : MonoBehaviour
{
    private VidaController vidaPlayer;
    [SerializeField] private EventReference cactusSound;

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
        RuntimeManager.PlayOneShot(cactusSound);
    }
}
