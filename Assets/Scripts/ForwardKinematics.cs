using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardKinematics : MonoBehaviour
{
    [Tooltip("List of Transforms to animate through forward kinematics.")]
    public List<Transform> targetTransforms;

    [Tooltip("List of starting Transform rotations.")]
    public List<Transform> startingRotations;

    [Tooltip("List of ending Transform rotations.")]
    public List<Transform> endingRotations;

    [Tooltip("Animation time in seconds.")]
    public float animationTime = 1.0f;

    [Tooltip("Whether to play the animation.")]
    public bool animate = false;

    // How long the animation has played.
    private float runTime;

    // Start is called before the first frame update
    void Start()
    {
        // Reset the run time.
        runTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If playing the forward kinematics animation.
        if (animate)
        {
            // Update the run time.
            runTime += Time.deltaTime;

            // Clamp the run time.
            runTime = Mathf.Clamp(runTime, 0.0f, animationTime);

            // Update each rotation.
            for (int i = 0; i < targetTransforms.Count && i < startingRotations.Count && i < endingRotations.Count; i++)
            {
                // Check that the target, starting, and ending transforms are valid.
                if (targetTransforms[i] != null && startingRotations[i] != null && endingRotations[i] != null)
                {
                    targetTransforms[i].localRotation = Quaternion.Lerp(startingRotations[i].localRotation, endingRotations[i].localRotation, runTime / animationTime);
                }
            }
        }
        // If not playing the forward kinematics animation.
        else
        {
            // Reset the run time.
            runTime = 0.0f;
        }
    }
}
