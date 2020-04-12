using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerPlane : MonoBehaviour
{
    Transform t;
    Vector3 oP;

    void Start()
    {
        t = GameObject.Find("plane (Rdy)").GetComponent<Transform>();
        oP = new Vector3(t.localScale.x, t.localScale.y, t.localScale.z);
    }

    public void Tt()
    {
        t.localScale = new Vector3(1.25f, 1.25f, 1.25f);
    }
}
