using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoSingletonGeneric<EnemyService>
{
    public EnemyView enemyView;
    public EnemyScriptableObject enemyScriptableObject;
    private void Update()
    {
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("0 registered");
            EnemyModel model = new EnemyModel(enemyScriptableObject);
            EnemyController enemyController = new EnemyController(model, enemyView);
            
        }
    }

    
}
