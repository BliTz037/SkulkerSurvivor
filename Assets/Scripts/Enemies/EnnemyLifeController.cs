using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyLifeController : MonoBehaviour
{
    public float Health = 1.0f;
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            OnEnemyDeath();
        }
    }

    private void OnEnemyDeath()
    {
        Destroy(gameObject);
    }
}
