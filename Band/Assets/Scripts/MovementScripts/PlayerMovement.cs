using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
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


    //Enables movement up, down, left, right
    private void OnEnable()
    {
        upwardMovement.Enable();
        sideMovement.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = sideMovement.ReadValue<float>();
        float verticalInput = upwardMovement.ReadValue<float>();

        //OLD CODE!
        //transform.Translate(sideMovement.ReadValue<float>() * Time.deltaTime * moveAmount, upwardMovement.ReadValue<float>() * Time.deltaTime * moveAmount, 0);

        // Check if there is any input for movement
        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
        {
            // Calculate the direction of movement
            Vector3 movementDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

            // Calculate the new position after movement
            Vector3 newPosition = transform.position + movementDirection * moveAmount;

            // Check if the new position is within the bounds of the grid
            if (IsWithinGridBounds(newPosition))
            {
                // Move the player to the new position
                transform.position = newPosition;
            }
        }
    }

    // Check if the new position is within the bounds of the grid
    bool IsWithinGridBounds(Vector3 position)
    {
        // check if the position is within the grid bounds
        // use size of grid, position of its boundaries, etc.
        // true if position is within bounds, false otherwise
        // right now: assumes bounds are within (-10, -10) to (10, 10)

        float gridSize = 10; // Assuming the grid size is 10x10
        return position.x >= -gridSize && position.x <= gridSize &&
               position.y >= -gridSize && position.y <= gridSize;
    }

    //Handles collisions for encounter and gig squares 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Encounter")
        {
            Debug.Log("Collided!");
            Encounter currentEncounter = collision.gameObject.GetComponent<Encounter>();
            eh.CurrentEncounter(currentEncounter);
            currentEncounter.InactiveEncounter();


            //myEncounter.text = "Encounter # " + collision.gameObject.GetComponent<Square>().GetMyEncounter();
        }
        else if (collision.gameObject.tag == "Gig")
        {
             myGig.text = "Gig # " + collision.gameObject.GetComponent<Square>().GetMyEncounter();
        }

    }
}

  

