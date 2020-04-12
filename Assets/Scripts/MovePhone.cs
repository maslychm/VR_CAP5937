using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhone : MonoBehaviour
{
    Transform t;
    void Start()
    {
        t = GameObject.Find("CellPhone (Rdy)").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mp()
    {
        t.localPosition = new Vector3(2.4f, -1.831076f,6.8f);
    }
}
