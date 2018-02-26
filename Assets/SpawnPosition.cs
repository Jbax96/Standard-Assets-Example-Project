using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnPosition : MonoBehaviour {
    private Vector3 spawn;
    public int lives;
    public GameObject player;
    public Text nOfLives;


    void Start()
    {
    }
    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Checkpoint")
        {
            spawn = new Vector3(hit.transform.position.x, hit.transform.position.y + 2, hit.transform.position.z);
        }
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
