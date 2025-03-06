using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ControllerLogic : MonoBehaviour
{
    public GunController[] controllers;
    private OVRInput.Controller controller;
    public Hands hand;
    
    // Start is called before the first frame update
    void Start()
    {
        if((int)hand!=(int)controller)controller=(OVRInput.Controller)(int)hand;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,controller)){
            checkAllAs(true);
        }
        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger,controller)){
            checkAllAs(false);
        }

    }
    void checkAllAs(bool state){
        foreach (var gun in controllers)
        {
            gun.stateOfTrigger=state;
            gun.checker=true;
        }
    }
    public void DeleteAllGuns()
    {
        foreach (var gun in controllers)
        {
            gun.DestroyGun();
        }
    }
}

public enum Hands {Izquierda=1,Derecha=2};
