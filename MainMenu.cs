using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
   public void PlayButton()
    {

        SceneManager.LoadScene("Select_Level");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackMenu()
    {

        SceneManager.LoadScene("Main menu");
    }

}
