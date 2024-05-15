using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private List<GameObject> moveablePlaces = new List<GameObject>();

    private List<GameObject> availableSquares = new List<GameObject>();

    [SerializeField]
    private InputAction upwardMovement;//A set of inputs for moving upward and downward

    [SerializeField]
    private InputAction sideMovement;//A set of inputs for moving left and right

    [SerializeField]
    private float moveAmount;//The force to move by 

    [SerializeField]
    private TMP_Text myEncounter;//A deprecated script 

    [SerializeField]
    private TMP_Text myGig;//Deprecated

    [SerializeField]
    private EncounterHandler eh;//Responsible for hiding and showing encounters found by player

    [SerializeField]
    private Vector2 startPosition;//The starting place for player


    [SerializeField]
    private Vector2 lowerPos;//Acts as the lower x and y bound of the grid

    [SerializeField]
    private Vector2 upperPos;//Acts as the upper x and y bound of the grid

    [SerializeField]
    private float delayTime;//Delays game 

    [SerializeField]
    private int encounterMoneyDeduction;//Decrements the money for encounters

    private void Start()
    {
        transform.position = startPosition;
        Debug.Log(moveablePlaces.Count);
    }
    //Enables movement up, down, left, right
    public void OnEnable()
    {
        upwardMovement.Enable();
        sideMovement.Enable();
    }

    public void OnDisable()
    {
        upwardMovement.Disable();
        sideMovement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = sideMovement.ReadValue<float>();
        float verticalInput = upwardMovement.ReadValue<float>();
        CheckForAvailableSquares();
        //OLD CODE!
        //transform.Translate(sideMovement.ReadValue<float>() * Time.deltaTime * moveAmount, upwardMovement.ReadValue<float>() * Time.deltaTime * moveAmount, 0);

        // Check if there is any input for movement
        if (sideMovement.ReadValue<float>() > 0)
        {
            StartCoroutine(DelayMove(ReturnClosestXAboveSquare().transform.position));
            EraseAvailableSquares();
        }
        else if (sideMovement.ReadValue<float>() < 0)
        {
            
            StartCoroutine(DelayMove(ReturnClosestXBelowSquare().transform.position));
            EraseAvailableSquares();
        }

        if(upwardMovement.ReadValue<float>() > 0){
            
            StartCoroutine(DelayMove(ReturnClosestYAboveSquare().transform.position));
            EraseAvailableSquares();

        }
        else if (upwardMovement.ReadValue<float>() < 0)
        {
            StartCoroutine(DelayMove(ReturnClosestYBelowSquare().transform.position));
            EraseAvailableSquares();
        }
          
            //Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;
            // Calculate the new position after movement
            
           /* // Check if the new position is within the bounds of the grid
            if (IsWithinGridBounds(newPosition))
            {
                // Move the player to the new position
                
            }

            */
        
    }

    // Check if the new position is within the bounds of the grid
    bool IsWithinGridBounds(Vector3 position)
    {
        // check if the position is within the grid bounds
        // use size of grid, position of its boundaries, etc.
        // true if position is within bounds, false otherwise
        // right now: assumes bounds are within (-10, -10) to (10, 10)

        //float gridSize = 10; // Assuming the grid size is 10x10
        return position.x >= lowerPos.x && position.x <= upperPos.x &&
               position.y >= lowerPos.y && position.y <= upperPos.y;
    }

    //Adds available squares
    private void CheckForAvailableSquares()
    {
        foreach(GameObject g in moveablePlaces)
        {
            if(Mathf.Abs((Vector2.Distance(transform.position, g.transform.position))) < moveAmount)
            {
                availableSquares.Add(g);
                
            }

        }
    }

    //Determines what is the closest square below the square
    private GameObject ReturnClosestYBelowSquare()
    {
        
        GameObject smallestDist = availableSquares[0];

        foreach (GameObject place in availableSquares)
        {
            if (place.transform.position.y == transform.position.y)
            {
                continue;
            }
            else if(place.transform.position.y < transform.position.y && place.transform.position.x == transform.position.x)
            {
                return place;
            }
        }

        return smallestDist;
    }

    //Determines the closest square above the player
    private GameObject ReturnClosestYAboveSquare()
    {
        
        GameObject smallestDist = availableSquares[0];

        foreach (GameObject place in availableSquares)
        {
            if (place.transform.position.y == transform.position.y)
            {
                continue;
            }
            else if (place.transform.position.y > transform.position.y && place.transform.position.x == transform.position.x)
            {
                return place;
            }
        }


        return smallestDist;
    }

    //Determines the closest square to the left of the player
    private GameObject ReturnClosestXBelowSquare()
    {
        
        GameObject smallestDist = availableSquares[0];

        foreach (GameObject place in availableSquares)
        {
            if (place.transform.position.x == transform.position.x)
            {
                continue;
            }
            else if (place.transform.position.x < transform.position.x && place.transform.position.y == transform.position.y)
            {
                return place;
            }
        }

        return smallestDist;
    }

    //Determines the closest square to the right of the player 
    private GameObject ReturnClosestXAboveSquare()
    {
        
        GameObject smallestDist = availableSquares[0];

        foreach (GameObject place in availableSquares)
        {
            if (place.transform.position.x == transform.position.x)
            {
                continue;
            }
            else if (place.transform.position.x > transform.position.x && place.transform.position.y == transform.position.y)
            {
                return place;
            }
        }
        return smallestDist;
    }


    //Resets available squares
    private void EraseAvailableSquares()
    {
        availableSquares.Clear();
    }

    //Retrieves moveable squares from the Square Spawner
    public void AddMoveableSquare(GameObject s)
    {
        moveablePlaces.Add(s);
    }

    //Handles collisions for encounter and gig squares 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Encounter")
        {
            Encounter currentEncounter = collision.gameObject.GetComponent<Encounter>();
            eh.CurrentEncounter(currentEncounter);
            currentEncounter.InactiveEncounter();
            GameStateManager.SetMoney(encounterMoneyDeduction);
            OnDisable();


            //myEncounter.text = "Encounter # " + collision.gameObject.GetComponent<Square>().GetMyEncounter();
        }
        else if (collision.gameObject.tag == "Gig")
        {
             myGig.text = "Gig # " + collision.gameObject.GetComponent<Square>().GetMyEncounter();
            GameStateManager.SetMoney(encounterMoneyDeduction * 2);
        }else if(collision.gameObject.tag == "Empty" || collision.gameObject.tag == "Inactive")
        {
            GameStateManager.SetMoney(encounterMoneyDeduction);
        }
        

    }

    //Delays Movement
    private IEnumerator DelayMove(Vector3 position)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.transform.position = position;


    }
}

  

