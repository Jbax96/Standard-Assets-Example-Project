﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shootable : MonoBehaviour {

    public int currentHealth = 3;

    public void Damage(int damageAmount)

    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            if(gameObject.tag == "fire")
            {
               SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
