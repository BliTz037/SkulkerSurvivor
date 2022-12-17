using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Speed = 10;
    public float MaxHp = 5;
    public float Hp = 5;
    public float Damage = 1;
    public int SpecialAttack = 0;
    public float FireRate = 0.5f;

    public void Reset()
    {
        Speed = 10;
        MaxHp = 5;
        Hp = 5;
        Damage = 1;
        SpecialAttack = 0;
        FireRate = 0.5f;
    }
}
