using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private bool isActive = false;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isActive) return;

        // ESPACIO → reiniciar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // ESC → salir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    public void ShowGameOver()
    {
        if (isActive) return;

        isActive = true;

        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }
}