using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheckpoints : MonoBehaviour
{
    Car car;
    void Start()
    {
        car = GetComponent<Car>();
    }
    private void Update()
    {
        car.checkPoints[car.checkPointCounter].GetComponent<MeshRenderer>().enabled = true;
        if (car.checkPointCounter == 0)
        {
            if (car.checkPoints[car.checkPoints.Length-1].GetComponent<MeshRenderer>().enabled == true)
            {
                car.checkPoints[car.checkPoints.Length - 1].GetComponent<MeshRenderer>().enabled = false;
            }
            //car.checkPoints.Length; 
            //car.checkPoints[car.checkPointCounter].GetComponent<MeshRenderer>().enabled = false;
            print("0");
        }
        else
        {
            car.checkPoints[car.checkPointCounter - 1].GetComponent<MeshRenderer>().enabled = false;
        }
 
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            car.NextCheckpoint();
        }
    }
}
