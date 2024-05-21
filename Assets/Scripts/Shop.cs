using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    
    
    
    public void purchaseStandardTurret()
    {
        Debug.Log("Standard turret selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }
    
    public void purchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher selected");
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
    
}
