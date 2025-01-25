using UnityEngine;

public class Gizmo : MonoBehaviour
{

    public Color color = Color.red;
    public float radius = 0.5f;

    void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
