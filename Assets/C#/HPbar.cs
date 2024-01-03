using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Slider hpbar;
    public float maxHp;
    public static float currenthp;
    public GameObject DiePanel;

    void Awake()
    {
        maxHp = 100;
        currenthp = 0;
        DiePanel.SetActive(false);
    }

    void Update()
    {
        hpbar.value = currenthp / maxHp;
        if(currenthp >= 100)
        {
            DiePanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
