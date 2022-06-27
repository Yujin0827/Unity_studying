using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovingDot : MonoBehaviour
{

    [SerializeField] private Camera cam;        // Camera
    [SerializeField] private GameObject GazePointer;    // Dot Prefab
    [SerializeField] private GameObject dot;    // dot

    private int cnt = 3;
    private Vector3[] dotPos;   // dot 이동 위치
    private int moveNum = 0;

    float curGazeTime = 0;      // 응시하는 시간
    [SerializeField] private float gazeChargeTime;

       
    // Start is called before the first frame update
    void Start()
    {
        curGazeTime = 0;

        dotPos = new Vector3[cnt * 4 + 1];

        // set dot position
        dotPos[0] = dot.transform.localPosition;
        for (int i = 1; i <= cnt; i++)
        {   
            float sinVal = Mathf.Sin(Mathf.Deg2Rad * 5.0f * i);
            float cosVal = Mathf.Cos(Mathf.Deg2Rad * 5.0f * i);
            Debug.Log("sin Value: " + sinVal);
            Debug.Log("cos Value: " + cosVal);

            dotPos[i] = new Vector3(-sinVal, 0, cosVal);
            //Debug.Log("left position: " + dotPos[i]);

            dotPos[cnt + i] = new Vector3(sinVal, 0, cosVal);
            //Debug.Log("right position: " + dotPos[cnt + i]);

            dotPos[cnt * 2 + i] = new Vector3(0, sinVal, cosVal);
            //Debug.Log("top position: " + dotPos[cnt * 2 + i]);

            dotPos[cnt * 3 + i] = new Vector3(0, -sinVal, cosVal);
            //Debug.Log("bottom position: " + dotPos[cnt * 3 + i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GazePointer: " + GazePointer.transform.position);
        Debug.Log("dot: " + dot.transform.position);

        if (Vector3.Distance(GazePointer.transform.position, dot.transform.position) <= 0.05f)
        {
            GazeToDot();
        }
        else
        {
            NotGazeToDot();
        }


    }

    public void GazeToDot()
    {
        dot.transform.GetComponent<MeshRenderer>().material.color = Color.green;
        curGazeTime += Time.deltaTime;

        if (curGazeTime >= 2f)
        {
            MoveDotPosition();
            dot.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            curGazeTime = 0;
        }
    }

    public void NotGazeToDot()
    {
        dot.transform.GetComponent<MeshRenderer>().material.color = Color.red;

        curGazeTime = 0;
    }

    public void MoveDotPosition()
    {
        dot.transform.position = dotPos[moveNum];
        moveNum++;

        if (moveNum > 12)
        {
            moveNum = 0;
        }
    }
}
