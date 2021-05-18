using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelSelect : MonoBehaviour
{

    public SceneFader fader;

    public void Select (string levelName)
    {

        fader.FadeTo(levelName);

    }
  


    public void level01()
    {

        SceneManager.LoadScene("Level01");

    }
    public void level02()
    {

        SceneManager.LoadScene("Level02");

    }
    


}
