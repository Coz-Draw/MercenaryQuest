using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public AudioClip sound;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Sonido (opcional)
        if (Camera.main != null && sound != null)
        {
            AudioSource audio = Camera.main.GetComponent<AudioSource>();
            if (audio != null)
                audio.PlayOneShot(sound);
        }

        // Autodestrucción
        Destroy(gameObject, 2f);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = new Vector2(dir.x, 0).normalized;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destruir entre balas
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        // Daño enemigo
        GruntScript grunt = other.GetComponent<GruntScript>();
        if (grunt != null)
            grunt.Hit();

        // Daño jugador (opcional)
        JohnMovement player = other.GetComponent<JohnMovement>();
        if (player != null)
            player.Hit();

        Destroy(gameObject);
    }
}