using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject messagePanel;
    private bool activated = false;

    private void Start()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false); // 🔒 asegurar estado inicial
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            if (messagePanel != null)
            {
                messagePanel.SetActive(true);
                StartCoroutine(HideMessage());
            }

            // Ocultar cofre sin destruir (para que la coroutine funcione)
            GetComponent<Collider2D>().enabled = false;
            var sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = false;
        }
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(3f);
        if (messagePanel != null)
            messagePanel.SetActive(false);
    }
}