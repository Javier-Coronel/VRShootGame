using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RifleLogic : GunLogic
{
    public float timeBetweenBullets = 0.25f;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(shooting){
            timer+=Time.deltaTime;
            if(timer >= timeBetweenBullets){
                GenerateBullet();
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
