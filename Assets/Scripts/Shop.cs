using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret; 
    public TurretBlueprint missileLauncher; 
    private BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    
    
    
    public void selectStandardTurret()
    {
        Debug.Log("Standard turret selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    
    public void selectMissileLauncher()
    {
        Debug.Log("Missile Launcher selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    
}