using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float startTime;
    public float moveSpeed;

    public float minX, maxX;
    public int sign = -1;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);

            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }
    }
}
