using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{

    float mouseZcoord;

    public Vector3 mousePreviousLocation;
    public Vector3 mouseCurLocation;
    // Use this for initialization
    void Awake()
    {

        mouseZcoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // GetComponent<Rigidbody>().velocity = Vector3.zero;
        // GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnMouseDown()
    {

        mousePreviousLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseZcoord);

    }


    public Vector3 force;
    // Update is called once per frame
    void OnMouseDrag()
    {

        mouseCurLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mouseZcoord);
        force = mouseCurLocation - mousePreviousLocation;//Changes the force to be applied
        mousePreviousLocation = mouseCurLocation;
        GetComponent<Rigidbody>().velocity = force;
    }


    void OnMouseUp()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

}
