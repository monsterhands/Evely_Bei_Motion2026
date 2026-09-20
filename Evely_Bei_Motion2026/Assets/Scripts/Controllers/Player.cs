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

    void Update()
    {
        if(Keyboard.current.bKey.wasPressedThisFrame)
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
}
