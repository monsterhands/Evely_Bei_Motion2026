using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngleTest : MonoBehaviour
{
    public List<float> angles;
    private int currentAngleIndex = 0;
    public Vector3 currentTargetPosition;

    public float circleRadius;
    public Vector3 circleOffset;

    public float shiftDuration;
    private float shiftProgress = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float fortyFiveDegree = 45f;
        //float ffDInRadians = fortyFiveDegree * Mathf.Deg2Rad;
        //float twoPiRadians = 2 * Mathf.PI;
        //float tprInDegrees = twoPiRadians * Mathf.Rad2Deg;

        ////needs radians rather than degrees
        //float currentAngle = 90f;
        //Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        //Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        angles.Add(10f);
        angles.Add(35f);
        angles.Add(50f);
        angles.Add(87f);
        angles.Add(100f);
        angles.Add(112f);
        angles.Add(180f);
        angles.Add(240f);
        angles.Add(250f);
        angles.Add(300f);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    currentAngleIndex++;

        //    if(currentAngleIndex >= angles.Count)
        //    {
        //        currentAngleIndex = 0;
        //    }
        //}

        shiftProgress += Time.deltaTime;

        if(shiftProgress > shiftDuration)
        {
            currentAngleIndex++;

            if (currentAngleIndex >= angles.Count)
            {
                currentAngleIndex = 0;
            }
            shiftProgress = 0f;
        }

        float currentAngleNumber = angles[currentAngleIndex];
        float currentAngleInRadians = currentAngleNumber * Mathf.Deg2Rad;

        Vector3 startPoint = Vector3.zero + circleOffset;
        Vector3 endPoint = new Vector3(Mathf.Cos(currentAngleInRadians), Mathf.Sin(currentAngleInRadians)) * circleRadius + circleOffset;

        Debug.DrawLine(startPoint, endPoint, Color.wheat);      
    }
}
