using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        IDamageable damage = collision.gameObject.GetComponent<IDamageable>();
        if (damage != null)
        {
            damage.TakeDamage(BulletService.Instance.bulletScriptableObject.damage);
        }
        Destroy(gameObject);
    }
}
