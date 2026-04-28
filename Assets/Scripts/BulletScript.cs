using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public AudioClip shootSound; // 🔊 sonido de disparo

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 🔊 reproducir sonido al disparar
        if (shootSound != null)
        {
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }

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
        JohnMovement player = other.GetComponent<JohnMovement>();
        if (player != null)
        {
            player.Hit();
        }

        Destroy(gameObject);
    }
}