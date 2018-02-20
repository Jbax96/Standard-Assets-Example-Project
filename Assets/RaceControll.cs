using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceControll : MonoBehaviour {

    public Cars[] carCollection;
    public Cars[] carPosition;
    public Text position;
    public Cars playerCar;

    // Use this for initialization
    public void Start()
    {
        //set up the car objects
        carPosition = new Cars[carPosition.Length];
        InvokeRepeating("Update", 0.5f, 0.5f);
        position.text = "Race Position:";
    }

    // Update is called once per frame
    void Update()
    {
        string carPos = "";
        foreach (Cars car in carCollection)
        {
            carPosition[car.getCarPosition(carCollection) - 1] = car;
        }
        int playerPos = playerCar.getCarPosition(carCollection);
        carPos += playerPos;
        int playerLap = 0;
        playerLap = playerCar.getCarLap();
        position.text = "Position:" + carPos + " Lap:" + playerLap;
        
        if(playerLap == 3)
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
        
    }
}
