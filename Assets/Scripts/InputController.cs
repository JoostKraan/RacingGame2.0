using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public string InputsteerAxis = "Horizontal";
    public string InputthrottleAxis = "Vertical";

    Car car;
    public float Throttleinput { get; private set; }
    public float SteerInput { get; private set; }

    public float Forwards;
    public float Steering;
    public float braking;
    void Awake()
    {
        car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        //SteerInput = Input.GetAxis(InputsteerAxis);
        //Throttleinput = Input.GetAxis(InputthrottleAxis);
        Forwards = Input.GetAxis("Vertical");
        Steering = Input.GetAxis("Horizontal");

        car.ChangeSpeed(Forwards);
        car.Turn(Steering);        
        if(Input.GetKey(KeyCode.Space))
        {
            car.activatebrake(braking);
        }
        else
        {
            car.disablebrake(braking);
        }
    }
}