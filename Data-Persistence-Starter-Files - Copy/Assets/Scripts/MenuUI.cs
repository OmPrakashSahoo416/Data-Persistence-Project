using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
   public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void GoBackButton()
    {
        SceneManager.LoadScene(0);
    }
}
