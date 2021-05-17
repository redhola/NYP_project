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

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

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

        if (turret != null)
        {
            buildManager.SelectNode(this);

            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough gold to build that!");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        Debug.Log("Turret build! ");

    }

    public void UpgradeTurret()//Build turret kısmındaki scripti alıp, prefab, blueprint'i ve işlemi onaylamak için bool cebri koyuyoruz. 
    {                          //Son olarak da gelişkin kule geldiği için diğerini destroy komutu ile yok ediyoruz

        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough gold to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;

        Debug.Log("Turret upgraded! ");

    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        Destroy(turret);
        turretBlueprint = null;
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