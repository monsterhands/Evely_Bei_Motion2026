using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector3 bombOffset;
    public float bombTrailSpacing;
    public int numberOfTrailBombs;

    public Vector3[] corners;

    public float ratioIncrease = 0;

    public float maxRange = 1;
    public float lineTime = 3;

    public Vector3 currentVelocity;
    public Vector3 currentDeceleration;
    public float speed;
    public float accelerationTime;
    public float accelerationDirection;
    public float currentAcceleration;
    public float maxSpeed;
    public float decelerationTime;
    public float deceleration;

    public List<float> angles;
    float currentAngle = 0;
    float nextAngle;
    float angleInRadians;
    Vector3 radiusOffset;
    public float radiusValue;
    public int circlePointsValue;
    public int indexAngles = 0;

    public int powerups;

    void Start()
    {
        currentAcceleration = maxSpeed / accelerationTime;

        deceleration = maxSpeed / decelerationTime;
        radiusValue = 2f;
        circlePointsValue = Random.Range(3, 10);
    }

    void Update()
    {
        //basic motion to the right in every frame
        //transform.position = transform.position + currentVelocity;
        PlayerMovement();

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            float offsetDistance = 0.5f;
            bombOffset = transform.position * offsetDistance;
            SpawnBombAtOffset(bombOffset);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            bombTrailSpacing = 0.8f;
            numberOfTrailBombs = 3;
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            float distance = 1f;
            SpawnBombOnRandomCorner(distance);
        }

        Vector2 scrollValue = Mouse.current.scroll.ReadValue();
        if (scrollValue.y > 0)
        {
            if (ratioIncrease > 1f)
            {

            } else
            {
                ratioIncrease = ratioIncrease + 0.1f;
                WarpPlayer(enemyTransform, ratioIncrease);
            }
        } else if (scrollValue.y <= 0)
        {

        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            maxRange = maxRange + 0.5f;
            DetectAsteroids(maxRange, asteroidTransforms);
        }

        //EnemyRadar(radiusValue, circlePointsValue);



        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            
            if (angles.Count == 0)
            {
                powerups = Random.Range(2, 8);
                SpawnPowerups(radiusValue, powerups);
            }else
            {
                angles.Clear();
                powerups = Random.Range(2, 8);
                SpawnPowerups(radiusValue, powerups);
            }            
        }
    }

    public void SpawnBombAtOffset(Vector3 inOffset)
    {
        Instantiate(bombPrefab, inOffset, Quaternion.identity);
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        Vector3 bombPosition = transform.position;
        for(int i = 0; i < inNumberOfBombs; i++)
        {
            bombPosition.y -= inBombSpacing;
            Instantiate(bombPrefab, bombPosition, Quaternion.identity);
        }        
    }
    public void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector3 playerPos = transform.position;

        Vector3 corner1 = (Vector3.up + Vector3.left).normalized;
        Vector3 corner2 = (Vector3.down + Vector3.left).normalized;
        Vector3 corner3 = (Vector3.down + Vector3.right).normalized;
        Vector3 corner4 = (Vector3.up + Vector3.right).normalized;

        corners = new Vector3[]
        {
            playerPos + (corner1 * inDistance),
            playerPos + (corner2 * inDistance),
            playerPos + (corner3 * inDistance),
            playerPos + (corner4 * inDistance),
        };

        int randomCornerNumber = Random.Range(0, corners.Length);

        Vector3 randomCorner = corners[randomCornerNumber];
        Instantiate(bombPrefab, randomCorner, Quaternion.identity);
    }

    public void WarpPlayer(Transform target, float ratio)
    {
        transform.position = Vector3.Lerp(transform.position, target.position, ratio);
    }

    public void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        float sqrMaxRange = maxRange * maxRange;
        foreach (Transform asteroid in inAsteroids)
        {
            if (asteroid != null)
            {
                Vector3 distanceToAsteroid = asteroid.transform.position - transform.position;
                float distance = distanceToAsteroid.magnitude;
                if (distance <= sqrMaxRange)
                {
                    Debug.DrawLine(transform.position, asteroid.position, Color.green, lineTime);
                } else
                {

                }
            } else
                {

                }
        }
    }

    //basic velocity
    //public void PlayerMovement()
    //{
    //    currentVelocity = Vector3.zero;
    //    if (Keyboard.current.upArrowKey.isPressed)
    //    {
    //        currentVelocity += Vector3.up;
    //    }

    //    if (Keyboard.current.rightArrowKey.isPressed)
    //    {
    //        currentVelocity += Vector3.right;
    //    }

    //    if (Keyboard.current.downArrowKey.isPressed)
    //    {
    //        currentVelocity += Vector3.down;
    //    }

    //    if (Keyboard.current.leftArrowKey.isPressed)
    //    {
    //        currentVelocity += Vector3.left;
    //    }

    //    transform.position = transform.position + currentVelocity.normalized * speed * Time.deltaTime;
    //}

    //basic acceleration
    //public void PlayerMovement()
    //{
    //    maxSpeed = 5f;
    //    Vector3 accelerationDirection = Vector3.zero;
    //    if (Keyboard.current.upArrowKey.isPressed)
    //    {
    //        accelerationDirection += Vector3.up;
    //    }

    //    if (Keyboard.current.rightArrowKey.isPressed)
    //    {
    //        accelerationDirection += Vector3.right;
    //    }

    //    if (Keyboard.current.downArrowKey.isPressed)
    //    {
    //        accelerationDirection += Vector3.down;
    //    }

    //    if (Keyboard.current.leftArrowKey.isPressed)
    //    {
    //        accelerationDirection += Vector3.left;
    //    }

    //    if (currentVelocity.magnitude > maxSpeed)
    //    {
    //        currentVelocity = currentVelocity.normalized * maxSpeed;
    //    }
    //    else if (currentVelocity.magnitude < maxSpeed)
    //    {
    //        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;
    //    }

    //    transform.position = transform.position + currentVelocity * Time.deltaTime;
    //}

    //added deceleration
    public void PlayerMovement()
    {
        maxSpeed = 5f;
        Vector3 accelerationDirection = Vector3.zero;
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationDirection += Vector3.up;
        }        

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationDirection += Vector3.right;
        }

        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationDirection += Vector3.down;
        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationDirection += Vector3.left;
        }

        if (accelerationDirection.magnitude == 0)
        {
            currentVelocity += -currentVelocity.normalized * deceleration * Time.deltaTime;            
        }
            
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }
        else if (currentVelocity.magnitude < maxSpeed)
        {
            currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;
        }

        transform.position = transform.position + currentVelocity * Time.deltaTime;
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        if(angles.Count < circlePoints)
        {
            for (int i = 0; i < circlePoints; i++)
            {
                currentAngle += 360 / circlePoints;
                angles.Add(currentAngle);
            }
        }
        currentAngle = 0;
        
        float distance = Vector3.Distance(transform.position, enemyTransform.position);
        if (distance <= radius)
        {
            if (indexAngles + 1 >= angles.Count)
            {
                indexAngles = 0;
                currentAngle = angles.Count;
                nextAngle = angles[0];
                angleInRadians = currentAngle * Mathf.Deg2Rad;
                float nextAngleInRadians = nextAngle * Mathf.Deg2Rad;
                Vector3 currentPoint = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * radius;
                Vector3 nextPoint = new Vector3(Mathf.Cos(nextAngleInRadians), Mathf.Sin(nextAngleInRadians)) * radius;
                Debug.DrawLine(currentPoint + transform.position, nextPoint + transform.position, Color.red);
            }
            else
            {
                currentAngle = angles[indexAngles];
                nextAngle = angles[indexAngles + 1];
                angleInRadians = currentAngle * Mathf.Deg2Rad;
                float nextAngleInRadians = nextAngle * Mathf.Deg2Rad;
                Vector3 currentPoint = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * radius;
                Vector3 nextPoint = new Vector3(Mathf.Cos(nextAngleInRadians), Mathf.Sin(nextAngleInRadians)) * radius;
                Debug.DrawLine(currentPoint + transform.position, nextPoint + transform.position, Color.red);
                indexAngles++;
            }
        } else
        {
            if (indexAngles + 1 >= angles.Count)
            {
                indexAngles = 0;
                currentAngle = angles.Count;
                nextAngle = angles[0];
                angleInRadians = currentAngle * Mathf.Deg2Rad;
                float nextAngleInRadians = nextAngle * Mathf.Deg2Rad;
                Vector3 currentPoint = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * radius;
                Vector3 nextPoint = new Vector3(Mathf.Cos(nextAngleInRadians), Mathf.Sin(nextAngleInRadians)) * radius;
                Debug.DrawLine(currentPoint + transform.position, nextPoint + transform.position, Color.green);
            }
            else
            {
                currentAngle = angles[indexAngles];
                nextAngle = angles[indexAngles + 1];
                angleInRadians = currentAngle * Mathf.Deg2Rad;
                float nextAngleInRadians = nextAngle * Mathf.Deg2Rad;
                Vector3 currentPoint = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * radius;
                Vector3 nextPoint = new Vector3(Mathf.Cos(nextAngleInRadians), Mathf.Sin(nextAngleInRadians)) * radius;
                Debug.DrawLine(currentPoint + transform.position, nextPoint + transform.position, Color.green);
                indexAngles++;
            }
        }         
           
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        if (angles.Count < numberOfPowerups)
        {
            for (int i = 0; i < numberOfPowerups; i++)
            {
                currentAngle += 360 / numberOfPowerups;
                angles.Add(currentAngle);
            }
        }
        currentAngle = 0;


        if (indexAngles <= angles.Count-1)
        {            
            currentAngle = angles[indexAngles];
            angleInRadians = currentAngle * Mathf.Deg2Rad;
            Vector3 currentPoint = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * radius;
            Vector3 offsetPoint = currentPoint * 0.05f;
            Debug.DrawLine(currentPoint + transform.position, offsetPoint + transform.position, Color.green, 5);
            indexAngles++;
        } else
        {

        }
    }

}
