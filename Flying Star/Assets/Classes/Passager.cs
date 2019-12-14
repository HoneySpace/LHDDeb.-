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
            CreateSprite(Head);
            Hair = HairSet[Random.Range(0, HairSet.Length)];
            CreateSprite(Hair);
            Body = BodySet[Random.Range(0, BodySet.Length)];
            CreateSprite(Body);
            Pants = PantsSet[Random.Range(0, PantsSet.Length)];
            CreateSprite(Pants);
            for (int i = 0; i < CountTip; i++)
            {
                if (i < CountTipTerror)
                    CreateSprite(TerrorTipsSet[Random.Range(0, TerrorTipsSet.Length)]);
                else
                    CreateSprite(TipsSet[Random.Range(0, TipsSet.Length)]);
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
            CreateSprite(Head);
            Hair = HairSet[Random.Range(0, HairSet.Length)];
            CreateSprite(Hair);
            Pants = PantsSet[Random.Range(0, PantsSet.Length)];
            CreateSprite(Pants);
            Body = BodySet[Random.Range(0, BodySet.Length)];
            CreateSprite(Body);
            TerrorTipsSet = new Sprite[4 + CountTip];
            TerrorTipsSet[0] = Head;
            TerrorTipsSet[1] = Hair;
            TerrorTipsSet[2] = Body;
            TerrorTipsSet[3] = Pants;
            for (int i = 0; i < CountTip; i++)
            {
                Sprite s = TipsSet[Random.Range(0, TipsSet.Length)];
                CreateSprite(s);
                TerrorTipsSet[4 + i] = s;
            }
            //for(int i =0;i<CountDream;i++)
            //    Dreams[i] = DreamSet[Random.Range(0, DreamSet.Length)];
        }
    }
    void CreateSprite(Sprite s)
    {
        GameObject tip = new GameObject();
        tip.transform.parent = Holder.gameObject.transform;
        tip.transform.localScale = new Vector3(1, 1, 1);
        tip.transform.localPosition = new Vector3(0, 0, 0);
        tip.AddComponent<SpriteRenderer>();
        SpriteRenderer sr = tip.GetComponent<SpriteRenderer>();
        sr.sprite = s;
        sr.sortingOrder = thatOrder;
    }


    // Update is called once per frame
    void Update()
    {


    }
}
