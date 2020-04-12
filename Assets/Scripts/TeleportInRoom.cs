using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportInRoom : MonoBehaviour
{
    Transform t;

    void Start()
    {
        t = GameObject.Find("[VRSimulator_CameraRig]").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tp()
    {
        t.position = new Vector3(-5f,0f,5f);
    }
}
