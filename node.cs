using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour
{
    public Color hovercolor;
    public Vector3 possitionOffset;
    private SpriteRenderer rend;
    public Color notEnoughMoneyColor; //pop-up yazı çıkarmayı öğrenip onun yerine bunu koyacağız.

    private Color startColor;

    [Header ("Optional")]
    public GameObject turret;

    

    public float range = 7;

    BuildManager buildManager;

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance; //kısaltma yapmak için

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + possitionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //Mouse'un önünde bir ui elemanı olup olmadığını kontrol ediyoruz ki istenmeyen tıklamalar oluşmasın.
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("You can't build there");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //Mouse'un önünde bir ui elemanı olup olmadığını kontrol ediyoruz ki istenmeyen tıklamalar oluşmasın.
            return;

        if (buildManager.CanBuild) //Bunu koyduğumuz için kullanıcı sadece koymak üzere bir kule seçtiği zaman mouse'ın durduğu alan belli edilecek. Aksi takdirde farklılaşmasına rağmen tıklandığında bir kule koyulamazdı.
            return;

        if(buildManager.HasMoney)
        {
            rend.material.color = hovercolor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }


    void OnDrawGizmos(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range );
    }
}