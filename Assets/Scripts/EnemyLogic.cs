using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyLogic : MonoBehaviour
{
    public float life = 1;
    public float maxValue = 10;
    public float velocityMod=2;
    public Rigidbody ownRigidBody;
    
    void Start()
    {
        life = Mathf.Pow(Random.Range(1, maxValue), 0.7f);
        transform.localScale = Vector3.one*(life+1);
        transform.position += Vector3.up*(life+1)/2;
        transform.LookAt(new Vector3(0,transform.position.y,0));

    }

    float step = 0;
    void Update()
    {
        if (transform.position.x>60|| transform.position.z > 60)
        {
            Destroy(gameObject);
        }
        ownRigidBody.velocity = (Vector3.zero-transform.position).normalized*(maxValue-life+0.5f)/velocityMod;
        step+=Time.deltaTime;
        if(step>=0.25){
        transform.rotation = Quaternion.AngleAxis(180, Vector3.up)*transform.rotation;
            step=0;
        }
        if(life>maxValue)life=maxValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletLogic bullet = other.GetComponentInParent<BulletLogic>();
        if(bullet)
        {
            float tempLife = life-bullet.damage;
            float tempDamage = bullet.damage-life;
            life = tempLife;
            bullet.damage = tempDamage;
            if(life <= 0)
            {
                Destroy(gameObject);
            }
            return;
        }
        
        if (other.CompareTag("Player"))
        {
            GameLogic.Instance.life -=life/2f;
            Destroy(gameObject);
        }
    }
}
