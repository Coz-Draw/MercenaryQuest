using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    private int score = 0;
    public Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "moneda")
        {
            score++;
            scoreText.text = "SCORE: " + score;
        }
    }
}
