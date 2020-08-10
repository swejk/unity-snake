using UnityEngine;

public class Snake : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
        }
    }
}