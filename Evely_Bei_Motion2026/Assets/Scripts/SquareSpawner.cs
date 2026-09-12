using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class SquareSpawner : MonoBehaviour
{
    public GameObject whiteSquare;
    public GameObject mouseFollowSquare;
    public GameObject spawnedSquare;
    public List<GameObject> spawnedSquares;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasPressedThisFrame == true)
        {
            spawnedSquare = Instantiate(whiteSquare, mousePos, Quaternion.identity);
            spawnedSquares.Add(spawnedSquare);
            Debug.DrawLine(Vector3.zero, mousePos, Color.white);
        }

        mouseFollowSquare.transform.position = mousePos;

        Vector2 scrollValue = Mouse.current.scroll.ReadValue();
        if (scrollValue.y > 0)
        {
            mouseFollowSquare.transform.localScale += Vector3.one * 0.05f;
        } else if(scrollValue.y < 0)
        {
            mouseFollowSquare.transform.localScale -= Vector3.one * 0.05f;
        } else
        {

        }

        if (spawnedSquare != null)
        {
            foreach (GameObject spawnedSquare in spawnedSquares)
            {
                if (scrollValue.y > 0)
                {
                    spawnedSquare.transform.localScale += Vector3.one * 0.05f;
                }
                else if (scrollValue.y < 0)
                {
                    spawnedSquare.transform.localScale -= Vector3.one * 0.05f;
                }
                else
                {

                }
            }           

        }

    }
}
