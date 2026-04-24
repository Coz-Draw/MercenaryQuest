using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float Speed = 3f;
    public float JumpForce = 3f;
    public GameObject BulletPrefab;

    private Rigidbody2D rb;
    private Animator animator;
    private float horizontal;
    private bool grounded;
    private float lastShoot;
    private int health = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Movimiento
        horizontal = Input.GetAxisRaw("Horizontal");

        // Girar personaje
        if (horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Animaci�n
        if (animator != null)
            animator.SetBool("running", horizontal != 0.0f);

        // Detectar suelo (m�s estable)
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.2f);
        Debug.DrawRay(transform.position, Vector2.down * 0.2f, Color.red);

        // Salto CONTROLADO (sin AddForce)
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }

        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }

        // FORZAR Z = 0 (evita que se vaya detr�s del escenario)
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    private void FixedUpdate()
    {
        // Movimiento estable (sin exageraci�n)
        rb.linearVelocity = new Vector2(horizontal * Speed, rb.linearVelocity.y);
    }

    private void Shoot()
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
        health -= 1;
        if (health <= 0) Destroy(gameObject);
    }
}