using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    private bool selected;
    public int currentPosition;
    public int lastPosition;
    private int[] legalMoves;

    public GameObject controller;


    private Vector2 currentMousePos;
    private Vector3 lastLOCATION;
    
    // I don't think this needs to be in awake, but it works for now so we'll leave it here
    void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame < ye no shit
    void Update()
    {
        

        if (Input.GetKeyDown("t"))
        {
        }

        if (selected)
        {
            currentMousePos = getMousePos();
            if (!(currentMousePos.x < 0 || currentMousePos.x > 8 || currentMousePos.y > 0 || currentMousePos.y < -8))
            transform.position = getMousePos();
        }
    }


    //selects this piece when it is clicked on, causing it to follow the cursor until the mouse is released. Its last position is saved
    void OnMouseDown()
    {
        if (controller.GetComponent<Game>().myTurn(tag))
        {
            selected = true;
            lastPosition = getPosition();
            lastLOCATION = transform.position;
        } 
    }

    void hereWeGo()
    {
        currentPosition = getPosition();

        if (!(controller.GetComponent<Game>().gimmeMove(lastPosition, currentPosition)))
        {
            transform.position = lastLOCATION;
            currentPosition = getPosition();
            Debug.Log("BAD NONONO DONT DO THAT SCREW YOU");
        }

    }



    //when mouse is lifted, new position is saved as "currentposition
    //new position is tested. If position is illegal, piece is returned to old position. Otherwise, piece is placed in new position
    //attack test is performed. If an attack was performed, process is continued in "Game" script.
    //piece is unselected
    void OnMouseUp()
    {
        if (selected)
        {
            transform.position = restingPos();
            hereWeGo();
            selected = false;
        }
        
        
        
    }
    
    //gets the mouse position in world coordinates. Also saves position as higher than all other 2d elements for movement purposes
    Vector3 getMousePos()
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePos = (Camera.main.ScreenToWorldPoint(screenPos));

        return new Vector3(mousePos.x, mousePos.y, -0.2f);

    }

    //returns the mouse position as a floor value
    Vector3 restingPos()
    {
        Vector2 mousePos = getMousePos();
        return new Vector3(Mathf.Floor(mousePos.x) + 0.5f, Mathf.Floor(mousePos.y) + 0.5f, -0.1f);
    }

    //determines the square that this piece is resting on.
    int getPosition()
    {
        return Mathf.FloorToInt((-(transform.position.y) - 0.5f) * 8 + transform.position.x - 0.5f);
    }

    //converts from the intiger square value into a vector2 location
    Vector2 numToPos(int squarePos)
    {
        double xCoord = (squarePos % 8) + 0.5;
        double yCoord = -((Mathf.Floor(squarePos / 8)) + 0.5);

        return new Vector2((float)xCoord, (float)yCoord);

    }
    
    public void moveHere(int newSquare)
    {

        lastPosition = getPosition();
        lastLOCATION = transform.position;

        transform.position = numToPos(newSquare);

        hereWeGo();
    }
}
