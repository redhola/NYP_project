using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn() //  interface'i sürekli döndürmeye yarayan bi şey
    {

        float t = 1f;
        while (t >= 0f)
        {

            t -= Time.deltaTime;
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0; // just skip to the next frame

        }
        // zamana göre t yi sıfırlayıp while'dan çıkıyo
          
      
           }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        
    }

}

