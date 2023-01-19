using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    [Header("Input Variables")]
    Car movement;
    
    Wheel wl;
    public float forwards;
    public float turn;
    public float braking;
    public float currentspeed;
    public bool canactivate;
    public float timeleft = 10f;

    [SerializeField]
    GameObject newlapbrake;


    [Header("Level Variables")]
    private Transform targetPositionTransform;

    void Awake()
    {
        movement = GetComponent<Car>();
        wl = GetComponent<Wheel>();
        targetPositionTransform = movement.checkPoints[0].transform;
    }

    void FixedUpdate()
    {
        
        Vector3 targetPosition = targetPositionTransform.position;
        float forwards = 0;
        float turn = 0;

        Vector3 directionToTarget = (targetPosition - transform.position);
        float dot = Vector3.Dot(transform.forward, directionToTarget);

        float distance = Vector3.Distance(transform.position, targetPosition);
        float minDistance = 10;

        if (distance > minDistance)
        {
            if (dot > 0)
            {
                forwards = 1;
            }
            else if (dot < 0)
            {
                forwards = -1;
            }


            float angle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);

            if (angle > 5)
            {
                turn = 1;
            }
            if (angle < -5)
            {
                turn = -1;
            }
        }        
        else
        {
            targetPositionTransform = movement.NextCheckpoint().transform;
        }

        if (currentspeed < 18)
        {
            movement.disablebrake(braking);
        }

        


        movement.ChangeSpeed(forwards);
        movement.Turn(turn);
        StartCoroutine(CalculateSpeed());
    }
    public void Update()
    {
        //timeleft = 10f;
        timeleft -= Time.deltaTime;
        if (timeleft < 1)
        {
            newlapbrake.active = true;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
       
    //    if (other.gameObject.CompareTag("brake"))
    //    {
    //        movement.activatebrake(braking);
    //        wl.brakeForce = 1000f;
    //    }
    //    else
    //    {
    //        movement.disablebrake(braking);
    //    }
    //}
    IEnumerator CalculateSpeed()
    {
        Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        currentspeed = (lastPosition - transform.position).magnitude / Time.deltaTime;
    }
}