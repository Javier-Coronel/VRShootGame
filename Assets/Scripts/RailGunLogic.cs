using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGunLogic : GunLogic
{
    public float timeBetweenBullets = 1f;
    float timer = 0;
    public float loading = 0;
    public float bulletTime=0.5f;

    // Update is called once per frame
    void Update()
    {
        if(shooting){
            timer+=Time.deltaTime;
            loading = timer / timeBetweenBullets;
        }
    }
    public override void EndingShooting()
    {
        base.EndingShooting();
        if(timer >= timeBetweenBullets){
            GenerateBullet();
            
        }
        timer=0;
    }
    public override void GenerateBullet()
    {
        StartCoroutine(EnableBullet());
    }
    IEnumerator EnableBullet(){
        bullet.enabled = true;
        bullet.damage = damage;
        yield return new WaitForSeconds(bulletTime);
        bullet.enabled = false;
    }
}
