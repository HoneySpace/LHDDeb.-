using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatManager : MonoBehaviour
{
    public int CountOfSeatsInX, CountOfSeatsInY;
    public GameObject Unit;
    static Passager[] passagers;
    public float dx = 0.5f;
    public float dy = 1f;
    public float space = 1;
    public static int Index;
    int count;
    void Awake()
    {
        Index =Random.Range(0, CountOfSeatsInX * 2 * CountOfSeatsInY);
        passagers = new Passager[CountOfSeatsInX * 2 * CountOfSeatsInY];
        passagers[Index] = new Passager(true);
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
                Unit holder = go.GetComponent<Unit>();
                if (count != Index)
                {
                    passagers[count] = new Passager(holder, false);
                    holder.passager = passagers[count];
                }
                else
                {
                    holder.passager = passagers[Index];
                    passagers[Index].SetHolder(holder);
                }
                count++;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
