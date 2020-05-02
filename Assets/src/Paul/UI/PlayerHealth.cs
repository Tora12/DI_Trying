using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerHealthandDamage playerHealth;
    public Slider slider;
    public Slider slider1;
    private float maxHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerHealth.max_health;
        slider.maxValue = maxHealth;
        slider.value = playerHealth.health;
        slider1.maxValue = maxHealth;
        slider1.value = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealth.health;
        slider1.value = playerHealth.health;
    }
}
