using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityToStop : MonoBehaviour
{
    [Tooltip("The proximal GameObject that affects the animator.")]
    public GameObject affector;

    [Tooltip("The maximum distance that affects the animator.")]
    public float maxDistance = 1.0f;

    private Vector3 affectorPosition;
    private Vector3 robotPosition;

    void Start()
    {
        affectorPosition = affector.transform.position;
        robotPosition = gameObject.transform.position;
    }

    void Update()
    {
        affectorPosition = affector.transform.position;
        float currentDistance = Vector3.Distance(affectorPosition, robotPosition);

        if (currentDistance < maxDistance)
        {
            gameObject.GetComponent<ForwardKinematics>().animate = true;
        }
        else
        {
            gameObject.GetComponent<ForwardKinematics>().animate = false;
        }
    }
}
