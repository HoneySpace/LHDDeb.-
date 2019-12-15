using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public float Min=3;
    public GameObject choice;
    public static float Timee;
    public enum GameState
    {
        Reading=0,
        Playing=1
    }
    public static GameState State = GameState.Playing;
    static public Animator Stage;
    public static Animator anim;
    static Animator Victory;
    // Start is called before the first frame update
    void Awake()
    {
        Timee = 1000 * Min;
        Stage = GameObject.Find("Canvas").GetComponent<Animator>();
        anim = GameObject.Find("NewTip").GetComponent<Animator>();
        Victory = GameObject.Find("VictoryTip").GetComponent<Animator>();
    }    
    public void SetPlaying()
    {            
        State = GameState.Playing;
    }
    public static void SetBadEnd()
    {
        EndPoint.GoodEnd = false;
        Stage.SetTrigger("Next");
    }
    public static void SetGoodEnd()
    {
        EndPoint.GoodEnd = true;
        Stage.SetTrigger("Next");
    }
    public void Catch()
    {
        if (Player.ChoosenTer)
            SetGoodEnd();
        else SetBadEnd();
        choice.SetActive(false);
    }
    public void Leave()
    {
        Player.CanMove = true;
        choice.SetActive(false);
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
    IEnumerator Timeer()
    {
        yield return new WaitForSeconds(1000);
        Timee--;
        if (Timee == 0) SetBadEnd();
    }
}
