using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public float damage = 1;
    public float velocity = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*velocity);
        Debug.Log(transform.forward);
        if(damage<=0 || Mathf.Abs(transform.position.x)>60 || Mathf.Abs(transform.position.y) > 60 || Mathf.Abs(transform.position.z) > 60)
        {
            Destroy(gameObject);
        }
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
