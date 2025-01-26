using UnityEngine;

public class BubbleRotate : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotate the bubble
        transform.Rotate(0, 0, rotationSpeed);
    }
}
