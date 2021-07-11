using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public EnemyController enemyController;
    public float health;
    public float turnSpeed { get; private set; }
    public float movementSpeed { get; private set; }

    public float patrollingRadius;

    public float patrolTime;

    public float fireRate;

    public float attackDistance;



    public EnemyModel(EnemyScriptableObject enemyScriptableObject)
    {
        health = enemyScriptableObject.health;
        turnSpeed = enemyScriptableObject.turnSpeed;
        movementSpeed = enemyScriptableObject.movementSpeed;
        patrollingRadius = enemyScriptableObject.patrollingRadius;
        patrolTime = enemyScriptableObject.patrolTime;
        fireRate = enemyScriptableObject.fireRate;
        attackDistance = enemyScriptableObject.attackDistance;
    }

    public void GetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
}
