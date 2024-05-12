using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputAction upwardMovement;

    [SerializeField]
    private InputAction sideMovement;

    [SerializeField]
    private float moveAmount;

    [SerializeField]
    private TMP_Text myEncounter;

    [SerializeField]
    private TMP_Text myGig;

    [SerializeField]
    private EncounterHandler eh;

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
