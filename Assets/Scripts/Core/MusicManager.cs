using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public enum MusicState
{
    Menu,
    Gameplay,
    Victory,
    Defeat
}

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private EventReference musicEvent;
    [SerializeField] private EventReference sadMusicEvent;
    [SerializeField] private MusicState estadoInicial = MusicState.Menu;

    private EventInstance musicInstance;
    private EventInstance sadMusicInstance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(musicEvent);
        musicInstance.start();
        SetEstado(estadoInicial);
    }

    public void SetEstado(MusicState estado)
    {
        musicInstance.setParameterByName("Estado", (float)estado);
    }

    public void TocarSadMusic()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        sadMusicInstance = RuntimeManager.CreateInstance(sadMusicEvent);
        sadMusicInstance.start();
    }

    private void OnDestroy()
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();

        sadMusicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        sadMusicInstance.release();
    }
}
