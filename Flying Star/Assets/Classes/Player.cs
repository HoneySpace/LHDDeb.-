using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 LastP, StartP;
    public float Multy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            StartP = Input.touches[0].position;
        }
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            Vector3 DeltaY = Camera.main.ViewportToWorldPoint(new Vector3(0,Input.touches[0].position.y - StartP.y,0));
            gameObject.transform.Translate(DeltaY*Multy);
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, 0);
        }
        
    }
}
