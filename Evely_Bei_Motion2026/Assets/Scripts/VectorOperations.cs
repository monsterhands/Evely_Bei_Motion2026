using UnityEngine;

public class VectorOperations : MonoBehaviour
{
    public Vector2 redVector; //x = 1, y = 3
    public Vector2 blueVector; //x = 2, y = 2

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 redMinusBlue = redVector - blueVector;
        //R-B x = -1, y = 1
        Vector2 redPlusBlue = redVector + blueVector;
        //R+B x = 3, y = 5

        Vector2 origin = new Vector2(0, 0);

        Debug.DrawLine(origin, redVector, Color.red);
        Debug.DrawLine(origin, blueVector, Color.blue);
        Debug.DrawLine(origin, redPlusBlue, Color.purple);
        Debug.DrawLine(origin, redMinusBlue, Color.orange);
    }
}
