using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionController : MonoBehaviour
{
    public Text Score, LifesText;
    public int Lifes = 3;
    public GameObject Bubble, Panel, Bat;
    public float StartBubbleY = -6.91f;
    int iScore = 0;
    bool fl = true;
    Vector2 startPosition;
    Rigidbody2D rigPlayer;

    void Start()
    {
        startPosition = transform.position;
        rigPlayer = GetComponent<Rigidbody2D>();
        LifesText.text = "Жизней: " + Lifes;
        Score.text = "Счёт: 0";
    }

    public void Restart()
    {
        Lifes = 3;
        iScore = 0;
        LifesText.text = "Жизней: " + Lifes;
        Score.text = "Счёт: 0";
        transform.position = startPosition;
        rigPlayer.bodyType = RigidbodyType2D.Dynamic;
        Panel.SetActive(false);
        fl = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bat")
        {
            ++iScore;
            Score.text = "Счёт: " + iScore;
        }
        else if(collision.gameObject.tag == "Grass" && fl)
        {
            //Включает Bubble и выключает динамическую физику Minion
            //fl фиксирует, чтобы не попасть в эту часть алгоритма, если миньон чуть прокатится по траве
            rigPlayer.bodyType = RigidbodyType2D.Static;
            fl = false;
            if (Lifes-- > 0)
            {
                Bubble.transform.position = new Vector2(gameObject.transform.position.x, StartBubbleY);
                Bubble.SetActive(true);
                LifesText.text = "Жизней: " + Lifes;
            }
            else
                Panel.SetActive(true);
        }
        else if(collision.gameObject.tag == "Bubble")
            fl = true;
    }

    /*private void Update()
    {
        if (rigPlayer.velocity.x > 5 || rigPlayer.velocity.y > 5)
            rigPlayer.velocity = new Vector2(5f, 5f);

    }*/
}
