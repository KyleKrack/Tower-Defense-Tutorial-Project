using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    private bool doMovement = true;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f; 
    
    private void Update()
    {
        //Debug.Log("camera controller update");

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement; 
        
        if (!doMovement)
            return; 
        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) 
        {
           
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime), Space.World);
        }
        
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) 
        {
            transform.Translate(Vector3.back * (panSpeed * Time.deltaTime), Space.World);
        }
        
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) 
        {
            transform.Translate(Vector3.right * (panSpeed * Time.deltaTime), Space.World);
        }
        
        if (Input.GetKey("a") || Input.mousePosition.x <=  panBorderThickness) 
        {
            transform.Translate(Vector3.left * (panSpeed * Time.deltaTime), Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(scroll);

        Vector3 pos = transform.position;

        pos.y -= scroll * scrollSpeed * Time.deltaTime * 1000;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        transform.position = pos;

        
    }
    
}