using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    float DeltaY = 1.5f; //для контроля высоты внизу экрана, чтобы облака не сбивали миньона вниз
    float speedX, speedY;

    // Start is called before the first frame update
    void Start()
    {
        while (speedX == 0 || speedY == 0)
        {
            speedX = Random.Range(-5, 5);
            speedY = Random.Range(-5, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime;
        float x, y;

        deltaTime = Time.deltaTime;
        transform.Translate(speedX * deltaTime, speedY * deltaTime, 0f);

        x = transform.position.x;
        y = transform.position.y;

        if (x < Constants.ScreenLeft)
            speedX = Random.Range(1, 5);
        else if (x > Constants.ScreenRight)
            speedX = Random.Range(-5, -1);

        if (y > Constants.ScreenTop)
            speedY = Random.Range(-5, -1);
        else if (y - DeltaY < Constants.ScreenBottom)
            speedY = Random.Range(1, 5);
    }
}
