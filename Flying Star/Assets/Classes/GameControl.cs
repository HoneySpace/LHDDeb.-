using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public Canvas Interface;
    public enum GameState
    {
        Reading=0,
        Playing=1
    }
    public static GameState State = GameState.Reading;
    // Start is called before the first frame update
    void Start()
    {
        
    }    
    public void SetPlaying()
    {
        Interface.enabled = false;        
        State = GameState.Playing;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
