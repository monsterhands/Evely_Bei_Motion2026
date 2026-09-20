using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
}
