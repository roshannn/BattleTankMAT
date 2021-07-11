using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour, IDamageable
{
    //refs
    private EnemyController enemyController;

    public NavMeshAgent agent;

    public Transform fireTransform;

    public bool playerDetected;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("EnemyInstanstiated");
    }

    // Update is called once per frame
    void Update()
    {
        enemyController.Movement();
        enemyController.Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TankView>() != null)
        {
            playerDetected = true;
        }
    }


    public void GetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    public void TakeDamage(float damage)
    {
        enemyController.TakeDamage(damage);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
