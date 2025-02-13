using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public bool shooting = false;
    public BulletLogic bullet = null;
    public float damage = 1;
    public virtual void StartingShooting(){
        shooting=true;
    }
    public virtual void EndingShooting(){
        shooting=false;
    }
    public virtual void GenerateBullet()
    {
        BulletLogic actualBullet = Instantiate(bullet, transform.position, transform.rotation);
        actualBullet.damage = damage;
    }
}
