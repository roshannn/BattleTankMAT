using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public BulletView bullet;


    public float health;

    public float fireRate;

    public float movementSpeed;

    public float turnSpeed;
}