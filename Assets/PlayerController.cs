using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float force;

    bool leftPressed;
    bool rightPressed;


    [SerializeField]
    Transform anchor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //Calculate vector from the anchor 
        var direction = anchor.position - transform.position;
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
