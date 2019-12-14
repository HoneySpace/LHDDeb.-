using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text Discription;
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
                    holder.ItTer = true;
                    passagers[Index].SetHolder(holder);
                }
                count++;
            }        
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        List<string> Tips = new List<string>();
        foreach (Sprite sprite in Passager.TerrorTipsSet)
        {
            string[] s = sprite.name.Split(' ');
            for (int i = 0; i < s.Length; i++)
                if (
                    s[i] != "Girl"
                    &&
                    s[i] != "Men"
                    &&
                    s[i] != "Tip"
                    &&
                    s[i] != "Body"
                    &&
                    s[i] != "Head"
                  )
                {
                    Tips.Add(s[i]);
                    Tips.Add(" ");
                }
        }
        Discription.text = "";
        foreach (string s in Tips)
            Discription.text += s;
    }
   
}
