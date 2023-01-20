using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class LapTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text currentLapText;
    [SerializeField] Car checkpoints;

    private float timerTime;
    private int currentLapCounter = 0;
    private bool timerOn;

    private bool canFinish = true;

    void Update()
    {
        if (timerOn)
        {
            timerTime += Time.deltaTime;
        }
        timerText.text = "Laptime: " + timerTime.ToString("0.000 ");
        currentLapText.text = "Current lap: " + currentLapCounter.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "start")
        {
            timerOn = true;
            if (canFinish)
            {
                timerTime = 0;
                currentLapCounter++;
                canFinish = false;
            }
        }
    }
    public void CanFinishOn()
    {
        canFinish = true;
    }
}