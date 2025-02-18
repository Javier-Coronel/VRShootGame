using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToShootGunLogic : GunLogic
{
    public override void StartingShooting(){
        GenerateBullet();
    }
    public override void EndingShooting(){ }
}
