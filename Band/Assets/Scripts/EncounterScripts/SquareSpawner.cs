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
    private List<Square> squares;//A list of square to be instantiated

    private Square lastGenerated;

    [SerializeField]
    private int allowedEncounters;//The total number of encounter for a board


    [SerializeField]
    private Square startingSquare;//The starting square of the grid

    [SerializeField]
    private Square empty;

    [SerializeField]
    private List<Square> endingSquare;//The ending square of the grid

    [SerializeField]
    private PlayerMovement player;

    private GameObject g;
    private Square s;

    [SerializeField]
    private int spawnBuffer;

    private int bufferTimer; 
    // Start is called before the first frame update
    void Start()
    {
        bufferTimer = spawnBuffer;
        for (int i = 0; i < column * row; i++)
        {
            if (i == 0)
            {
                
                s = Instantiate(startingSquare, new Vector2(xStart + (xSpace * (i % column)), yStart + (ySpace * (i / column))), Quaternion.identity);
                g = s.gameObject;
                Debug.Log(g);
                player.AddMoveableSquare(g);
            }
            else if (i == column * row - 1)
            {
                s = Instantiate(endingSquare[Random.Range(0, endingSquare.Count)], new Vector2(xStart + (xSpace * (i % column)), yStart + (ySpace * (i / column))), Quaternion.identity); ;
                g = s.gameObject;
                player.AddMoveableSquare(g);

            }
            else
            {
                s = Instantiate(GenerateRandomSquare(), new Vector2(xStart + (xSpace * (i % column)), yStart + (ySpace * (i / column))), Quaternion.identity);
                g = s.gameObject;
                player.AddMoveableSquare(g);
            }
                
        }
    }

    //GenerateRandomSquare() returns a square based on the numbers of existing squares
    private Square GenerateRandomSquare()
    {
        int index = Random.Range(0, squares.Count);
        Square square = squares[index];


        if(square.GetIsEncounter() == true && allowedEncounters > 0 &&  bufferTimer == 0)
        {
            square.SetMyEncounter(allowedEncounters);
            allowedEncounters--;
            squares.Remove(square);
            bufferTimer = spawnBuffer;
            return square;
            
        }
        else
        {
            bufferTimer--;
            return empty;
        }

    }

}
