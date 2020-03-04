using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private int ammo = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1) && ammo > 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //Shooting Logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ammo -= 1;
        //Debug.Log(ammo);
    }
}
