using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tanyakcount : MonoBehaviour
{
    public Text Tanyak;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tanyak.GetComponent<Text>().text = Player.Tangchag + " " + "/ 30";
    }
}
