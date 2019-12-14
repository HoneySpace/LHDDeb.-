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
    public static Sprite[] TerrorTipsSet;    
    Sprite Hair, Head,Body,Draem;
    Sprite[] Dreams;
    Sprite[] Tips;  
    GameObject HeadObj, BodyObj, DreamObj;    
    void Start()
    {
        
    }
    
    void SetStyle()
    {
        Hair = HairSet[Random.Range(0, HairSet.Length)];
        Body = BodySet[Random.Range(0, BodySet.Length)];
        Head = HeadSet[Random.Range(0, HeadSet.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
