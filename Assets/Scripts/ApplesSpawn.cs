using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplesSpawn : MonoBehaviour
{
    public int Max = 10, Min = 15;
    public GameObject Apple;
    GameObject[] apples;
    public Text TextScore;
    int Score;
    Quaternion q;
    Vector3 v;
    int count;
 
    void Start()
    {
        q = new Quaternion();
        
    }

    public void CountMinus()
    {
        --count;
        TextScore.text ="Яблок собрано: " + ++Score;
    }

    public void Restart()
    {
        count = 0;
        Score = 0;
        for(int i = 0; i<apples.Length; ++i)
        {
            if (apples[i] != null)
                Destroy(apples[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject apple;
        CountMinusCaller cmc;
        if(count <= 0)
        {
            count = Random.Range(Min, Max);
            apples = new GameObject[count];
            for (int i = 0; i < count; ++i)
            {
                v = new Vector3(Random.Range(Constants.ScreenLeft, Constants.ScreenRight), 
                    Random.Range(Constants.ScreenBottom, Constants.ScreenTop), 0f);

                apples[i] = Instantiate(Apple, v, q);
                cmc = apples[i].GetComponent<CountMinusCaller>();
                cmc.Spawner = this;
            }
        }


    }
}
