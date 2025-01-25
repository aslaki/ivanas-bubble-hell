using UnityEngine;

public class CageController : MonoBehaviour
{
 [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float force;

    bool leftPressed;
    bool rightPressed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(leftPressed)
        {
            body.AddForce(Vector2.left * force);
        }
        if(rightPressed)
        {
            body.AddForce(Vector2.right * force);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        leftPressed = Input.GetKey(KeyCode.LeftArrow);
        rightPressed = Input.GetKey(KeyCode.RightArrow);
    }
}