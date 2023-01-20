using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheckpoints : MonoBehaviour
{
    Car car;
    void Start()
    {
        car = GetComponent<Car>();
        car.checkPoints[car.checkPointCounter].GetComponent<MeshRenderer>().enabled = true;
    }
    private void Update()
    {
        foreach (var cp in car.checkPoints)
        {
            cp.SetActive(false);
        }
        car.checkPoints[car.checkPointCounter].SetActive(true);
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            car.NextCheckpoint();
        }
    }
}
