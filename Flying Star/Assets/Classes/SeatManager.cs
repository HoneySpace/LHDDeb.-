using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatManager : MonoBehaviour
{
    public int CountOfSeatsInX, CountOfSeatsInY;
    public GameObject unit;
    public GameObject floor;
    static Passager[] passagers;
    public float dx = 0.5f;
    public float dy = 1f;
    public float space = 1;
    public static int Index;
    public static List<string> MentionedTip = new List<string>();
    public List<Unit> units = new List<Unit>();
    int count;
    public static Text Discription;
    void Awake()
    {
        Discription = GameObject.Find("Discript").GetComponent<Text>();
        Index =Random.Range(0, CountOfSeatsInX * 2 * CountOfSeatsInY);
        Debug.Log($"Terr:{Index}");
        passagers = new Passager[CountOfSeatsInX * 2 * CountOfSeatsInY];
        passagers[Index] = new Passager(true);
        for (int j = 0; j < CountOfSeatsInY; j++)
        {
            for (int i = 0; i < CountOfSeatsInX * 2; i++)
            {
                GameObject go;
                if (i < CountOfSeatsInX)
                {
                    go = Instantiate(unit, new Vector3(i * dx, j * dy, 0), new Quaternion(), gameObject.transform);
                    go.transform.localPosition = new Vector3(-space / 2 - i * dx, j * dy, 0);
                }
                else
                {
                    go = Instantiate(unit, new Vector3(i * dx, j * dy, 0), new Quaternion(), gameObject.transform);
                    go.transform.localPosition = new Vector3(space / 2 + (i - CountOfSeatsInX) * dx, j * dy, 0);
                }
                Unit holder = go.GetComponent<Unit>();
                units.Add(holder);
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
            if(j % 3 == 0)
                Instantiate(floor, new Vector3(0, j * dy, 0), new Quaternion(), gameObject.transform);
        }
    }
    private void Start()
    {
        StartCoroutine("StartInfo");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
    public static void UpadateText()
    {
        List<string> Tips = new List<string>();
        foreach (string tip in MentionedTip)
        {            
            string[] s = tip.Split(' ');
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
    IEnumerator StartInfo()
    {
        yield return new WaitForEndOfFrame();
        List<string> Tips = new List<string>();
        foreach (Sprite sprite in Passager.TerrorTipsSet)
        {
            if (Random.Range(0, 100) > 59)
            {
                MentionedTip.Add(sprite.name);
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
            else
                Unit.MisingInfoSet.Add(new MissingInfo(sprite));
        } 
        for(int i=0;i<Unit.MisingInfoSet.Count;i++)
        {
            int number = ReturnNumber();
            Debug.Log(number);
            units[number].missingInfo = Unit.MisingInfoSet[i];
        }
        Discription.text = "";
        foreach (string s in Tips)
            Discription.text += s;
    }
    int ReturnNumber()
    {
        int output = Random.Range(0, units.Count);
        if (output == Index) output = ReturnNumber();
        return output;
    }
}
