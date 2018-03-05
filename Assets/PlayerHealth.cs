﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
