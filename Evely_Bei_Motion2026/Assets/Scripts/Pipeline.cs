using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    Vector3 storedMousePos;
    Vector3 newMousePos;
    public float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed == true)
        {
            timer += Time.deltaTime;
            storedMousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }

        if(timer > 0.1)
        {
            newMousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.DrawLine(storedMousePos, newMousePos, Color.magenta);
            newMousePos = storedMousePos;
            timer = 0;
        }
    }
}
