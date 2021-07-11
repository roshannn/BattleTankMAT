using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;
    public CameraFollow cameraFollow;
    public TankScriptableObject tankScriptableObject;
    public TankController controller;
    public Transform playerTransform;

    private void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel model = new TankModel(tankScriptableObject);
        controller = new TankController(model, tankView);
        cameraFollow.SetTarget(controller.tankView.transform);
    }

    private void Update()
    {
        playerTransform = controller.tankView.transform;
    }
}
