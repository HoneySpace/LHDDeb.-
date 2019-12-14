using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Passager passager;
    public bool ItTer = false;
    void Start()
    {
        passager.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
