using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource music;

    private float originalVolume;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (music != null)
            originalVolume = music.volume;
    }

    public void LowerVolume()
    {
        if (music != null)
            music.volume = 0.2f;
    }

    public void RestoreVolume()
    {
        if (music != null)
            music.volume = originalVolume;
    }
}