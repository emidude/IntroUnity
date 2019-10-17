using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kleinbottle : MonoBehaviour {
    public Transform pointPrefab;
    [Range(10, 100)]
    public int resolution = 10;

    Transform[] points;

    const float pi = Mathf.PI;
    float step;

    public EnumForFunctionNames function;

    static GraphFunction[] functions = {
        figure8, movingFigure8, nonIntersecting
    };

    void Awake()
    {
        step = 2f / resolution;
        Vector3 scale = Vector3.one * step * 2f;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        points = new Transform[resolution * resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    // Update is called once per frame
    void Update() {
        float t = Time.time;
        GraphFunction f = functions[(int)function];
        for (int i = 0, z = 0; z < resolution; z++)
        {
            float v = (z + 0.5f) * step - 1f;
            for (int x = 0; x < resolution; x++, i++)
            {
                float u = (x + 0.5f) * step - 1f;
                points[i].localPosition = f(u, v, t);
            }
        }
       
    }

    static Vector3 figure8(float u, float v, float t){
        Vector3 p;
        float r = 3;
        u *= pi;
        v *= pi;
        p.x = (r + Mathf.Cos(u/2f)*Mathf.Sin(v)-Mathf.Sin(u/2f)*Mathf.Sin(2*v))*Mathf.Cos(u);
        p.y = (r + Mathf.Cos(u / 2f) * Mathf.Sin(v) - Mathf.Sin(u / 2f) * Mathf.Sin(2 * v)) * Mathf.Sin(u);
        p.z = Mathf.Sin(u / 2f) * Mathf.Sin(v) + Mathf.Cos(u / 2f) * Mathf.Sin(2 * v);
        return p;
    }

    
    static Vector3 movingFigure8(float u, float v, float t)
    {
        Vector3 p;
        float r = 3;
        t /= 10f;
        u = pi * (u + t );
        v = pi *(v + t);
        p.x = (r + Mathf.Cos(u / 2f) * Mathf.Sin(v) - Mathf.Sin(u / 2f) * Mathf.Sin(2 * v)) * Mathf.Cos(u);
        p.y = (r + Mathf.Cos(u / 2f) * Mathf.Sin(v) - Mathf.Sin(u / 2f) * Mathf.Sin(2 * v)) * Mathf.Sin(u);
        p.z = Mathf.Sin(u / 2f) * Mathf.Sin(v) + Mathf.Cos(u / 2f) * Mathf.Sin(2 * v);
        return p;
    }

    static Vector3 nonIntersecting(float u, float v, float t)
    {
        Vector3 p;
        float r = 3;

        u = pi * v;
        v = pi * u;
        p.x = (r + Mathf.Cos(u / 2f) * Mathf.Sin(v) - Mathf.Sin(u / 2f) * Mathf.Sin(2 * v)) * Mathf.Cos(u);
        p.y = (r + Mathf.Cos(u / 2f) * Mathf.Sin(v) - Mathf.Sin(u / 2f) * Mathf.Sin(2 * v)) * Mathf.Sin(u);
        u = t;
        v = t;
        p.z = Mathf.Sin(u / 2f) * Mathf.Sin(v) + Mathf.Cos(u / 2f) * Mathf.Sin(2 * v);
       
        return p;
    }


}
