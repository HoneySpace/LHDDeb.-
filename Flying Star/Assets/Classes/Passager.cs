using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passager : MonoBehaviour
{
    // Start is called before the first frame update 
    [SerializeField]
    Unit Holder;
    public static Sprite[] HairSet;
    public static Sprite[] BodySet;
    public static Sprite[] HeadSet;
    public static Sprite[] DreamSet;
    public static Sprite[] TipsSet;
    public static Sprite[] PantsSet;
    public static Sprite[] TerrorTipsSet;
    public bool CreateTerror = false;
    Sprite Hair, Head, Body, Draem, Pants;
    Sprite[] Dreams;
    Sprite[] Tips;
    static int Number;
    static int order = 100;
    int thatOrder;
    public GameObject DreamObj;
    public Passager(Unit holdr, bool create)
    {
        Holder = holdr;
        CreateTerror = create;
    }
    public Passager(bool create)
    {
        CreateTerror = create;
    }
    public static void SetOrder(int orde)
    {
        order = orde;
    }
    public void Start()
    {
        thatOrder = order--;
        SetStyle();
        Number++;
    }
    public void SetHolder(Unit holdr)
    {
        Holder = holdr;
    }
    void SetStyle()
    {
        if (!CreateTerror)
        {
            int CountTip = Random.Range(4, 7);
            int CountTipTerror = 0;// Random.Range(1, 3);
            int CountDream = Random.Range(2, 5);
            Head = HeadSet[Random.Range(0, HeadSet.Length)];
            CreateSprite(Head,thatOrder-2);
            Hair = HairSet[Random.Range(0, HairSet.Length)];
            CreateSprite(Hair, thatOrder - 1);
            Body = BodySet[Random.Range(0, BodySet.Length)];
            CreateSprite(Body, thatOrder - 1);
            Pants = PantsSet[Random.Range(0, PantsSet.Length)];
            CreateSprite(Pants, thatOrder - 1);
            for (int i = 0; i < CountTip; i++)
            {
                if (i < CountTipTerror)
                    CreateSprite(TerrorTipsSet[Random.Range(0, TerrorTipsSet.Length)], thatOrder);
                else
                    CreateSprite(TipsSet[Random.Range(0, TipsSet.Length)], thatOrder);
            }
            //for(int i =0;i<CountDream;i++)
            //    Dreams[i] = DreamSet[Random.Range(0, DreamSet.Length)];
        }
        else
        {
            int CountTip = Random.Range(4, 7);
            int CountTipTerror = Random.Range(1, 3);
            int CountDream = Random.Range(2, 5);
            Head = HeadSet[Random.Range(0, HeadSet.Length)];
            CreateSprite(Head,thatOrder-2);
            Hair = HairSet[Random.Range(0, HairSet.Length)];
            CreateSprite(Hair,thatOrder-1);
            Pants = PantsSet[Random.Range(0, PantsSet.Length)];
            CreateSprite(Pants,thatOrder-1);
            Body = BodySet[Random.Range(0, BodySet.Length)];
            CreateSprite(Body,thatOrder-1);
            TerrorTipsSet = new Sprite[4 + CountTip];
            TerrorTipsSet[0] = Head;
            TerrorTipsSet[1] = Hair;
            TerrorTipsSet[2] = Body;
            TerrorTipsSet[3] = Pants;
            for (int i = 0; i < CountTip; i++)
            {
                Sprite s = TipsSet[Random.Range(0, TipsSet.Length)];
                CreateSprite(s,thatOrder);
                TerrorTipsSet[4 + i] = s;
            }
            //for(int i =0;i<CountDream;i++)
            //    Dreams[i] = DreamSet[Random.Range(0, DreamSet.Length)];
        }
    }
    void CreateSprite(Sprite s,int order)
    {
        GameObject tip = new GameObject();
        tip.transform.parent = Holder.gameObject.GetComponentInChildren<Detector>().gameObject.transform;
        tip.transform.localScale = new Vector3(1, 1, 1);
        tip.transform.localPosition = new Vector3(0, 0, 0);
        tip.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = tip.GetComponent<SpriteRenderer>();
        sr.sprite = s;
        sr.sortingOrder = order;
    }


    // Update is called once per frame
    void Update()
    {


    }
}
