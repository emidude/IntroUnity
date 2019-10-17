using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingAClass : MonoBehaviour {

    AddingTestClss addingClss;
    float variable;

    AScriptAlreadyAttached instanceOfScriptAlreadyAttached;

    // Use this for initialization
    private void Start()
    {
        //addingClss = new AddingTestClss();
        addingClss = gameObject.AddComponent<AddingTestClss>();

        variable = GetComponent<AScriptAlreadyAttached>().storedVariable;

        instanceOfScriptAlreadyAttached = GetComponent<AScriptAlreadyAttached>();
    }

    // Update is called once per frame
    void Update () {
		//if (Input.GetMouseButtonDown(0)) //0 for left click, 1, right click, 2 middle button
        if (Input.GetKey(KeyCode.P))
        {
            addingClss.A = 5f;
            addingClss.B = 2f;

            Debug.Log("adding class " + addingClss.add());
        }

        if (Input.GetKey(KeyCode.V))
        {
            variable += 3f; //not passed by reference - does not update attached script
            Debug.Log("varible in other script " + GetComponent<AScriptAlreadyAttached>().storedVariable);

            instanceOfScriptAlreadyAttached.storedVariable += 5f;
            Debug.Log("varible in other script updated on the script " + GetComponent<AScriptAlreadyAttached>().storedVariable);

        }
    }
}
