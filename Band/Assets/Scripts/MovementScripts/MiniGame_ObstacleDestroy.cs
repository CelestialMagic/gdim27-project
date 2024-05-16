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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
