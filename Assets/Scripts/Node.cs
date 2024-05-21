using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems; 
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update

    public Color hoverColor;
    private Renderer rend;
    private Color startColor;
    public Vector3 offSet;

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
        rend.material.color = hoverColor; 
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }
}
