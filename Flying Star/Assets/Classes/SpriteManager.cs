using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Sprite[] HairSet;
    public Sprite[] BodySet;
    public Sprite[] HeadSet;
    public Sprite[] DreamSet;
    public Sprite[] TipsSet;
    public Sprite[] PantsSet;
    // Start is called before the first frame update
    private void Awake()
    {
        Passager.BodySet = BodySet;
        Passager.HeadSet = HeadSet;
        Passager.HairSet = HeadSet;
        Passager.DreamSet = DreamSet;        
        Passager.TipsSet = TipsSet;
        Passager.PantsSet = PantsSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
