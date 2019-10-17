using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour {

    void setCols(Vector3 cols, Transform point)
    {
        Renderer rend = point.GetComponent<Renderer>();
        rend.material.SetVector("_Color", cols);

    }
}
