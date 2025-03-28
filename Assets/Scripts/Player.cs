using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask layer;
    private Vector3  startTouch , ActualPosition , swipeDelta;
    public bool swipeLeft , swipeRight , swipeDown , swipeUp ;
    float sqrDeadZone = 1f;
    GameObject ThePIin;
    public bool RunGame;

    void Start()
    {
        RunGame = true;
    }
    
    void Update()
    {
        if (!RunGame)
        {
            return;
        }

        swipeLeft = swipeRight = swipeDown = swipeUp = false;
        
        if (Input.GetMouseButton(0))
        {
            ActualPosionDetect();
        }
        if (Input.GetMouseButtonDown(0))
        {
            ClickPositionDetect();
        }
        if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector3.zero;
        }
        
        DetectDirection();
        //Debug.DrawRay(cam.transform.position , Input.mousePosition , Color.red);
        controlePinMovement();
    }

    void ActualPosionDetect()
    {
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer)){
            ActualPosition = hit.point;
            ThePIin = hit.collider.gameObject;
        }
    }

    void ClickPositionDetect()
    {
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            startTouch = hit.point;
        }
    }


    void DetectDirection()
    {
        // reset distance , get the new swipedelta
        swipeDelta = Vector3.zero;
        if (startTouch != Vector3.zero && Input.GetMouseButton(0))
        {
            swipeDelta = ActualPosition - startTouch;
        }
        
        //checking if our delta is beyond deadzone
        //print(swipeDelta.sqrMagnitude);
        if (swipeDelta.sqrMagnitude > sqrDeadZone)
        {
            //we're beyond a deadzone , this is a swipe 
            // now we need to figure out in which direction it goes

            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //up or down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
            startTouch = swipeDelta = Vector2.zero;
        }
    }

    void controlePinMovement()
    {
        if (swipeRight)
        {
            if (ThePIin != null && ThePIin.GetComponent<Pin>().Name == "right")
            {
                ThePIin.GetComponent<Pin>().MovePin = true;
                if (GameManager.instant.getSound() == 1)
                {
                    SoundManager.instance.Play("pull");
                }
            }
        }
        else if (swipeLeft)
        {
            if (ThePIin != null && ThePIin.GetComponent<Pin>().Name == "left")
            {
                ThePIin.GetComponent<Pin>().MovePin = true;
                if (GameManager.instant.getSound() == 1)
                {
                    SoundManager.instance.Play("pull");
                }
            }
        }
        else if (swipeUp)
        {
            if (ThePIin != null && ThePIin.GetComponent<Pin>().Name == "up")
            {
                ThePIin.GetComponent<Pin>().MovePin = true;
                if (GameManager.instant.getSound() == 1)
                {
                    SoundManager.instance.Play("pull");
                }
            }
        }
        else if (swipeDown)
        {
            if (ThePIin != null && ThePIin.GetComponent<Pin>().Name == "down")
            {
                ThePIin.GetComponent<Pin>().MovePin = true;
                if (GameManager.instant.getSound() == 1)
                {
                    SoundManager.instance.Play("pull");
                }
            }
        }
    }
}
