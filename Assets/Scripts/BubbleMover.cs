using UnityEngine;

public class BubbleMover : MonoBehaviour
{
    [SerializeField] private float bubbleSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bubbleSpeed * Time.deltaTime);
    }
}
