using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawnenemy", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawnenemy()
    {
        int pox = Random.Range(0, 251);
        int poz = Random.Range(0, 251);
        int Ge = Random.Range(0, 5);
        if (Ge == 0)
        {
            Instantiate(Enemy, new Vector3(pox, 1, 0), Quaternion.identity);
        }
        if (Ge == 1)
        {
            Instantiate(Enemy, new Vector3(0, 1, poz), Quaternion.identity);
        }
        if (Ge == 2)
        {
            Instantiate(Enemy, new Vector3(250, 1, poz), Quaternion.identity);
        }
        if (Ge == 3)
        {
            Instantiate(Enemy, new Vector3(pox, 1, 250), Quaternion.identity);
        }
    }
}
