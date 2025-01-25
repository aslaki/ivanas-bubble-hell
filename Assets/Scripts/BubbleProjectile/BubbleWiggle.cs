using System.Collections;
using UnityEngine;

public class BubbleWiggle : MonoBehaviour
{
    public float speed = 3;
    private float wiggleSpeed = 1;
    private float wiggleSwitch = 1f;

    private bool waitToSwitch;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Translate(Vector3.right * wiggleSpeed * Time.deltaTime);

        if (!waitToSwitch)
        {
            StartCoroutine(WiggleSwitch());
        }
    }

    private IEnumerator WiggleSwitch()
    {
            waitToSwitch= true;
            wiggleSpeed *= -1;
            yield return new WaitForSeconds(wiggleSwitch); 
            waitToSwitch= false;
    }
}
