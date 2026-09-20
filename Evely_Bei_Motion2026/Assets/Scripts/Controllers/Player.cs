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
}
