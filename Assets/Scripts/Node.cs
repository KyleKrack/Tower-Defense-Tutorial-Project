using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems; 
using UnityEngine;
using Random = System.Random;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update

    public Color hoverColor;
    private Renderer rend;
    private Color startColor;
    public Vector3 offSet;
    public Color notEnoughMoneyColor; 

    [HideInInspector]
    public GameObject turret;

    [HideInInspector] 
    public TurretBlueprint turretBlueprint;

    [HideInInspector] 
    public bool isUpgraded = false;
    
    
    private BuildManager buildmanager; 
    

    private void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildmanager = BuildManager.instance; 
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offSet; 
    }
    
    private void OnMouseDown()
    {
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; 
        }
        
        if (turret != null)
        {
            buildmanager.selectNode(this); 
            return;
        }

        if (!buildmanager.CanBuild)
        {
            return; 
        }
        
        BuildTurret(buildmanager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("not enough money!");
            return;
        }

        PlayerStats.money -= blueprint.cost;
        
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;
        
        GameObject effect = (GameObject)Instantiate(buildmanager.buildEffect, GetBuildPosition(), Quaternion.identity); 
        Destroy(effect, 5f);
        
        
        Debug.Log("Turret built! ");
    }


    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money to upgrade that!");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;
        
        //get rid of old
        Destroy(turret);
        
        //build new one
        
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildmanager.buildEffect, GetBuildPosition(), Quaternion.identity); 
        Destroy(effect, 5f);
        
        isUpgraded = true; 
        
        Debug.Log("Turret upgraded! ");
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; 
        }
        
        if (!buildmanager.CanBuild)
        {
            return; 
        }

        if (buildmanager.HasMoney)
        {
            rend.material.color = hoverColor; 
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
        
        
        
        
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }
}
