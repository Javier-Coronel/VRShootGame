using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleLogic : GunLogic
{
    float timeBetweenBullets = 0.25f;
    float timer = 0;
    float damage=1;

    // Update is called once per frame
    void Update()
    {
        if(shooting){
            timer+=Time.deltaTime;
            if(timer >= timeBetweenBullets){
                Instantiate(bullet,transform.position, Quaternion.identity);
                timer=0;
            }
        }
    }
    public override void StartingShooting(){
        base.StartingShooting();
    }
    public override void EndingShooting(){
        base.EndingShooting();
    }
}
