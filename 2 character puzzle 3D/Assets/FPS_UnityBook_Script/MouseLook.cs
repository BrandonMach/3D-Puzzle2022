using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotateAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    };

    public RotateAxes axes = RotateAxes.MouseXAndY;

    public float sensetivityHor = 0.9f;
    public float sensetivityVert = 0.9f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float rotationX = 0; //Vertical angle


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(axes == RotateAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensetivityHor, 0); // rotatte around Y axes
        }
        else if(axes == RotateAxes.MouseY)
        {   //Rotate around X axes
            rotationX -= Input.GetAxis("Mouse Y") * sensetivityVert; // subtract up and down 
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
        else
        {
            //both horizontal and vertical rotation

            rotationX -= Input.GetAxis("Mouse Y") * sensetivityVert;
            rotationX = Mathf.Clamp(rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensetivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }


    }
}
