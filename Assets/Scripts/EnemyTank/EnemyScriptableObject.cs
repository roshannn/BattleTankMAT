using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/EnemyTank/NewEnemyTankScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public float health;

    public float movementSpeed;

    public float turnSpeed;

    public float patrollingRadius;

    public float patrolTime;

    public float fireRate;

    public float attackDistance;

    public BulletView bulletView;

}
