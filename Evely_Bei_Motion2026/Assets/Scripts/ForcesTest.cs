using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePos.z = 0;
            Vector3 directionToApplyForce = worldMousePos - transform.position;

            rb.AddForce(directionToApplyForce.normalized * forceStrength, ForceMode2D.Force);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision enter");
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision exit");
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision stay");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger exit");
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger stay");
    }
}
