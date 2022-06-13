using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLine : MonoBehaviour
{
    LineRenderer l;
    Vector3 startPos, cube;

    
    IEnumerator ShowHideCube()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            l.enabled = true;
            yield return new WaitForSeconds(3);
            l.enabled = false;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        l = GetComponent<LineRenderer>();

        //startPos = new Vector3(0, 0.9f, -4);
        startPos = gameObject.transform.position - new Vector3(0, 0.1f, 0);
        Debug.Log($"startPos: {startPos}");

        StartCoroutine(ShowHideCube());
    }

    // Update is called once per frame
    void Update()
    {
        l.SetPosition(0, startPos);
        l.SetPosition(1, GameObject.Find("Cube").GetComponent<Transform>().position);
    }


}