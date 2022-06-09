using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = .1f;

    public float startTime;
    public float minX, maxX;
    public float minZ, maxZ;

    public float moveSpeed;
    public int xsign = -1;
    public int zsign = -1;

    public int way = 1;

    // Update is called once per frame
    void Update()
    {
        /*float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection;

        transform.position += moveDirection * speed;*/
        
        
        if (Time.time >= startTime)
        {
            if (way == 1)
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime * xsign, 0, 0);

                if (transform.position.x <= minX || transform.position.x >= maxX)
                {
                    xsign *= -1;
                }
                if (transform.position.x >= maxX)
                {
                    way *= -1;
                }
            }

            else
            {
                transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * zsign);

                if (transform.position.z <= minZ || transform.position.z >= maxZ)
                {
                    zsign *= -1;
                }
                if (transform.position.z >= maxZ)
                {
                    way *= -1;
                }
                    
            }
            

        }


    }
}
