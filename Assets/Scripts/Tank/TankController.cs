using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankModel tankModel;
    public TankView tankView;
    Rigidbody rb;
    public TankController(TankModel model,TankView tankPrefab)
    {
        tankModel = model;
        tankView = GameObject.Instantiate<TankView>(tankPrefab);
        rb = tankView.rigidbody;
        tankView.GetTankController(this);
        tankModel.GetTankController(this);
    }

    public void Move(float movement)
    {
        var pos = tankView.transform.forward * movement * tankModel.movementSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + pos);
    }

    public void Turn(float rotate)
    {
        float turn = rotate * tankModel.turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

    }

    public void Fire()
    {
        BulletService.Instance.Fire(tankView.fireTransform, TankService.Instance.tankScriptableObject.bullet);
    }

    public void TakeDamage(float damage)
    {
        tankModel.health -= damage;
        if (tankModel.health<= 0)
        {
            tankView.DestroyPlayer();
        }
    }

}   
