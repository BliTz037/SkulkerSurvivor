using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBullet : MonoBehaviour
{
    public float Damage = 1.0f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnnemyLifeController>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
