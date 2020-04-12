using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingConstraint : MonoBehaviour
{
    [Tooltip("A transform that represents the initial swing position.")]
    public Transform initialRotation;

    [Tooltip("A transform that represents the final slide position.")]
    public Transform finalRotation;

    [Tooltip("Whether to show the lines representing the mathematical calculations. The yellow line represents the current center of mass vector. The blue line represents the initial center of mass vector. The red line represnts the final center of mass vector. The white lines represent the cross products of current vector with the initial and final vectors. They will overlap when the current vector is between the initial and final vectors and separate when it is beyond either vector.")]
    public bool showCalculations = false;

    // Update is called once per frame
    void Update()
    {
        // Check that the two rotations exist.
        if (initialRotation != null && finalRotation != null)
        {
            // Check that a local RigidBody exists.
            Rigidbody rigidBody = GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                // Determine the current center of mass vector.
                Vector3 currentCOM = ((transform.rotation * rigidBody.centerOfMass) - (initialRotation.position - transform.position)).normalized;

                // Show the current center of mass vector from its initial position as a yellow line.
                if (showCalculations)
                    Debug.DrawLine(initialRotation.position, initialRotation.position + currentCOM, Color.yellow, Time.deltaTime, false);

                // Determine the initial center of mass vector.
                Vector3 initialCOM = (initialRotation.rotation * rigidBody.centerOfMass).normalized;

                // Show the initial center of mass vector as a blue line.
                if (showCalculations)
                    Debug.DrawLine(initialRotation.position, initialRotation.position + initialCOM, Color.blue, Time.deltaTime, false);

                // Determine the final center of mass vector.
                Vector3 finalCOM = (finalRotation.rotation * rigidBody.centerOfMass).normalized;

                // Show the final center of mass vector as a red line.
                if (showCalculations)
                    Debug.DrawLine(finalRotation.position, finalRotation.position + finalCOM, Color.red, Time.deltaTime, false);

                // Determine the cross product of the initial and final centers of mass.
                Vector3 swingCross = Vector3.Cross(initialCOM, finalCOM).normalized;

                // Project the current center of mass vector onto the swing plane.
                Vector3 projectedCOM = Vector3.ProjectOnPlane(currentCOM, swingCross).normalized;

                // Determine the cross product of the initial and projected centers of mass.
                Vector3 initialCross = Vector3.Cross(initialCOM, projectedCOM).normalized;

                // Show the initial cross product vector as a white line.
                if (showCalculations)
                    Debug.DrawLine(initialRotation.position, initialRotation.position + initialCross, Color.white, Time.deltaTime, false);

                // Determine the cross product of the projected and final centers of mass.
                Vector3 finalCross = Vector3.Cross(projectedCOM, finalCOM).normalized;

                // Show the final cross product vector as a white line.
                if (showCalculations)
                    Debug.DrawLine(finalRotation.position, finalRotation.position + finalCross, Color.white, Time.deltaTime, false);

                // Check if the current rotation is inside of the initial and final rotations.
                if (initialCross == swingCross && finalCross == swingCross)
                {
                    // Determine the rotation between the initial and projected centers of mass.
                    Quaternion projectedRotation = Quaternion.FromToRotation(initialCOM, projectedCOM);

                    // Apply the rotation to the current transform.
                    transform.rotation = projectedRotation * initialRotation.rotation;
                }
                // Otherwise, the current rotation is outside of the initial and final rotations.
                else
                {
                    // Determine how close the current rotation is to the initial rotation.
                    float initialDistance = (projectedCOM - initialCOM).magnitude;

                    // Determine how close the current rotation is to the final rotation.
                    float finalDistance = (projectedCOM - finalCOM).magnitude;

                    // Check if closer to final rotation.
                    if (initialDistance > finalDistance)
                    {
                        // Set to final rotation.
                        transform.rotation = finalRotation.rotation;
                    }
                    // Otherwise set to initial rotation.
                    else
                    {
                        transform.rotation = initialRotation.rotation;
                    }
                }
            }
        }
    }
}
