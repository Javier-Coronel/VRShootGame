using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContinuousGunLogic : GunLogic
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
}
