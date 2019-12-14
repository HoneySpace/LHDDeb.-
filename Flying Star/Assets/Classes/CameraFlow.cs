using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public float distans = 4;
    public GameObject Traget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Traget.transform.position + new Vector3(0, distans,-10);
        //gameObject.transform.position;
    }
}
