using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic Instance { get; private set; }
    int round = 0;
    public float maxLife = 10;
    public float life = 10;
    public GameObject enemyPrefab;
    public List<GameObject> enemies;
    public GameObject gunUI;
    public GunLogic[] gunsPrefabs;
    public int randGun = 0;
    private bool onRound = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        SetGunUI();
    }

    void FixedUpdate()
    {
        if (onRound)
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
                SetGunUI();
            }
        }
    }
    void SetGunUI()
    {
        onRound = false;
        gunUI.SetActive(true);
        randGun = UnityEngine.Random.Range(0, gunsPrefabs.Length - 1);
        gunUI.transform.GetChild(0).GetChild(randGun).gameObject.SetActive(true);

    }
    public void GetOnRound()
    {
        onRound = true;
        life = maxLife;
        int enemiesInRound = round * (int)Math.Floor(Math.E * 1.5);
        for (int i = 0; i < enemiesInRound; i++)
        {
            var a = UnityEngine.Random.Range(0, 50);
            Vector3 position = (UnityEngine.Random.value >= 0.5) ? new Vector3(a, 0.25f, 50) : new Vector3(50, 0.25f, a);
            enemies.Add(Instantiate(enemyPrefab, position, Quaternion.FromToRotation(position, transform.position)));
        }
    }
}
