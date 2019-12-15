using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Passager passager;
    public static List<MissingInfo> MisingInfoSet = new List<MissingInfo>();
    [SerializeField]
    public MissingInfo missingInfo = new MissingInfo();
    public bool ItTer = false;
    Animator anim;
    public float Sense = 3;
    State state=State.Stay;
    enum State
    {
        Scarry, Stay
    }
    void Start()
    {
        passager.Start();
        anim = GetComponentInChildren<Animator>();
    }
    public void AddToNote()
    {
        if(!missingInfo.WasMantioned)
        {
            GameControl.Pop();
            missingInfo.WasMantioned = true;
            SeatManager.MentionedTip.Add(missingInfo.Tip.name);
            SeatManager.UpadateText();
            Handheld.Vibrate();
            anim.SetTrigger("Stay");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (missingInfo.Tip != null && !missingInfo.WasMantioned)
            if (Vector3.Distance(gameObject.transform.position, Player.Pos) < Sense)
            {
                if (state == State.Stay)
                {
                    state = State.Scarry;
                    anim.SetTrigger("Scarry");                    
                }
            }
            else
            {
                if (state == State.Scarry)
                {
                    state = State.Stay;
                    anim.SetTrigger("Stay");
                }
            }
    }
}
