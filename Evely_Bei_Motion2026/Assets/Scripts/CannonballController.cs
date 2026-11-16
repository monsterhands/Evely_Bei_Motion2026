using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public float lifespan;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.IsTouching(collision.gameObject.GetComponent<Collider2D>()))
        {
            Debug.Log("Touching an object.");
        }
        if(collision.gameObject.GetComponent<CannonballController>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
