using UnityEngine;

public class Seeker : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject greenOrb;
    public float minDistance;
    public bool shipInOrbit = false;
    public float maxTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add rotation
        float distance = Vector2.Distance(transform.position, playerShip.transform.position);
        if (distance <= minDistance)
        {
            //halt rotation
            shipInOrbit = true;
            SeekerBeam();
        } else
        {
            shipInOrbit= false;
        }
    }

    public void SeekerBeam()
    {
        float timer = 0;
        timer += Time.deltaTime;
        if (timer > maxTimer && shipInOrbit == true)
        {
            Debug.DrawLine(greenOrb.transform.position,playerShip.transform.position, Color.red, 2);
            timer = 0;
        }
    }
}
