using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioClip sound;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Sonido (opcional)
        if (Camera.main != null && sound != null)
        {
            AudioSource audio = Camera.main.GetComponent<AudioSource>();
                audio.PlayOneShot(sound);
        }
     
    }
}