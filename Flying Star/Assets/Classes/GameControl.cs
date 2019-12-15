using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{    
    public enum GameState
    {
        Reading=0,
        Playing=1
    }
    public static GameState State = GameState.Playing;
    public static Animator anim;
    static Animator Victory;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GameObject.Find("NewTip").GetComponent<Animator>();
        Victory = GameObject.Find("VictoryTip").GetComponent<Animator>();
    }    
    public void SetPlaying()
    {            
        State = GameState.Playing;
    }
    public static void Victrory()
    {
        Victory.SetTrigger("Win");
    }
    public static void Pop()
    {
        anim.SetTrigger("Pop");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
