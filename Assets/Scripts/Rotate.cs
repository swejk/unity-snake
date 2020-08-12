using UnityEngine;

/**
 * Rotates object in 2D.
 */
public class Rotate : MonoBehaviour
{
    public float DegreesPerSecond;

    private void Update()
    {
        // Rotate around z-axis
        transform.Rotate(Vector3.forward, Time.deltaTime * DegreesPerSecond);
    }
}