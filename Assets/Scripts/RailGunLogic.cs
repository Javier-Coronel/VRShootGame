using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGunLogic : GunLogic
{
    public float timeBetweenBullets = 5f;
    float timer = 0;
    public float loading = 0;
    public Transform loadingShow;
    public float bulletTime=5f;
    private void Start()
    {
        bullet.damage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(shooting&& !bullet.isActiveAndEnabled)
        {
            timer+=Time.deltaTime;
            loading = timer/timeBetweenBullets;
            if (loading >= 1) loading = 1;
            if (loadingShow) loadingShow.localScale= new Vector3(loadingShow.localScale.x, loading, loadingShow.localScale.z);

        }
    }
    public override void EndingShooting()
    {
        base.EndingShooting();
        if(loading >= 1)
        {
            GenerateBullet();
        }
        timer=0;
        loading = 0;
        if (loadingShow) loadingShow.localScale = new Vector3(loadingShow.localScale.x, loading, loadingShow.localScale.z);
    }
    public override void GenerateBullet()
    {
        StartCoroutine(EnableBullet());
    }
    IEnumerator EnableBullet(){
        bullet.gameObject.SetActive(true);
        yield return new WaitForSeconds(bulletTime);
        bullet.gameObject.SetActive(false);
    }
}
