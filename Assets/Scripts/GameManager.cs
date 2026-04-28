using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;
    public AudioSource music;

    private float originalVolume;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 🔥 IMPORTANTE: asegurar estado inicial limpio
        Time.timeScale = 1f;
        isGameOver = false;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (music != null)
            originalVolume = music.volume;
    }

    void Update()
    {
        if (!isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void GameOver()
    {
        // 🔥 evita que se dispare varias veces
        if (isGameOver) return;

        isGameOver = true;

        Time.timeScale = 0f;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (music != null)
            music.volume = 0.2f;
    }

    void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}