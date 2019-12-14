using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatManager : MonoBehaviour
{
    public int CountOfSeatsInX, CountOfSeatsInY;
    public GameObject Unit;
    public float dx = 0.5f;
    public float dy = 1f;
    void Start()
    {        
        int order = -98;
        for(int j=0; j<CountOfSeatsInY;j++)
            for(int i = 0; i < CountOfSeatsInX; i++)
            {                
                Passager p= Unit.GetComponent<Passager>();
                p = new Passager(order);
                Instantiate(Unit, new Vector3(i*dx, j * dy, 0),new Quaternion(),gameObject.transform);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
