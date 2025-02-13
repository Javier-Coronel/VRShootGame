using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    public bool shooting = false;
    public GameObject bullet;
    public virtual void StartingShooting(){
        shooting=true;
    }
    public virtual void EndingShooting(){
        shooting=false;
    }
}
