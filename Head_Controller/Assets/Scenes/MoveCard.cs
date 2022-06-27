using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCard : MonoBehaviour
{
    //[SerializeField] private Button startBtn;
    [SerializeField] private GameObject gazePointer;
    [SerializeField] private GameObject card;
    [SerializeField] private Material origin;
    //[SerializeField] private Material gaze;

    private Vector3 startPos;       // cam start position
    private Vector3 startCardPos;   // card start position

    private float posX;     // card's position.x
    private float posY;     // card's position.y
    private float posZ;     // card's position.z

    private float startX;   // cam start rotation angle X
    private float startY;   // cam start rotation angle Y
    private float angleY;   // cam rotation angle Y
    private float cardY;


    void Awake()
    {
        GetComponent<MoveCard>().enabled = false;
    }

    void Start()
    {
        startPos = Camera.main.transform.position;

        startX = Camera.main.transform.rotation.eulerAngles.x;
        startY = Camera.main.transform.rotation.eulerAngles.y;

        posX = 2 * Mathf.Sin(Mathf.Deg2Rad * startY);
        posY = -2 * Mathf.Sin(Mathf.Deg2Rad * startX);
        posZ = 2 * Mathf.Cos(Mathf.Deg2Rad * startY);
        

        startCardPos = startPos + new Vector3(posX, posY, posZ);
        card.transform.position = startCardPos;
    }

    // Update is called once per frame
    void Update()
    {
        card.transform.LookAt(Camera.main.transform);

        angleY = Camera.main.transform.rotation.eulerAngles.y;
        cardY = 2 * startY - angleY;

        MoveCardPosition();
        PlaySound();

        if (Vector3.Distance(gazePointer.transform.position, card.transform.position) <= 0.1f)
        {
            card.transform.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            card.transform.GetComponent<MeshRenderer>().material = origin;
        }
    }

    void MoveCardPosition()
    {
        posX = startPos.x + (2 * Mathf.Sin(Mathf.Deg2Rad * cardY));
        posZ = startPos.z + (2 * Mathf.Cos(Mathf.Deg2Rad * cardY));

        gazePointer.transform.position = new Vector3(gazePointer.transform.position.x, gazePointer.transform.position.y, posZ);
        card.transform.position = new Vector3(posX, startCardPos.y, posZ);

        //Debug.Log("gaze position : " + gazePointer.transform.position);
    }

    void PlaySound()
    {
        float distance = Vector3.Distance(startCardPos, card.transform.position);

        Debug.Log("distance : " + distance);
        //Debug.Log("card position.x : " + posX);
        if (distance <= 0.3f && distance >= -0.3f)
        {
            Camera.main.GetComponent<AudioSource>().Play();

            Debug.Log("play" + (startY - angleY));
        }
    }
}
