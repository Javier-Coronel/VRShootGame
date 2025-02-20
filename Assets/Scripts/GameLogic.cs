using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    int round = 0;
    float life = 10;
    public GameObject enemyPrefab;
    public List<GameObject> enemies;
    

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
        if (life <= 0)
        {
            round = 0;
            foreach (var item in enemies)
            {
                if (item) Destroy(item);
                enemies.Remove(item);
            }
        }
        if (enemies.Count == 0)
        {
            round++;
            int enemiesInRound = round * (int)Math.Floor(Math.E * 1.5);
            for (int i = 0; i < enemiesInRound; i++)
            {
                var a = UnityEngine.Random.Range(0, 50);
                Vector3 position = (UnityEngine.Random.value>=0.5) ? new Vector3(a,0.25f,50) : new Vector3(50,0.25f,a);
                enemies.Add(Instantiate(enemyPrefab,position,Quaternion.FromToRotation(position,transform.position)));
            }
        }
    }
}
