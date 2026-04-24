using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si quien toca la moneda es el jugador
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}