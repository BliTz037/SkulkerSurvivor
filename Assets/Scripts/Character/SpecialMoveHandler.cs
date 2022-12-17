using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMoveHandler : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform BulletSpawnPoint;

    public Transform CharacterPosition;

    public float BulletSpeed = 30f;
    private float _nextAttackTime;

    private PlayerStats _stats;

    public void Awake()
    {
        _stats = GetComponent<PlayerStats>();
    }

    public void Update()
    {
        if (StateManager.Instance().CurrentState != State.Game)
        {
            return;
        }

        if (Time.time > _nextAttackTime)
        {
            _nextAttackTime = Time.time + _stats.FireRate * 3;

            if (_stats.SpecialAttack > 0)
                SpecialShoot(_stats.SpecialAttack);
        }
    }

    private void SpecialShoot(int nbBullet)
    {
        float angleStep = 360 / nbBullet;
        float angle = 0f;


        for (int i = 0; i < nbBullet; i++)
        {
            float projectileDirXPosition = BulletSpawnPoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1f;
            float projectileDirZPosition = BulletSpawnPoint.position.z + Mathf.Cos((angle * Mathf.PI) / 180) * 1f;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, BulletSpawnPoint.position.y, projectileDirZPosition);
            Vector3 projectileMoveDirection = (projectileVector - BulletSpawnPoint.position).normalized * BulletSpeed;

            var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.z);

            angle += angleStep;

            Destroy(bullet, 4.0f);
        }
    }
}
