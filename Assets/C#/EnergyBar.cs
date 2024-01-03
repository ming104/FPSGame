using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider Energybar;
    public float maxEnergy;
    public static float currentEnergy;

    void Awake()
    {
        maxEnergy = 100;
        currentEnergy = 0;
    }
    void Update()
    {
        Energybar.value = currentEnergy / maxEnergy;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentEnergy <= 100)
            {
                currentEnergy += 0.3f;
            }
        }
        if (Player.isRun == false)
        {
            if (currentEnergy > 0)
            {
                currentEnergy -= 0.7f;
            }
        }
    }
}
