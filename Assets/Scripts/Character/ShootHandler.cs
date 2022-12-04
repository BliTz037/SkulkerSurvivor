using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform BulletSpawnPoint;

    public Transform CharacterPosition;

    public float BulletSpeed = 30f;

    public float FireRate = 0.5f;

    public float BulletDamage = 1f;

    private float _nextFire = 0f;


    public void Shoot()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + FireRate;

            var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, CharacterPosition.rotation);

            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * BulletSpeed, ForceMode.Impulse);

            Destroy(bullet, 4.0f);
        }
    }

    
}