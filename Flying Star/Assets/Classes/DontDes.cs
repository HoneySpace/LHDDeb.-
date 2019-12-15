using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDes : MonoBehaviour
{
    static DontDes inst = null;
    public static  DontDes Inst { get { return inst; } }
    private void Awake()
    {
        if(inst != null && inst != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
