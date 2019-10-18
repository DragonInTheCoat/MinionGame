using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplesSpawn : MonoBehaviour
{
    public int Max = 10, Min = 15;
    public GameObject Apple, RedApple;

    public Text TextScore;
    public int RedCount = 3;
    List<GameObject> RedApples;
    List<GameObject> apples;
    int Score;
    Quaternion q;
    Vector3 v;
    int count;
 
    void Start()
    {
        q = new Quaternion();
        count = Random.Range(Min, Max);
        apples = new List<GameObject>();
        RedApples = new List<GameObject>();
        FunAppleSpawn(apples, Apple, count);
        FunAppleSpawn(RedApples, RedApple, RedCount);
        count += RedApples.Count;
    }

    public void CountMinus()
    {
        --count;
        TextScore.text ="Яблок собрано: " + ++Score;
    }

    public void AddGreenApple(GameObject newApple)
    {
        Score += 5;
        apples.Add(newApple);
    }

    public void Restart()
    {
        Score = 0;
        count = 0;
        TextScore.text = "Яблок собрано: 0";
        ListDestroy(apples);
        ListDestroy(RedApples);
        apples = new List<GameObject>();
        RedApples = new List<GameObject>();
    }

    void ListDestroy(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i] != null)
                Destroy(list[i]);
        }
    }

    //Список заполняется префабами яблок, расположенных в случайных местах
    void FunAppleSpawn(List<GameObject> appleList, GameObject prefab, int n)
    {
        appleList = new List<GameObject>();
        for (int i = 0; i < n; ++i)
        {
            v = new Vector3(Random.Range(Constants.ScreenLeft, Constants.ScreenRight),
                Random.Range(Constants.ScreenBottom, Constants.ScreenTop), 0f);

            appleList.Add(Instantiate(prefab, v, q));

            if (appleList[i].GetComponent<CountMinusCaller>() != null)
                appleList[i].GetComponent<CountMinusCaller>().Spawner = this;
            else if (appleList[i].GetComponent<RedAppleSpawn>() != null)
                appleList[i].GetComponent<RedAppleSpawn>().Spawner = this;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(count <= 0)
        {
            count = Random.Range(Min, Max);
            FunAppleSpawn(apples, Apple, count);
            FunAppleSpawn(RedApples, RedApple, RedCount);
            //добавляет количество красных яблок в общий счетчик, чтобы генерация новых яблок
            //начиналась после исчезновения всех яблок, а не только зеленых
            count += RedCount;
        }
    }
}
