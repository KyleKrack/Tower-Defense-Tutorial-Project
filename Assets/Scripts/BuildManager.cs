using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Buildmanager in scene!");
            return; 
        }
        instance = this; 
    }

    public GameObject standardTurretPrefab;

    public GameObject missileLauncherPrefab;
    
    private TurretBlueprint turretToBuild;

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("not enough money!");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret; 
        
        Debug.Log("Turret built! Money left: " + PlayerStats.money);
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    
    

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    
}
