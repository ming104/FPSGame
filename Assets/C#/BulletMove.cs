using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        Destroy(gameObject, 10);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        { 

        }
    }
}
