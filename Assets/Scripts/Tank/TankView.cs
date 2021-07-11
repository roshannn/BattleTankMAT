using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour, IDamageable
{
    //references
    private TankController tankController;
    public Rigidbody rigidbody;
    //movementParameters
    private float rotation;
    private float movement;

    //Health bar
    [SerializeField]private Slider healthSlider;

    //Firing bullet
    public Transform fireTransform;
    public float canFire = 0f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        healthSlider.maxValue = tankController.tankModel.health;

    }

    public void GetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canFire < Time.time)
        {
            canFire = tankController.tankModel.fireRate + Time.time;
            tankController.Fire();
        }
    }

    private void GetInput()
    {
        movement = Input.GetAxis("Vertical1");
        rotation = Input.GetAxis("Horizontal1");
    }

    private void Move()
    {
       
        if (movement != 0)
        {
            tankController.Move(movement);
        }
    }
    private void Turn()
    {
        
        if (rotation != 0)
        {
            tankController.Turn(rotation);
        }
    }

    public void TakeDamage(float damage)
    {
        tankController.TakeDamage(damage);
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }


}
