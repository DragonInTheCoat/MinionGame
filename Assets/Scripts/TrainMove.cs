using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    public float Speed = 3f;
    public float Delta = 6f;
    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void Restart()
    {
        transform.position = startPosition;
        gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
        if (Constants.ScreenRight + Delta < transform.position.x)
            gameObject.SetActive(false);
    }
}
