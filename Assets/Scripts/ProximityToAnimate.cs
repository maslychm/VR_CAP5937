using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityToAnimate : MonoBehaviour
{
    [Tooltip("The Animator to animate.")]
    public Animator animator;

    [Tooltip("The proximal GameObject that affects the animator.")]
    public GameObject affector;

    [Tooltip("The maximum distance that affects the animator.")]
    public float maxDistance = 1.0f;

    [Tooltip("The animator Bool parameter to affect.")]
    public string parameter = "";

    [Tooltip("The animator Bool parameter value to set.")]
    public bool value = false;

    // The original value of the animator Bool parameter.
    private bool originalValue;

    // Start is called before the first frame update
    void Start()
    {
        // Check that the animator exists.
        if (animator != null)
        {
            // Store the original value of the animator Bool parameter.
            originalValue = animator.GetBool(parameter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check that the animator and affector exist.
        if (animator != null && affector != null)
        {
            // Get the animator's position.
            Vector3 animatorPosition = animator.transform.position;

            // Get the affector's position.
            Vector3 affectorPosition = affector.transform.position;

            // Get the current distance between the animator and affector.
            float currentDistance = Vector3.Distance(animatorPosition, affectorPosition);

            // Check if the current distance is greater than maximum distance.
            if (currentDistance > maxDistance)
            {
                // Restore the original value of the animator Bool parameter.
                animator.SetBool(parameter, originalValue);
            }
            // Check if the current distance is within the maximum distance.
            else
            {
                // Set the new value of the animator Bool parameter.
                animator.SetBool(parameter, value);
            }
        }
    }
}
