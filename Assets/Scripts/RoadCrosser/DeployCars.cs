using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCars : MonoBehaviour {
    public GameObject CarRight;
    public GameObject CarLeft;
    int lastLeft = -1;
    int lastRight = -1;
    public float[] posRight = {3.4f, 8.5f, 13.4f, 18.5f, -1.5f, -6.5f, -11.5f, -16.6f}; //right lane pos
    public float[] posLeft = {-18.8f, -13.8f, -8.8f, -3.8f, 1.2f, 6.2f, 11.2f, 16.2f}; //left lane pos

    void Start ()
    {
        //start cars spawning
        StartCoroutine(carWave());
    }

    private void spawnCar()
    {
        var randomIndexRight = Random.Range(0, posRight.Length); //pick random lane
        var randomIndexLeft = Random.Range(0, posLeft.Length); //pick random lane
        if(randomIndexRight == lastRight || randomIndexLeft == lastLeft){ //if same as last lane
          spawnCar(); //try again
          return;
        }
        GameObject right = Instantiate(CarRight) as GameObject; //create right car
        GameObject left = Instantiate(CarLeft) as GameObject; //create left car
        lastLeft = randomIndexLeft; //last left lane index
        lastRight = randomIndexRight; //last right lane index
        right.transform.position = new Vector2(39f, posRight[randomIndexRight]); //place car on lane
        left.transform.position = new Vector2(-39f, posLeft[randomIndexLeft]); //place car on lane
    }

    IEnumerator carWave()
    {
        while(true){
            yield return new WaitForSeconds(1f);
            spawnCar();
        }
    }
}
