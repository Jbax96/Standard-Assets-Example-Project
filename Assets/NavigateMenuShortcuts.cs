using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateMenuShortcuts : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("1"))
        {
            SceneManager.LoadScene("First Person Maze");
        }
		if (Input.GetKeyUp ("2")) {
			SceneManager.LoadScene ("newThirdPerson");
		}
		if (Input.GetKeyUp ("3")) {
			SceneManager.LoadScene ("Racer");
		}
    }
}
