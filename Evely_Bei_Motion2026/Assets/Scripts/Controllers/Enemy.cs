using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public GameObject playerShip;
    public float comfortZone;
    Vector3 direction;
    public bool shipInZone = false;
    public float moveSpeed;
    public float maxSpeed;

    //Assignment 1 Variables
    public float defenceZone;
    public bool inDefenceMode = false;
    public float radius;
    int missilesNumber;
    float maxTimer;
    public GameObject missilePrefab;
    public List<float> angles;
    float currentMissileXY;
    int indexAngles = 0;
    float missileOffset;
    public List<Vector3> missilePositions;
    List<GameObject> missiles;

    void Start()
    {
        radius = defenceZone;
        defenceZone = 2f;
        maxTimer = 4f;
    }

    void Update()
    {
        //Assignment 1 Code Begin
        float distance = Vector2.Distance(transform.position, playerShip.transform.position);
        if (distance <= defenceZone)
        {
            inDefenceMode = true;
            missilesNumber = Random.Range(2, 6);
            DefenceMode(radius, missilesNumber);
        }
        //Assignment 1 Code End

        //float distance = Vector2.Distance(transform.position, playerShip.transform.position);
        //if (distance <= comfortZone)
        //{
        //    shipInZone = true;
        //    Skedaddle();

        //} else
        //{
        //    shipInZone = false;
        //}


    }

    //Assignment 1 Code Begin
    public void DefenceMode(float radius, int numberOfMissiles)
    {
        float timer = 0;
        timer += Time.deltaTime;

        if (angles.Count < numberOfMissiles)
        {
            for (int i = 0; i < numberOfMissiles; i++)
            {
                currentMissileXY += ((180 / numberOfMissiles) + 180);
                angles.Add(currentMissileXY);
            }
        }
        currentMissileXY = 0;

        if(indexAngles < numberOfMissiles)
        {
            currentMissileXY = angles[indexAngles];
            float angleInRadians = currentMissileXY * Mathf.Deg2Rad;
            Vector3 currentMissile = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * missileOffset;
            missilePositions.Add(currentMissile);
            indexAngles++;
        }
        for (int i = 0; i < missilePositions.Count; i++)
        {
            if (missilePositions[i] != null)
            {
                GameObject newMissile = Instantiate(missilePrefab, missilePositions[i], Quaternion.identity);
                missiles.Add(newMissile);
            }
        }
        
    }
    //Assignment 1 Code End

    //public void Skedaddle()
    //{           
    //    direction = (transform.position - playerShip.transform.position).normalized;

    //    transform.position += moveSpeed * Time.deltaTime * direction;
    //}

    
}
