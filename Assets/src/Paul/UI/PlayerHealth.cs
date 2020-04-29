using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public PlayerController playerHealth;
    public Slider slider;
    public Slider slider1;
    private float maxHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = playerHealth.maxHealth;
        slider.maxValue = maxHealth;
        slider.value = playerHealth.currentHealth;
        slider1.maxValue = maxHealth;
        slider1.value = playerHealth.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealth.currentHealth;
        slider1.value = playerHealth.currentHealth;
    }
}
