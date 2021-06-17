using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint StandartTurret;
    public TurretBlueprint AnotherTurret;
    public TurretBlueprint LaserTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Standart turret selected");
        buildManager.SelectTurretToBuild(StandartTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("Another turret selected");
        buildManager.SelectTurretToBuild(AnotherTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("Laser turret selected");
        buildManager.SelectTurretToBuild(LaserTurret);
    }
}

