using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAppleSpawn : MonoBehaviour
{
    public GameObject GreenApple;
    public ApplesSpawn Spawner;
    CountMinusCaller cmc;
    GameObject newApple;

    private void Start()
    {
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            newApple = Instantiate(GreenApple, transform.position, transform.rotation);
            cmc = newApple.GetComponent<CountMinusCaller>();
            cmc.Spawner = Spawner;
            cmc.Spawner.AddGreenApple(newApple);
            Destroy(gameObject);
        }
    }
}
