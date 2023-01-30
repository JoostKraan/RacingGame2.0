using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Track1()
    {
        SceneManager.LoadScene(2);
    }
    public void Track2()
    {
        SceneManager.LoadScene(3);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
}
