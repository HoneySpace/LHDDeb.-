using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public enum GameState
    {
        Reading=0,
        Playing=1
    }
    GameState State = GameState.Reading;
    // Start is called before the first frame update
    void Start()
    {
        
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
