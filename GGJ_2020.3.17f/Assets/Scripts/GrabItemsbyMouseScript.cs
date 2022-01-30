using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemsbyMouseScript : MonoBehaviour
{

    bool IsGrabbing = false;
    public Camera Cam;
    public float LiftOffObject = -1;
    Vector3 mousePos;
    Collider2D targetCol;

    // Update is called once per frame
    void Update()
    {
        mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            IsGrabbing = true;
            targetCol = Physics2D.OverlapPoint(mousePos);

        }

        if (IsGrabbing && targetCol)
        {
            
            mousePos.z = targetCol.transform.position.z;
            //mousePos.z = LiftOffObject;
            targetCol.transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0)&& targetCol)
        {
            
            IsGrabbing = false;
            targetCol.transform.position = new Vector3(targetCol.transform.position.x, targetCol.transform.position.y, 0);
            
            targetCol = null;
        }
    }


}
