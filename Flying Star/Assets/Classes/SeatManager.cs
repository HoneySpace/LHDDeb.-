using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatManager : MonoBehaviour
{
    public int CountOfSeatsInX, CountOfSeatsInY;
    public GameObject Unit;
    public float dx = 0.5f;
    public float dy = 1f;
    public float space = 1;
    void Awake()
    {        
        int order = -98;
        for(int j=0; j<CountOfSeatsInY;j++)
            for(int i = 0; i < CountOfSeatsInX*2; i++)
            {
                GameObject go;
                if (i < CountOfSeatsInX)
                {
                    go = Instantiate(Unit, new Vector3(i * dx, j * dy, 0), new Quaternion(), gameObject.transform);
                    go.transform.localPosition = new Vector3(-space/2 -i * dx, j * dy, 0);
                }
                else
                {
                    go = Instantiate(Unit, new Vector3(i * dx, j * dy, 0), new Quaternion(), gameObject.transform);
                    go.transform.localPosition = new Vector3(space/2 + (i- CountOfSeatsInX) * dx, j * dy, 0);
                }                
                Passager p = Unit.GetComponent<Passager>();
                p.SetOrder(order);
                order++;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
