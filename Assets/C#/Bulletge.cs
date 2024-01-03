using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletge : MonoBehaviour
{
    public Transform bulletpos;
    public GameObject Bullet;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, bulletpos.transform.position, bulletpos.transform.rotation);
        }
    }
}
