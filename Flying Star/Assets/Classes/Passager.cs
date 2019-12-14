using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passager : MonoBehaviour
{
    // Start is called before the first frame update 
    [SerializeField]
    public static Sprite[] HairSet;
    public static Sprite[] BodySet;
    public static Sprite[] HeadSet;
    public static Sprite[] DreamSet;    
    public static Sprite[] TipsSet;
    public static Sprite[] PantsSet;
    public static Sprite[] TerrorTipsSet;    
    Sprite Hair, Head,Body,Draem, Pants;    
    Sprite[] Dreams;
    Sprite[] Tips;
    int order;
    public GameObject DreamObj;   
    public Passager()
    {

    }
    public void SetOrder(int order)
    {
        this.order = order;
        
    }
    void Start()
    {
        SetStyle();
    }    
    void SetStyle()
    {
        int CountTip = Random.Range(4, 7);
        int CountTipTerror = 0;//Random.Range(1, 3);
        int CountDream = Random.Range(2, 5);
        Head = HeadSet[Random.Range(0, HeadSet.Length)];
        CreateSprite(Head);
        Hair = HairSet[Random.Range(0, HairSet.Length)];        
        CreateSprite(Hair);
        Body = BodySet[Random.Range(0, BodySet.Length)];
        CreateSprite(Body);        
        Pants = PantsSet[Random.Range(0, PantsSet.Length)];
        CreateSprite(Pants);
        for (int i = 0;i<CountTip;i++)
        {            
            if (i < CountTipTerror)
                CreateSprite(TerrorTipsSet[Random.Range(0, TerrorTipsSet.Length)]);
            else
            CreateSprite(TipsSet[Random.Range(0, TipsSet.Length)]);            
        }
        //for(int i =0;i<CountDream;i++)
        //    Dreams[i] = DreamSet[Random.Range(0, DreamSet.Length)];
    }
    void CreateSprite(Sprite s)
    {
        GameObject tip = new GameObject();
        tip.transform.parent = gameObject.transform;        
        tip.transform.localScale = new Vector3(1, 1, 1);
        tip.transform.localPosition= new Vector3(0, 0, 0);
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
