using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_Player : MonoBehaviour
{

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    private bool collided; 

    private int minigameMoney; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            collided = true; 


        } else if (collision.gameObject.tag == "Collect")
        {
            Destroy(collision.gameObject);
            SetMinigameMoney(10);
        }
    }

    public int GetMinigameMoney()
    {
        return minigameMoney;
    }

    public void SetMinigameMoney(int amount)
    {
        minigameMoney += amount;
    }

    public bool GetCollided()
    {
        return collided; 
    }
}

