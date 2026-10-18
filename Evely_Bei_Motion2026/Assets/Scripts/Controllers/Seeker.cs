using UnityEngine;

public class Seeker : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject greenOrb;
    public float minDistance;
    public bool shipInOrbit = false;
    bool activeBeam = false;
    public float maxTimer;
    public float timer = 0;
    float duration;
    float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxTimer = 4;
        duration = 2;
        minDistance = 5;
        rotationSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Vector3 directionToShip = (playerShip.transform.position - transform.position).normalized;
        bool turnRight = false;

        float dotToRight = Vector3.Dot(transform.right, directionToShip);
        turnRight = dotToRight > 0;

        if (turnRight)
        {
            transform.eulerAngles -= Vector3.forward * rotationSpeed * Time.deltaTime;
        }
        else
        {
            transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }


        float distance = Vector2.Distance(transform.position, playerShip.transform.position);
        if (distance <= minDistance && !activeBeam)
        {
            rotationSpeed = 0;
            shipInOrbit = true;
            SeekerBeam();
        } else
        {
            rotationSpeed = 4f;
            shipInOrbit= false;
        }
        if (timer > maxTimer)
        {
            activeBeam = false;
            timer = 0;
        }
    }

    public void SeekerBeam()
    {
        if (shipInOrbit && !activeBeam)
        {
            timer = 0;
            activeBeam = true;
            Debug.DrawLine(greenOrb.transform.position,playerShip.transform.position, Color.red, duration);          
        }
    }

}
