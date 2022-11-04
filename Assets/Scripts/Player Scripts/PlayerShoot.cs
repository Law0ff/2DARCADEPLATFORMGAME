using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireBullet;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            ShootBullet();
    }
    void ShootBullet()
    {

            FireBullet bullet = Instantiate(fireBullet, transform.position, Quaternion.identity).GetComponent<FireBullet>();
            bullet.Speed *= transform.localScale.x;
    }
}
