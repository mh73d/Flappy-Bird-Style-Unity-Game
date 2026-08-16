using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----------Audio Source-----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("----------Audio clip-----------")]
    public AudioClip background;
    public AudioClip pipetouch;
    public AudioClip death;
    public AudioClip win1;
    public AudioClip win2;
    public AudioClip scorePipe;
    public AudioClip cupSound ;

    public static AudioManager instance;


     void Awake() // to male the background music continue between scenes
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }





    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        musicSource.loop = true;
    }

    //

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    //


     













}
