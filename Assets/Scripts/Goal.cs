using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject winPanel;

    private bool activated = false;

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false); // 🔴 asegura que esté apagado
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player") && GameState.Instance.hasChest)
        {
            activated = true;

            if (winPanel != null)
                winPanel.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}