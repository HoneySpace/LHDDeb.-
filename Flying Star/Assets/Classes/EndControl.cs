using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndControl : MonoBehaviour
{
    public Sprite[] bg = new Sprite[2];
    public GameObject BadGay;
    public GameObject[] DSys = new GameObject[2];
    public GameObject[] img = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        if (EndPoint.GoodEnd)
        {
            img[0].SetActive(true);
            BadGay.GetComponent<Image>().sprite = bg[0];
            DSys[0].GetComponent<DialogSystem>().Gays[0] = BadGay.GetComponent<Animator>();
            DSys[0].SetActive(true);
        }
        else
        {
            img[1].SetActive(true);
            BadGay.GetComponent<Image>().sprite = bg[1];
            DSys[1].GetComponent<DialogSystem>().Gays[0] = BadGay.GetComponent<Animator>();
            DSys[1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
