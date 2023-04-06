using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    int speedBullet;
    private void OnEnable()
    {
         Base.onDetection += Shoot;
    }


    private void Shoot(Vector3 playerPos)
    {
        GameObject bullet1 = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet1.GetComponent<Rigidbody>().AddForce((playerPos - transform.position) * speedBullet, ForceMode.Impulse);
    }

}
