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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            car.NextCheckpoint();
        }
    }
}
