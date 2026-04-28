using UnityEngine;

public class JohnCollisinons : MonoBehaviour
{
    private Animator animator;
    private bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !isDead)
        {
            isDead = true;

            animator.SetTrigger("johnDie");

            // Detener movimiento (opcional pero recomendado)
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Static;
            }

            // Desactivar colisiones para evitar bugs
            GetComponent<Collider2D>().enabled = false;

            // NO destruir inmediatamente
            Destroy(gameObject, 1.5f);
        }
    }
}
