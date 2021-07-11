using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoSingletonGeneric<BulletService>
{
    public BulletScriptableObject bulletScriptableObject;
    
    public void Fire(Transform fireTransform,BulletView bulletView)
    {
        BulletView bullet = GameObject.Instantiate<BulletView>(bulletView,fireTransform.position, fireTransform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bulletScriptableObject.speed * fireTransform.forward;
    }
}
