using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour
{
    public Text text;
    public Animator[] Gays;
    public Animator SceneHandler;
    List<string[]> Speachs = new List<string[]>();
    int[] Count=new int[2];
    public string[] SpeachOne;
    public string[] SpeachTwo;
    int turn=0;
    int[] CountTurn=new int[2];
    int i = 0;
    int Turn
    {
        get { return turn; }
        set
        {
            if (value > 1) turn = 0;
            else
            if (value < 0) turn = 1;
            else turn = value;
        }
    }
    void Start()
    {
        Speachs.Add(SpeachOne);
        Speachs.Add(SpeachTwo);
        Count[0] = SpeachOne.Length;
        Count[1] = SpeachTwo.Length;
        CountTurn[0] = 0;
        CountTurn[1] = 0;
        Print();        
    }
     
    void Print()
    {
        bool typed = false;
        Turn++;
        if(CountTurn[0]!=0) Gays[Turn].SetTrigger("Back");
        Turn++;
        text.text = string.Empty;
        Gays[Turn].SetTrigger("ToCentre");
        if (CountTurn[Turn]<Count[Turn])
        {
            text.text = Speachs[Turn][CountTurn[Turn]];
            CountTurn[Turn]++;
            typed = true;
        }
        Turn++;
        if (typed) Invoke("Print", 3);
        else SceneHandler.SetTrigger("Next");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
