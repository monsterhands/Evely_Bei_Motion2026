using UnityEngine;

public class FirstScript : MonoBehaviour
{
    Vector2 originPosition = new Vector2(0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int x = 0;

        int y = x + 1;

        //float health = 0.5f;

        //Vector2 originPosition = new Vector2(0, 0);
        //using a constructor method to create a new Vector2 from scratch
        Vector2 currentPosition = new Vector2(3, -2);

        //Vectors are more complex than a number like float or int

        //draw line draws line between start and end points
        //Debug.DrawLine(originPosition, currentPosition, Color.gray, 15f);
        Debug.Log(currentPosition);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dVector = new Vector2(0, 1);
        Vector2 eVector = new Vector2(3, -2);
        Debug.DrawLine(originPosition, dVector, Color.yellow);
        Debug.DrawLine(originPosition, eVector, Color.gray);

    }
}
