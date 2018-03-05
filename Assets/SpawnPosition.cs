using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnPosition : MonoBehaviour {
    private Vector3 spawn;
    private Vector3 newSpawn;
    public int lives;
    public GameObject player;
    public Text nOfLives;   
    private int spawnCounter;

    void Start()
    {
    }
    void OnCollisionEnter(Collision hit)
    {
        //Collide with Checkpoint
        if(hit.gameObject.tag == "Checkpoint")
        {
            newSpawn = new Vector3(hit.transform.position.x, hit.transform.position.y + 2, hit.transform.position.z);

  
            if (spawnCounter > 0)
            {
                if (lives != 3 && spawn != newSpawn)
                {
                    lives++;
                    spawn = newSpawn;
                    spawnCounter++;
                }
                
            }
            else
            {
                spawn = newSpawn;
                spawnCounter++;
            }
        }
        //Fall out of bounds
        if(hit.gameObject.tag == "Death")
        {
            if (lives > 0)
            {
                player.transform.position = spawn;
                lives--;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        nOfLives.text = "Lives: " + lives;
    }
    private void Update()
    {
        //Respawn
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (lives > 0)
            {
                player.transform.position = spawn;
                lives--;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        nOfLives.text = "Lives: " + lives;

    }
}
