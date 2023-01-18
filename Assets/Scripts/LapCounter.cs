using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapCounter : MonoBehaviour
{
    [SerializeField]
    GameObject winner;
    [SerializeField]
    GameObject AI1;
    [SerializeField]
    GameObject AI2;
    [SerializeField]
    GameObject AI3;
    public int Lap;
    public Text LText;
    public bool canFinish = true;
    public bool canWin;

    [Header("playerNumber")]
    public float playernumber;
    public void AddLapP()
    {
        Lap++;
        LText.text = Lap.ToString();        
    }
    public void AddLapAI()
    {
        Lap++;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        //-----------------------------------------------1
        if (playernumber == 1)
        {
            if (other.gameObject.CompareTag("finich"))
            {
                if (canFinish == true)
                {
                    AddLapAI();                   
                    canFinish = false;
                    if (Lap > 2)
                    {
                        AI1.active = true;
                        canWin = true;
                        if(canWin == true)
                        {
                            AI2.active = false;
                            AI3.active = false;
                            winner.active = false;
                        }
                    }

                }
            }
            if (other.gameObject.CompareTag("boolTrue"))
            {
                canFinish = true;
            }
        }
        //-----------------------------------------------2
        if (playernumber == 2)
        {
            if (other.gameObject.CompareTag("finich"))
            {
                if (canFinish == true)
                {
                    AddLapAI();
                    canFinish = false;
                    if (Lap > 2)
                    {
                        AI2.active = true;
                        canWin = true;
                        if (canWin == true)
                        {
                            AI1.active = false;
                            AI3.active = false;
                            winner.active = false;
                        }
                    }
                }
            }
            if (other.gameObject.CompareTag("boolTrue"))
            {
                canFinish = true;
            }
        }
        //-----------------------------------------------3
        if (playernumber == 3)
        {
            if (other.gameObject.CompareTag("finich"))
            {
                if (canFinish == true)
                {
                    AddLapAI();
                    canFinish = false;
                    if (Lap > 2)
                    {
                        AI3.active = true;
                        canWin = true;
                        if (canWin == true)
                        {
                            AI2.active = false;
                            AI1.active = false;
                            winner.active = false;
                        }
                    }
                }
            }
            if (other.gameObject.CompareTag("boolTrue"))
            {
                canFinish = true;
            }
        }
        //-----------------------------------------------4
        if (playernumber == 4)
        {
            if (other.gameObject.CompareTag("finich"))
            {
                if (canFinish == true)
                {
                    AddLapP();
                    canFinish = false;
                    if (Lap > 2)
                    {
                        winner.active = true;
                        canWin = true;
                        if (canWin == true)
                        {
                            AI2.active = false;
                            AI3.active = false;
                            AI1.active = false;
                        }
                    }
                }
            }
            if (other.gameObject.CompareTag("boolTrue"))
            {
                canFinish = true;
            }
        }
    }
}
