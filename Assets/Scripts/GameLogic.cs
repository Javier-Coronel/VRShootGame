using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    int round = 1;
    public GameObject enemyPrefab;
    List<GameObject> enemies;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var item in enemies)
        {
            if (!item)
            {
                enemies.Remove(item);
            }
        }
        if (enemies.Count == 0)
        {
            round++;
            int enemiesInRound = round * (int)Math.Floor(Math.E * 1.5);
            for (int i = 0; i < enemiesInRound; i++)
            {
                enemies[i]= Instantiate(enemyPrefab);
            }
        }
    }
}
