/*
Basic Player controller to 2D Point and Click Game
*/
using UnityEngine;

public class PlayerControllerPC2D : MonoBehaviour
{
    [SerializeField] Vector2 target;
    [SerializeField] float speedPlayer;
    
    void Update()
    {
        //Get the coordinates of the mouse position in the screen game
        Vector2 mousePos = Camera.main.ScreenToWorñdPoint(Input.mousePosition);

        //Check if the user do left click and do action
        //0 - Is Left Button
        if(Input.GetMouseButtonDown(0))
        {
            //Only moves in the X axis
            target = new Vector2(mousePos.x, transform.position.y);
            
            //To move in the Y axis
            //target = new Vector2(transform.position.x, mousePos.y);
        }

        //Move the player towards the target coordinates
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speedPlayer);
    }
}