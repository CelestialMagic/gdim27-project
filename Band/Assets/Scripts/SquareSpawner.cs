using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField]
    private float xStart, yStart;//The starting position of grid

    [SerializeField]
    private int row, column;//The number of rows and columns of grid

    [SerializeField]
    private float xSpace, ySpace;//The spacing between each square

    [SerializeField]
    private Square encounterSquare;//A square representing encounters

    [SerializeField]
    private Square emptySquare;//A square representing empty spaces

    [SerializeField]
    private Square gigSquare;//A square representing gigs

    private List<Square> squares;//A list of square to be instantiated

    private Square lastGenerated;

    [SerializeField]
    private int allowedEncounters;//The total number of encounter for a board

    [SerializeField]
    private int allowedGigs;//The total number of gigs for a board


    // Start is called before the first frame update
    void Start()
    {
        squares = new List<Square>() { encounterSquare, emptySquare, gigSquare };
        for (int i = 0; i < column * row; i++)
        {
            Instantiate(GenerateRandomSquare(), new Vector2(xStart + (xSpace * (i % column)), yStart + (ySpace * (i / column))), Quaternion.identity);
        }
    }

    //GenerateRandomSquare() returns a square based on the numbers of existing squares
    private Square GenerateRandomSquare()
    {
        Square square = squares[Random.Range(0, squares.Count)];
        if(square == encounterSquare && allowedEncounters > 0)
        {
            encounterSquare.SetEncounter(allowedEncounters);
            allowedEncounters--;
            return encounterSquare;
            
        }
        else if (square == gigSquare && allowedGigs > 0)
        {
            allowedGigs--;
            return gigSquare; 

        }
        else
        {
            return emptySquare; 
        }
            
        
        
    }
}
