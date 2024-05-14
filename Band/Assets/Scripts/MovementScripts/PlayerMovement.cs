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
        transform.Translate(sideMovement.ReadValue<float>() * Time.deltaTime * moveAmount, upwardMovement.ReadValue<float>() * Time.deltaTime * moveAmount, 0);
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
        }else if (collision.gameObject.tag == "Gig")
        {
            myGig.text = "Gig # " + collision.gameObject.GetComponent<Square>().GetMyEncounter();
        }
    }


}
