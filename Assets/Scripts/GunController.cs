using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GunLogic logic;
    public bool stateOfTrigger = false;
    public bool checker = true;
    

    // Update is called once per frame
    void Update()
    {
        if (logic) { 
            if(checker&&stateOfTrigger){
                logic.StartingShooting();
                checker=false;
            }else if(checker&&!stateOfTrigger){
                logic.EndingShooting();
                checker=false;
            }
        }
    }
    public void SetGun(){
        if (logic) 
        {
            Destroy(logic.gameObject);
        }
        GameObject logicToAdd = Instantiate(GameLogic.Instance.gunsPrefabs[GameLogic.Instance.randGun].gameObject,gameObject.transform);
        logic = logicToAdd.GetComponent<GunLogic>();
    }
    public void DestroyGun()
    {
        if (logic)
        {
            Destroy(logic.gameObject);
        }
    }
}
