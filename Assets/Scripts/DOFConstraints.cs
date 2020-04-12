using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOFConstraints : MonoBehaviour
{
    [Tooltip("Whether to constrain the position along the local X-axis.")]
    public bool PositionX;

    [Tooltip("Whether to constrain the position along the local Y-axis.")]
    public bool PositionY;

    [Tooltip("Whether to constrain the position along the local Z-axis.")]
    public bool PositionZ;

    [Tooltip("Whether to constrain the rotation around the local X-axis.")]
    public bool RotationX;

    [Tooltip("Whether to constrain the rotation around the local Y-axis.")]
    public bool RotationY;

    [Tooltip("Whether to constrain the rotation around the local Z-axis.")]
    public bool RotationZ;

    // Cache of the local position and rotation constraints.
    private Vector3 localPositionConstraints;
    private Vector3 localRotationConstraints;

    // Start is called before the first frame update
    void Start()
    {
        // Store the local positions and rotations as constraints.
        localPositionConstraints = transform.localPosition;
        localRotationConstraints = transform.localRotation.eulerAngles;
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        // Get the current local rotation.
        Vector3 localRotation = transform.localRotation.eulerAngles;

        // Check the X-axis.
        if (RotationX) { localRotation.x = localRotationConstraints.x; }
        else { localRotationConstraints.x = localRotation.x; }

        // Check the Y-axis.
        if (RotationY) { localRotation.y = localRotationConstraints.y; }
        else { localRotationConstraints.y = localRotation.y; }

        // Check the Z-axis.
        if (RotationZ) { localRotation.z = localRotationConstraints.z; }
        else { localRotationConstraints.z = localRotation.z; }

        // Apply the constrained local rotation.
        transform.localRotation = Quaternion.Euler(localRotation);


        // Get the current local position.
        Vector3 localPosition = transform.localPosition;

        // Check the X-axis.
        if (PositionX) { localPosition.x = localPositionConstraints.x; }
        else { localPositionConstraints.x = localPosition.x; }

        // Check the Y-axis.
        if (PositionY) { localPosition.y = localPositionConstraints.y; }
        else { localPositionConstraints.y = localPosition.y; }

        // Check the Z-axis.
        if (PositionZ) { localPosition.z = localPositionConstraints.z; }
        else { localPositionConstraints.z = localPosition.z; }

        // Apply the constrained local rotation.
        transform.localPosition = localPosition;
    }
}

