using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;

        }
        instance = this;
    }

    public GameObject standartTurretPrefab;
    public GameObject anotherTurretPrefab;

    private TurretBlueprint turretToBuild;
    public node selectedNode;

    public NodeUI nodeUI;


    public bool CanBuild { get { return turretToBuild != null; } } //Shopa týklayýp týklamadýðýmýzý kontrol ediyoruz
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }//

 

    public void SelectNode (node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild (TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }
}

