using UnityEngine;

public class Recover : MonoBehaviour
{
    private CarController carController;
    private GameObject spawnObject;

    void Start()
    {
        carController = GetComponent<CarController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            int lastCheckpoint = carController.checkPointCounter - 1;
            if (lastCheckpoint < 0)
            {
                lastCheckpoint = carController.checkPoints.Length - 1;
            }
            spawnObject = carController.checkPoints[lastCheckpoint];
            transform.position = spawnObject.transform.position;
        }
    }
}
