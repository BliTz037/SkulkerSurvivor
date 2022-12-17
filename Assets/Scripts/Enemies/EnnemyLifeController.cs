using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyLifeController : MonoBehaviour
{
    public float Health = 1.0f;
    
    private XpDropper _xpDropper;

    public void Awake()
    {
        _xpDropper = FindObjectOfType<XpDropper>();
    }
    
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
        _xpDropper.DropXp(gameObject.transform.position);
    }
}
