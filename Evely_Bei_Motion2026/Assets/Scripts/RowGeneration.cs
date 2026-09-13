using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{
    public GameObject whiteSquare;
    public GameObject spawnedSquare;
    public List<GameObject> spawnedSquares;

    public Vector3 firstPosition;
    public float distance = 1.5f;

    public TMP_InputField squareCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateSquare()
    {
        if(spawnedSquare == null)
        {
            Vector3 spawnPos = firstPosition;
            spawnedSquare = Instantiate(whiteSquare, spawnPos, Quaternion.identity);
            spawnedSquares.Add(spawnedSquare);
            spawnPos.x += distance;
        } else
        {
            Vector3 spawnPos = spawnedSquare.transform.position;
            for (int i = 0; i < 1; i++)
            {
                spawnPos.x += distance;
                spawnedSquare = Instantiate(whiteSquare, spawnPos, Quaternion.identity);
                spawnedSquares.Add(spawnedSquare);
            }
        }
       CountTheSquares();
    }

    public void CountTheSquares()
    {
        string currentCount = spawnedSquares.Count.ToString();
        squareCount.text = currentCount;
    }
}
