using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithController : MonoBehaviour {


	public float movementspeed = 1f;

void Update()
	{

		if (Input.GetKey(KeyCode.UpArrow))
		{
            transform.Translate(Vector3.up * movementspeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(Vector3.down * movementspeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
		}
        if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(new Vector3(0f,0f,-1f) * movementspeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0f, 0f, -1f) * movementspeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0f, 0f, -1f) * movementspeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.R))
		{
			transform.Rotate(new Vector3(0f, 0f, 10f) * Time.deltaTime);

			//quaternions
			//https://docs.unity3d.com/ScriptReference/Quaternion-operator_multiply.html

			//https://docs.unity3d.com/ScriptReference/Quaternion.html

			float angle = 50f * Time.deltaTime;
			transform.rotation *= Quaternion.AngleAxis(angle, Vector3.up);


		}


		
		

		// Key pressed down
		if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Key T pressed");
        }

        //key released
        if (Input.GetKeyUp(KeyCode.T))
        {
            Debug.Log("T released");
        }

    }
}
