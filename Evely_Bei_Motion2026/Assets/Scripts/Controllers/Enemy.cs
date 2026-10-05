using System.Collections;
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

    void Start()
    {
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerShip.transform.position);
        if (distance <= comfortZone)
        {
            shipInZone = true;
            Skedaddle();

        } else
        {
            shipInZone = false;
        }


    }

    public void Skedaddle()
    {           
        direction = (transform.position - playerShip.transform.position).normalized;

        transform.position += moveSpeed * Time.deltaTime * direction;
    }
}
