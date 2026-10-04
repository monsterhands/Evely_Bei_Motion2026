using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    public float timer = 0;

    int currentStar = 0;
    int nextStar;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (nextStar == (starTransforms.Count-1))
        {
            currentStar = 0;
        }

        if (timer > drawingTime)
        {
            DrawConstellation();
            currentStar++;
            timer = 0;
        }        
        
    }

    public void DrawConstellation()
    {
        nextStar = currentStar + 1;

        Debug.DrawLine(starTransforms[currentStar].position, starTransforms[nextStar].position, Color.azure, drawingTime);        
    }
}
