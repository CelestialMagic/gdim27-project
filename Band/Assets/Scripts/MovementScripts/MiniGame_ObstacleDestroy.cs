using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_ObstacleDestroy : MonoBehaviour
{
    [SerializeField]
    private MiniGame_Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Collect")
        {
            Debug.Log("Collided!");
            Destroy(collision.gameObject);
        }
    }
}
