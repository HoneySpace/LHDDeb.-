using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Vector3 Pos;
    Vector3 LastP, StartP;
    public float Multy;
    public Canvas Inter;
    public float Sensetivity;
    public static bool CanMove = true;
    public static bool ChoosenTer = false;
    public float TouchSense;
    public GameObject Choice;
    bool flag=true;
    Animator animator;
    static interPosition InterPos=interPosition.Centre;
    // Start is called before the first frame update
    void Start()
    {
        animator = Inter.GetComponentInChildren<Detector>().gameObject.GetComponentInChildren<Animator>();
    }
          
    enum interPosition
    {
        Left, Centre, Right
    }   
    public void ToLeft()
    {
        Inter.GetComponentInChildren<Button>().gameObject.active = false;
        flag = false;
        animator.SetTrigger("ToLeft");
        InterPos = interPosition.Left;
    }
    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            Pos = gameObject.transform.position;
            if (GameControl.State == GameControl.GameState.Playing)
            {
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    StartP = Input.touches[0].position;
                }
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
                {
                    Vector3 DeltaY = Camera.main.ViewportToWorldPoint(Input.touches[0].position) - Camera.main.ViewportToWorldPoint(StartP);
                    gameObject.transform.Translate(DeltaY * Multy);
                    gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, 0);
                }
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
                {
                    Vector3 DeltaX = Camera.main.ViewportToWorldPoint(Input.touches[0].position) - Camera.main.ViewportToWorldPoint(StartP);
                    if (Mathf.Abs(DeltaX.x) > Sensetivity)
                    {
                        if (flag)
                        {
                            Inter.GetComponentInChildren<Button>().gameObject.active = false;
                            flag = false;
                        }
                        if (InterPos == interPosition.Centre)
                            if (DeltaX.x < 0)
                            {
                                animator.SetTrigger("ToLeft");
                                InterPos = interPosition.Left;
                            }
                            else
                            {
                                animator.SetTrigger("ToRight");
                                InterPos = interPosition.Right;
                            }
                        else
                        if (InterPos == interPosition.Right)
                            if (DeltaX.x < 0)
                            {
                                animator.SetTrigger("FromRight");
                                InterPos = interPosition.Centre;
                            }
                            else
                            {
                                animator.SetTrigger("FromLeft");
                                InterPos = interPosition.Centre;
                            }
                        else
                        if (InterPos == interPosition.Left)
                            if (DeltaX.x > 0)
                            {
                                animator.SetTrigger("FromLeft");
                                InterPos = interPosition.Centre;
                            }
                            else
                            {
                                animator.SetTrigger("FromRight");
                                InterPos = interPosition.Centre;
                            }
                    }
                }
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
                {
                    Vector3 DeltaY = Camera.main.ViewportToWorldPoint(Input.touches[0].position) - Camera.main.ViewportToWorldPoint(StartP);
                    if (Mathf.Abs(DeltaY.y) < TouchSense)
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                        RaycastHit Hit;
                        Physics.Raycast(ray, out Hit, 100, LayerMask.GetMask("Default"));
                        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Vector3.forward);
                        if (Hit.collider != null)
                        {
                            {
                                Debug.Log(Hit.collider.name);
                                Unit unit = Hit.collider.gameObject.GetComponent<Unit>();
                                if (unit.Scarred)
                                {
                                    if (unit.missingInfo.Tip != null) unit.AddToNote();
                                }
                                else
                                {
                                    ChoosenTer = unit.ItTer;
                                    CanMove = false;
                                    Choice.SetActive(true);
                                }

                            }
                        }
                        Debug.Log("Touch");
                    }
                }
            }
        }
    }
}
