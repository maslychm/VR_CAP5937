using UnityEngine;

public class LightColorPress : MonoBehaviour
{
    Light lt;
    Color origColor;

    void Start()
    {
        Debug.Log("Changing Color");
        lt = GameObject.Find("Light oo").GetComponent<Light>();
        origColor = lt.color;
    }

    void Update()
    {
        //lt.color = Color.red;
    }

    public void Cc()
    {
        if (lt.color == Color.red)
            lt.color = origColor;
        else
            lt.color = Color.red;

    }
}