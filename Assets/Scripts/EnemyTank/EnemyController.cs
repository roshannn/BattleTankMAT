
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    public EnemyModel enemyModel;
    public EnemyView enemyView;

    public enum States
    {
        none,patrolling,following,attacking
    }
    public States currentState;

    private float timer;
    private float canFire = 0f;



    public EnemyController(EnemyModel model, EnemyView enemyPrefab)
    {
        enemyModel = model;
        enemyView = GameObject.Instantiate<EnemyView>(enemyPrefab, GetRandomPosition(), Quaternion.identity);
        enemyModel.GetEnemyController(this);
        enemyView.GetEnemyController(this);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randDir = Random.insideUnitSphere * enemyModel.patrollingRadius;
        randDir += EnemyService.Instance.enemyView.transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, enemyModel.patrollingRadius, NavMesh.AllAreas);
        return navHit.position;
    }
    public void Movement()
    {
        if (!enemyView.playerDetected)
        {
            Patrol();
        }
        else
        {
            Follow();
        }
    }

    private void Patrol()
    {
        currentState = States.patrolling;
        timer += Time.deltaTime;
        if (timer > enemyModel.patrolTime)
        {
            SetPatrolingDestination();
            timer = 0;
        }
    }

    private void SetPatrolingDestination()
    {
        Vector3 newDestination = GetRandomPosition();
        enemyView.agent.SetDestination(newDestination);
    }


    private void Follow()
    {
        currentState = States.following;
        enemyView.agent.SetDestination(TankService.Instance.playerTransform.position);
    }

    public void Attack()
    {
        if (enemyModel.attackDistance <= Vector3.Distance(enemyView.transform.position, TankService.Instance.playerTransform.position))
        {
            currentState = States.attacking;
            if (canFire < Time.time)
            {
                canFire = enemyModel.fireRate + Time.time;
                BulletService.Instance.Fire(enemyView.fireTransform, EnemyService.Instance.enemyScriptableObject.bulletView);
            }
        }
    }


    public void TakeDamage(float damage)
    {
        enemyModel.health -= damage;
        if(enemyModel.health <= 0)
        {
            enemyView.DestroyEnemy();
        }
    }




}
