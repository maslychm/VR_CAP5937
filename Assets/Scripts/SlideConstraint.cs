using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideConstraint : MonoBehaviour
{
    [Tooltip("A transform that represents the initial slide position.")]
    public Transform initialPosition;

    [Tooltip("A transform that represents the final slide position.")]
    public Transform finalPosition;

    [Tooltip("Whether to show lines representing the mathematical calculations. The white line represents the slide. The yellow line represents the current position and its projection onto the slide. The blue line represents the distance past the initial position. The red line represents the distance past the final position.")]
    public bool showCalculations = false;

    // Update is called once per frame
    void Update()
    {
        // Check that the two positions exist.
        if (initialPosition != null && finalPosition != null)
        {
            // Project the current position onto the slide.
            Vector3 projectedPosition = Vector3.Project(transform.position - initialPosition.position, finalPosition.position - initialPosition.position) + initialPosition.position;

            // Show the slide as a white line.
            if (showCalculations)
                Debug.DrawLine(initialPosition.position, finalPosition.position, Color.white, Time.deltaTime, false);

            // Show the current position and its projection onto the slide as a yellow line.
            if (showCalculations)
                Debug.DrawLine(transform.position, projectedPosition, Color.yellow, Time.deltaTime, false);

            // Determine the distance between the projected and initial positions.
            float initialDistance = Vector3.Distance(projectedPosition, initialPosition.position);

            // Determine the distance between the projected and final positions.
            float finalDistance = Vector3.Distance(projectedPosition, finalPosition.position);

            // Determine the slider distance between the initial and final positions.
            float sliderDistance = Vector3.Distance(initialPosition.position, finalPosition.position);

            // Check if the projected position is past the initial position.
            if (finalDistance > sliderDistance && initialDistance < sliderDistance)
            {
                transform.position = initialPosition.position;

                // Show the distance between the initial position and projected position as a blue line.
                if (showCalculations)
                    Debug.DrawLine(initialPosition.position, projectedPosition, Color.blue, Time.deltaTime, false);
            }
            // Check if the projected position is past the final position.
            else if (initialDistance > sliderDistance && finalDistance < sliderDistance)
            {
                transform.position = finalPosition.position;

                // Show the distance between the final position and projected position as a red line.
                if (showCalculations)
                    Debug.DrawLine(finalPosition.position, projectedPosition, Color.red, Time.deltaTime, false);
            }
            // Otherwise, the projected position is between the two positions.
            else
            {
                transform.position = projectedPosition;
            }
        }
    }
}
