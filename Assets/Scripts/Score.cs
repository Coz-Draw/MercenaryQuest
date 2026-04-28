using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int cobre = 0;
    public int oro = 0;

    public Text cobreText;
    public Text oroText;

    void Start()
    {
        cobreText.text = "COBRE: 0";
        oroText.text = "ORO: 0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("moneda"))
        {
            cobre++;
            cobreText.text = "COBRE: " + cobre;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("moneda2"))
        {
            oro++;
            oroText.text = "ORO: " + oro;
            Destroy(collision.gameObject);
        }
    }
}