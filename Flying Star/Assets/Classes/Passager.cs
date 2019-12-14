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
    GameObject DreamObj;    
    void Start()
    {
        SetStyle();
    }
    
    void SetStyle()
    {
        int CountTip = Random.Range(1, 3);
        int CountDream = Random.Range(2, 5);
        Hair = HairSet[Random.Range(0, HairSet.Length)];
        Body = BodySet[Random.Range(0, BodySet.Length)];
        Head = HeadSet[Random.Range(0, HeadSet.Length)];
        Pants = PantsSet[Random.Range(0, PantsSet.Length)];
        for (int i = 0;i< Random.Range(4, 7);i++)
        {
            GameObject tip = new GameObject();             
            tip.AddComponent<SpriteRenderer>();
            SpriteRenderer sr = tip.GetComponent<SpriteRenderer>();
            if (i < CountTip)
                sr.sprite = TerrorTipsSet[Random.Range(0, TerrorTipsSet.Length)];
            Instantiate(sr, gameObject.transform);
        }
        for(int i =0;i<CountDream;i++)
            Dreams[i] = DreamSet[Random.Range(0, DreamSet.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
