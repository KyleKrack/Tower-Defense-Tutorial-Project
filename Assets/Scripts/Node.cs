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

    [Header("Optional:")]
    public GameObject turret;
    
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
        if (!buildmanager.CanBuild)
        {
            return; 
        }
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return; 
        }
        
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: display on screen");
            return;
        }


        buildmanager.BuildTurretOn(this);
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
