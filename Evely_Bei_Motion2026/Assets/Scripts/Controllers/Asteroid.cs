using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        GetRandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (targetPoint - transform.position).normalized;
        transform.position += moveSpeed * Time.deltaTime * direction;
        float distance = Vector2.Distance(transform.position, targetPoint);
        if(distance <= arrivalDistance)
        {
            GetRandomPoint() ;
        }
    }

    public void GetRandomPoint()
    {
        targetPoint = Random.insideUnitCircle;
        targetPoint.Normalize();
        targetPoint *= maxFloatDistance;
    }
}
