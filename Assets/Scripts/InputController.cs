using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string InputsteerAxis = "Horizontal";
    public string InputthrottleAxis = "Vertical";

    Car car;
    Rigidbody rb;
    public float Throttleinput { get; private set; }
    public float SteerInput { get; private set; }

    public float Forwards;
    public float Steering;
    public float braking;
    void Awake()
    {
        car = GetComponent<Car>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Forwards = Input.GetAxis("Vertical");
        Steering = Input.GetAxis("Horizontal");

        car.ChangeSpeed(Forwards);
        car.Turn(Steering);        
        if(Input.GetKey(KeyCode.Space))
        {
            car.activatebrake(braking);
            //rb.drag = 0.15f;
        }
        else
        {
            //rb.drag = 0.5f;
            car.disablebrake(braking);
        }
    }
}