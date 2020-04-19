using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum axisToAnimate
{
    XAxis,
    YAxis,
    ZAxis
}

public class TimeToAnimate : MonoBehaviour
{
    [Tooltip("Hour hand to animate.")]
    public GameObject hourHand;

    [Tooltip("Minute hand to animate.")]
    public GameObject minuteHand;

    [Tooltip("Second hand to animate.")]
    public GameObject secondHand;

    [Tooltip("Local axis to rotate about.")]
    public axisToAnimate axis = axisToAnimate.ZAxis;

    // Update is called once per frame
    void Update()
    {
        // Get the current time.
        System.DateTime currentTime = System.DateTime.Now;
        float currentHour = currentTime.Hour % 12.0f;
        float currentMinute = currentTime.Minute % 60.0f;
        float currentSecond = currentTime.Second % 60.0f;

        // Calculate clock rotations.
        float clockHour = (currentHour + (currentMinute / 60.0f)) * (360.0f / 12.0f);
        float clockMinute = (currentMinute + (currentSecond / 60.0f)) * (360.0f / 60.0f);
        float clockSecond = (currentSecond) * (360.0f / 60.0f);

        // Check that the hour hand exists.
        if (hourHand != null)
        {
            // If X axis.
            if (axis == axisToAnimate.XAxis)
            {
                hourHand.transform.localEulerAngles = new Vector3(clockHour, 0.0f, 0.0f);
            }
            // If Y axis.
            else if (axis == axisToAnimate.YAxis)
            {
                hourHand.transform.localEulerAngles = new Vector3(0.0f, clockHour, 0.0f);
            }
            // If Z axis.
            else if (axis == axisToAnimate.ZAxis)
            {
                hourHand.transform.localEulerAngles = new Vector3(0.0f, 0.0f, clockHour);
            }
        }

        // Check that the minute hand exists.
        if (minuteHand != null)
        {
            // If X axis.
            if (axis == axisToAnimate.XAxis)
            {
                minuteHand.transform.localEulerAngles = new Vector3(clockMinute, 0.0f, 0.0f);
            }
            // If Y axis.
            else if (axis == axisToAnimate.YAxis)
            {
                minuteHand.transform.localEulerAngles = new Vector3(0.0f, clockMinute, 0.0f);
            }
            // If Z axis.
            else if (axis == axisToAnimate.ZAxis)
            {
                minuteHand.transform.localEulerAngles = new Vector3(0.0f, 0.0f, clockMinute);
            }
        }

        // Check that the second hand exists.
        if (secondHand != null)
        {
            // If X axis.
            if (axis == axisToAnimate.XAxis)
            {
                secondHand.transform.localEulerAngles = new Vector3(clockSecond, 0.0f, 0.0f);
            }
            // If Y axis.
            else if (axis == axisToAnimate.YAxis)
            {
                secondHand.transform.localEulerAngles = new Vector3(0.0f, clockSecond, 0.0f);
            }
            // If Z axis.
            else if (axis == axisToAnimate.ZAxis)
            {
                secondHand.transform.localEulerAngles = new Vector3(0.0f, 0.0f, clockSecond);
            }
        }
    }
}
