using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public float life = 1;
    public float maxValue = 10;
    // Start is called before the first frame update
    void Start()
    {
        life = Mathf.Pow(Random.Range(1, maxValue), 0.7f);
        transform.localScale = Vector3.one*(life+1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
