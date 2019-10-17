using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePrefabs : MonoBehaviour {

    public Transform prefab;

    List<Transform> prefabs;

    public int numberOfPrefabs;
	// Use this for initialization
	void Start () {
        float increment = 2f * Mathf.PI / numberOfPrefabs;
        for (int i = 0; i <numberOfPrefabs; i++)
        {
            float theta = i * increment;
            Vector3 localPosition = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0f);
            Transform pf = Instantiate(prefab, localPosition, Quaternion.identity);
            if (i % 2 == 0)
            {
                pf.GetComponent<MoveWithController>().movementspeed = 2f;
            }
            Vector3 colour;
            if (i% 3 == 0)
            { 
                colour = new Vector3(1f, 0f, 0.5f); //colour needs to be between 0 and 1
            }
            else { colour = new Vector3(0f, 1f, 0.5f); }

            setColour(colour, pf); //pf passed by reference

            prefabs.Add(pf);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setColour(Vector3 cols, Transform point)
    {
        Renderer rend = point.GetComponent<Renderer>();
        rend.material.SetVector("_Color", cols);
    }
}
