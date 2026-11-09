using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public float lifespan;
    public bool isCannonball = false;

    // Start is called before the first frame update
    void Start()
    {
        isCannonball = true;
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CannonballController>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
