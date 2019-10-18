using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject Train, Bubble;
    //public GameObject Bat, Cloud1, Cloud2, Cloud3;
    int Times; //количество тиков между поездами
    Vector2 StartTrainPosition;

    void Start()
    {
        Times = Random.Range(1000, 5000);
        StartTrainPosition = Train.transform.position;
    }

    public void Restart()
    {
        Times = Random.Range(1000, 5000);
    }

    void FixedUpdate()
    {
        //когда на сцене появляется пузырь, всё остальное должно исчезнуть, чтобы не мешать
        if (Bubble.activeSelf)
            gameObject.SetActive(false);
        else
        {
            //SetActivFun(StartTrainPosition.x < Train.transform.position.x, true, true, true, true);

            if (!Train.activeSelf)
            {
                if (Times-- < 0)
                {
                    Train.SetActive(true);
                    Train.transform.position = StartTrainPosition;
                    Times = Random.Range(1000, 5000);
                }

            }
        }
    }

    //void SetActivFun(bool train, bool bat, bool cloud1, bool cloud2, bool cloud3)
    //{
    //    Train.SetActive(train);
    //    Bat.SetActive(bat);
    //    Cloud1.SetActive(cloud1);
    //    Cloud2.SetActive(cloud2);
    //    Cloud3.SetActive(cloud3);
    //}

}
