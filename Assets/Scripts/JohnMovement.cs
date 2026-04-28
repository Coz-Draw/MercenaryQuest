using System.Collections;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float Speed = 3f;
    public float JumpForce = 3f;
    public GameObject BulletPrefab;

    public GameOverUI gameOverUI;

    private Rigidbody2D rb;
    private Animator animator;
    private float horizontal;
    private bool grounded;
    private float lastShoot;

    private int health = 5;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal > 0) transform.localScale = new Vector3(1, 1, 1);

        if (animator != null)
            animator.SetBool("running", horizontal != 0);

        grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.2f);

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    void FixedUpdate()
    {
        if (isDead) return;
        rb.linearVelocity = new Vector2(horizontal * Speed, rb.linearVelocity.y);
    }

    void Shoot()
    {
        Vector3 direction = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

        GameObject bullet = Instantiate(
            BulletPrefab,
            transform.position + direction * 0.5f,
            Quaternion.identity
        );

        BulletScript bulletScript = bullet.GetComponent<BulletScript>();
        if (bulletScript != null)
            bulletScript.SetDirection(direction);
    }

    public void Hit()
    {
        if (isDead) return;

        health--;

        if (health <= 0)
        {
            isDead = true;

            if (animator != null)
                animator.SetTrigger("johnDie");

            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;

            GetComponent<Collider2D>().enabled = false;

            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1.5f);

        if (gameOverUI != null)
            gameOverUI.ShowGameOver();

        Destroy(gameObject);
    }
}