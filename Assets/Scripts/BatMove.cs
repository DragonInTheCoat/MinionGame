using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{
    //public GameObject Player;
    public Rigidbody2D rigPlayer;
    float speedX = 10f;
    float x, y;
    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = transform.position.y;
    }

    public void Restart()
    {
        x = 0;
        transform.position = new Vector2(x, y);
    }
    //при нажатии "вверх", если миньон бездвижен какое-то время, ему придастся импульс вверх
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetAxis("Vertical") > 0)
            {
                rigPlayer.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
        }
    }

    void Update()
    {
        float nowX;

        transform.Translate(Input.GetAxis("Horizontal") * speedX * Time.deltaTime, 0f, 0f);
        nowX = transform.position.x;

        if (nowX > Constants.ScreenRight)
            transform.position = new Vector2(Constants.ScreenRight, y);
        else if (nowX < Constants.ScreenLeft)
            transform.position = new Vector2(Constants.ScreenLeft, y);
    }
}
