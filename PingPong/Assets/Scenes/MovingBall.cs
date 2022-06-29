using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    [SerializeField] private GameObject GazePointer;
    [SerializeField] private GameObject Ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pointer = GazePointer.transform.position;
        GazePointer.transform.position = new Vector3(Ball.transform.position.x, pointer.y, pointer.z);

        if (Vector3.Distance(GazePointer.transform.position, Ball.transform.position) <= 0.1f)
        {
            Ball.transform.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            Ball.transform.GetComponent<MeshRenderer>().material.color = Color.white;
        }


    }
}
