﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountMinusCaller : MonoBehaviour
{
    public ApplesSpawn Spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Spawner.CountMinus();
            Destroy(gameObject, 0.2f);
        }
    }
}
