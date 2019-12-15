using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalAnimator : MonoBehaviour
{
    public float X, Y, Z;   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = new Vector3(X, Y, Z);
    }
}
