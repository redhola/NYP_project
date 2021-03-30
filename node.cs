using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour{

    public Color hovercolor;

    public GameObject turret;

    private SpriteRenderer rend;

    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance; //kýsaltma yapmak için
           
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //Mouse'un önünde bir ui elemaný olup olmadýðýný kontrol ediyoruz ki istenmeyen týklamalar oluþmasýn.
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

        if (turret != null)
        {
            Debug.Log("You can't build there");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //Mouse'un önünde bir ui elemaný olup olmadýðýný kontrol ediyoruz ki istenmeyen týklamalar oluþmasýn.
            return;

        if (buildManager.GetTurretToBuild() == null) //Bunu koyduðumuz için kullanýcý sadece koymak üzere bir kule seçtiði zaman mouse'ýn durduðu alan belli edilecek. Aksi takdirde farklýlaþmasýna raðmen týklandýðýnda bir kule koyulamazdý.
            return;

        rend.material.color = hovercolor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
