using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;

    // Start is called before the first frame update
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerDown() {
        //print(Input.GetTouch(Input.touchCount - 1).position);
        if (Input.GetTouch(Input.touchCount - 1).position.x > 700 || Input.GetTouch(Input.touchCount - 1).position.y > 400)
        {
            //
        }
        else {
            joystick.transform.position = Input.GetTouch(Input.touchCount - 1).position;
            joystickBG.transform.position = Input.GetTouch(Input.touchCount - 1).position;
            joystickTouchPos = Input.GetTouch(Input.touchCount - 1).position;

        }
        
        
        //print(Input.touchCount);

    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData; 
        Vector2 dragPos = pointerEventData.position;
        
        //print(Input.GetTouch(Input.touchCount - 1).position);

        joystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius) { 
            joystick.transform.position = joystickTouchPos + new Vector2(joystickVec.x * joystickDist, 0); 
        }
        else 
            joystick.transform.position = joystickTouchPos + new Vector2(joystickVec.x * joystickRadius, 0); 
    }
    public void PointerUp()
    {
        joystickVec = Vector2.zero; 
        joystick.transform.position = joystickOriginalPos; 
        joystickBG.transform.position = joystickOriginalPos;
    }
    
}
