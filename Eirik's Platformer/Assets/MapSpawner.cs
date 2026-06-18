using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    float offsetX = 0.96f;
    float boxSizeX = 4;
    float boxOffsetX = 6.4f;
    public int brickamount;
   BoxCollider2D boxCollider;
    public GameObject brick;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.offset = new Vector2(boxSizeX * brickamount, 0);

        boxCollider.size = new Vector2(brickamount > 1? boxOffsetX : (boxOffsetX * brickamount) ,boxOffsetX);
        GameObject bwicky = Instantiate(brick, new Vector2(transform.position.x + offsetX, transform.position.y), Quaternion.identity);
        for (int i = 0; i < brickamount; i++) 
        {
            GameObject newBrick = Instantiate(brick, new Vector2(bwicky.transform.position.x+offsetX, transform.position.y),Quaternion.identity);
            bwicky= newBrick;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
