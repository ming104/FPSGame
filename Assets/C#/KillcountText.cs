using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillcountText : MonoBehaviour
{
    public Text Kill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Kill.GetComponent<Text>().text = Player.Killcount + "kills";
    }
}
