using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject storyPanel;

    private bool isActive = true;

    void Start()
    {
        Time.timeScale = 0f;

        if (storyPanel != null)
            storyPanel.SetActive(true);
    }

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueGame();
        }
    }

    public void ContinueGame()
    {
        isActive = false;

        Time.timeScale = 1f;

        if (storyPanel != null)
            storyPanel.SetActive(false);
    }
}