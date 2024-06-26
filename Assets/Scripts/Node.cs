using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update

    public Color hoverColor;
    private Renderer rend;
    private Color startColor;
    public Vector3 offSet;

    private GameObject turret; 
    

    private void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + offSet, transform.rotation); 
        

    }


    private void OnMouseEnter()
    {
        rend.material.color = hoverColor; 
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor; 
    }
}
