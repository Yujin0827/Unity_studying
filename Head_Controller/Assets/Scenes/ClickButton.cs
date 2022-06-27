using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private GameObject card;
    [SerializeField] private GameObject targetManager;
    

    // Start is called before the first frame update
    void Start()
    {
        startBtn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click()
    {
        GameObject.Find("Right Ray Interactor").SetActive(false);

        targetManager.GetComponent<MoveCard>().enabled = true;
        Debug.Log("card position: " + card.transform.position);
    }
}
