using UnityEngine;
using UnityEngine.InputSystem;

public class CoverController : MonoBehaviour
{
    private CoverPai coverPai;
    private PontoCoverPai pontoCoverPai;
    private RailCamera railCamera;
    [SerializeField] private Vector3 posicaoOriginal;
    
    [SerializeField] private GameObject coverObject;
    public bool isInCover = false;
    private GameObject meuCamera;
    private Vector3 eulerOriginal;
    private float currentPitch;
    [SerializeField] private float alvoPitch = 18f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coverPai = FindAnyObjectByType<CoverPai>();
        pontoCoverPai = FindAnyObjectByType<PontoCoverPai>();
        railCamera = FindAnyObjectByType<RailCamera>();
        
        meuCamera = GameObject.Find("Main Camera");
        eulerOriginal = meuCamera.transform.rotation.eulerAngles;
        currentPitch = eulerOriginal.x;

    }

    // Update is called once per frame
    void Update()
    {
        posicaoOriginal = coverPai.coversOriginal[railCamera.nodesNumero];
        Cover();
    }

    private void Cover()
    {
        

        var posicaoAtual = coverPai.coversG[railCamera.nodesNumero].transform.position;
        Vector3 posicaoPonto = pontoCoverPai.pontosG[railCamera.nodesNumero].transform.position;
        var direcao = (posicaoPonto - posicaoAtual).normalized;
        var direcaoOriginal = (posicaoOriginal - posicaoAtual).normalized;

        Debug.Log(posicaoAtual);
        Debug.Log(posicaoPonto);



        if (Keyboard.current == null) return;

        bool segurando = Keyboard.current.spaceKey.isPressed;

        if (segurando)
        {
            // Debug.Log("Player is taking cover!");
            isInCover = true;
            if (Vector3.Distance(posicaoAtual, posicaoPonto) > 0.01f)
            {
                coverPai.coversG[railCamera.nodesNumero].transform.position = posicaoAtual + direcao * Time.deltaTime * 5f;
                currentPitch = Mathf.LerpAngle(currentPitch, alvoPitch, 5f * Time.deltaTime);
                meuCamera.transform.rotation = Quaternion.Euler(currentPitch, meuCamera.transform.rotation.eulerAngles.y, meuCamera.transform.rotation.eulerAngles.z);

            }

        }
        else
        {
            isInCover = false;
            if (Vector3.Distance(posicaoAtual, posicaoOriginal) > 0.01f)
            {
                coverPai.coversG[railCamera.nodesNumero].transform.position = posicaoAtual + direcaoOriginal * Time.deltaTime * 5f;
                currentPitch = Mathf.LerpAngle(currentPitch, 0f, 5f * Time.deltaTime);
                meuCamera.transform.rotation = Quaternion.Euler(currentPitch, meuCamera.transform.rotation.eulerAngles.y, meuCamera.transform.rotation.eulerAngles.z);
            }
        }
    }
    private void Cover2()
    {

    }
}
