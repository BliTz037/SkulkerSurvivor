using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform BulletSpawnPoint;

    public Transform CharacterPosition;

    public AudioClip ShootSound;

    public float BulletSpeed = 30f;

    private float _nextFire = 0f;

    private PlayerStats _stats;

    public void Awake()
    {
        _stats = GetComponent<PlayerStats>();
    }
    public void Shoot()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _stats.FireRate;
            SoundManager.Instance.PlaySound(ShootSound);

            var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, CharacterPosition.rotation);

            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * BulletSpeed, ForceMode.Impulse);
            bullet.GetComponent<CharacterBullet>().Damage = _stats.Damage;

            Destroy(bullet, 4.0f);
        }
    }


}