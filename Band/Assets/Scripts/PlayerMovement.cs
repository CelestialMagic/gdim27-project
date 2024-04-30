using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private InputAction upwardMovement;

    [SerializeField]
    private InputAction sideMovement;

    [SerializeField]
    private float moveAmount;


    private void OnEnable()
    {
        upwardMovement.Enable();
        sideMovement.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(sideMovement.ReadValue<float>() * Time.deltaTime * moveAmount, upwardMovement.ReadValue<float>() * Time.deltaTime * moveAmount, 0);
    }
}
