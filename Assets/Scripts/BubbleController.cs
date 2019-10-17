using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public GameObject Player;
    public GameObject SceneController;
    public float Speed = 3;
    Rigidbody2D rigPlayer;
    Vector2 startPosition;
    bool fl = true;

    void Start()
    {

        rigPlayer = Player.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    public void Restart()
    {
        fl = true;
        transform.position = startPosition;
    }

    void Update()
    {
        if (fl && transform.position.y >= Player.transform.position.y)
        {
            //fl отслеживает, чтобы миньон получал динамическую физику один раз в течение "воскрешения"
            rigPlayer.bodyType = RigidbodyType2D.Dynamic;
            fl = false;
        }

        transform.Translate(Vector2.up * Time.deltaTime * Speed);

        if (Constants.ScreenTop < transform.position.y)
        {
            //Выключает Bubble и включает родительский контроллер поезда, облаков и биты
            fl = true;
            SceneController.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
