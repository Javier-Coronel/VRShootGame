using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGunBulletLogic : BulletLogic
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*velocity);
        Debug.Log(transform.forward);
        if(Mathf.Abs(transform.position.x)>60|| Mathf.Abs(transform.position.y) > 60 || Mathf.Abs(transform.position.z) > 60)
        {
            Destroy(gameObject);
        }
    }
    public override void OnCollisionEnter(Collision collision){ }
}
