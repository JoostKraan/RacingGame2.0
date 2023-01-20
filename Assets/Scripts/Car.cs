using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Car : MonoBehaviour
{
    public Transform centerOfMass;
    public float motorTorque = 500f;
    public float maxSteer = 20f;
    public float brakeTorque = 100f;
    public float currentspeed;

    public float BrakeForce;

    public float steer { get; set; }
    public float throttle { get; set; }
    private Rigidbody _rigidbody;
    private Wheel[] wheels;

    [SerializeField] private LapTimer finish;    

    [Header("Level Variables")]
    public GameObject[] checkPoints;
    public GameObject currentCheckPoint;
    public int checkPointCounter = 0;
    


    void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }
    public void ChangeSpeed(float throttle)
    {
        foreach (var wheel in wheels)
        {
            
            wheel.Torque = throttle * motorTorque;
        }
    }
    public void Turn(float steer)
    {
        foreach (var wheel in wheels)
        {
            wheel.Steerangle = steer * maxSteer;
        }
    }
    public void activatebrake(float brake)
    {
        foreach (var wheel in wheels)
        {
            wheel.brakeForce = 10000f;
        }         
    }
    public void disablebrake(float brake)
    {
        foreach (var wheel in wheels)
        {
            wheel.brakeForce = 0f;
        }
    }

    void Update()
    {
        //steer = Gamemaneger.Instance.Inputcontroller.SteerInput;
        //throttle = Gamemaneger.Instance.Inputcontroller.Throttleinput;
        //foreach (var wheel in wheels)
        //{
            //wheel.Steerangle = steer * maxSteer;
            //wheel.Torque = throttle * motorTorque;
        //}
        StartCoroutine(CalculateSpeed());
    }
    IEnumerator CalculateSpeed()
    {
        Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        currentspeed = (lastPosition - transform.position).magnitude / Time.deltaTime;
    }
    
    public GameObject NextCheckpoint()
    {
        checkPointCounter++;
        print(checkPointCounter);
        if (checkPointCounter > checkPoints.Length - 1)
        {
            LapTimer lapTimer = FindObjectOfType<LapTimer>();
            lapTimer.CanFinishOn();
            checkPointCounter = 0;
        }
        currentCheckPoint = checkPoints[checkPointCounter];
        return currentCheckPoint;
    }    
}