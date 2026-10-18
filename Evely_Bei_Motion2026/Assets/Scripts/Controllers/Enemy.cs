using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
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
    public bool deployedMissiles = false;
    public bool explode = false;
    public float radius;
    public int missilesNumber;
    public float timer = 0;
    float maxTimer;
    public GameObject missilePrefab;
    public List<float> angles;
    float currentMissileXY = 0;
    public int indexAngles = 0;
    public float missileOffset;
    public List<Vector3> missilePositions;
    public List<GameObject> missiles;
    float distance;
    Vector3 currentMissile;
    public int indexMissiles = 0;
    bool isOutOfMissiles = true;
    GameObject activeMissile;

    void Start()
    {
        defenceZone = 2f;
        maxTimer = 8f;
        missileOffset = 2;
    }

    void Update()
    {
        //Assignment 1 Code Begin
        timer += Time.deltaTime;
        distance = Vector2.Distance(transform.position, playerShip.transform.position);
        if (distance <= defenceZone && !inDefenceMode)
        {
            missilesNumber = Random.Range(2, 6);
            inDefenceMode = true;            
        }
        if(distance > defenceZone)
        {
            inDefenceMode = false;
        }
        if (inDefenceMode && isOutOfMissiles)
        {
            timer = 0;            
            DefenceMode(radius, missilesNumber);
        }
        if(deployedMissiles)
        {
            isOutOfMissiles = false;
            FireMissile();            
        }
        if ( timer > maxTimer)
        {
            timer = 0;
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
        float angleDivide = 180 / numberOfMissiles;
        if (angles.Count < numberOfMissiles)
        {            
            for (int i = 0; i < numberOfMissiles; i++)
            {
                currentMissileXY += angleDivide;
                angles.Add(currentMissileXY);
            }
        }

        currentMissileXY = 0;
        indexAngles = 0;
        if(indexAngles < angles.Count && angles.Count != 0)
        {
            for (int i = 0; i < angles.Count; i++)
            {
                currentMissileXY = angles[indexAngles];
                float angleInRadians = currentMissileXY * Mathf.Deg2Rad;
                currentMissile = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * missileOffset;
                missilePositions.Add(currentMissile);
                indexAngles++;
            }
        }

        //if (indexAngles < angles.Count)
        //{
        //    currentMissileXY = angles[indexAngles];
        //    float angleInRadians = currentMissileXY * Mathf.Deg2Rad;
        //    Vector3 currentMissile = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * missileOffset;
        //    missilePositions.Add(currentMissile);
        //    indexAngles++;
        //}
        indexMissiles = 0;
        if (indexMissiles < missilePositions.Count && missiles.Count <= missilePositions.Count -1)
        {
            for(int i = 0; i < missilePositions.Count; i++)
            {
                currentMissile = missilePositions[indexMissiles];
                GameObject newMissile = Instantiate(missilePrefab, currentMissile + transform.position, Quaternion.identity);
                missiles.Add(newMissile);
                indexMissiles++;
            }            
        }
        else
        {

        }

        if (missiles.Count >= missilePositions.Count)
        {
            deployedMissiles = true;            
        }

    }

    public void FireMissile()
    {
        indexMissiles = 0;
        if(missiles != null && missiles.Count > 0)
        {
            if (timer < maxTimer || !explode)
            {
                activeMissile = missiles[0];
                Vector3 direction = (playerShip.transform.position - activeMissile.transform.position).normalized;
                activeMissile.transform.position += moveSpeed * Time.deltaTime * direction;
                if (timer > maxTimer)
                {
                    missiles.Remove(activeMissile);
                    Destroy(activeMissile);
                    timer = 0;
                }
                float targetDistance = Vector2.Distance(activeMissile.transform.position, playerShip.transform.position);
                if (targetDistance < 0.5f)
                {
                    missiles.Remove(activeMissile);
                    Destroy(activeMissile);
                    timer = 0;
                }
            }

        }
        if (missiles.Count <= 0)
        {
            isOutOfMissiles = true;
            angles.Clear();
            missilePositions.Clear();
            missiles.Clear();
            deployedMissiles = false;
        }      
    }
    //Assignment 1 Code End

    //public void Skedaddle()
    //{           
    //    direction = (transform.position - playerShip.transform.position).normalized;

    //    transform.position += moveSpeed * Time.deltaTime * direction;
    //}


}
