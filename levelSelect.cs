using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelSelect : MonoBehaviour
{
    public void level01()
    {

        SceneManager.LoadScene("Level01");

    }
    public void level02()
    {

        SceneManager.LoadScene("Level02");

    }

    public void level03()
    {

        SceneManager.LoadScene("Level03");

    }


}