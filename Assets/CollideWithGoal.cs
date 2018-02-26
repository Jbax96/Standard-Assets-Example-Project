using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithGoal : MonoBehaviour
{

    void OnCollisionEnter(Collision hit)
    {
        if(hit.transform.root.CompareTag("Player"))
        { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


