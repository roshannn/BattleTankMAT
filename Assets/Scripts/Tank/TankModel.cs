using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;
    public float health { get; set;}
    public float turnSpeed { get; private set; }
    public float movementSpeed { get; private set; }

    public float fireRate { get; private set; }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        fireRate = tankScriptableObject.fireRate;
        movementSpeed = tankScriptableObject.movementSpeed;
        turnSpeed = tankScriptableObject.turnSpeed;
        health = tankScriptableObject.health;
    }

    public void GetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

}
