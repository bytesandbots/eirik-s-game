using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    [Header("Brick Settings")]
    public GameObject brickPrefab;
    public int brickCount = 5;
    public Vector3 brickSize = new Vector3(1f, 1f, 1f);
    public float spacing = 0.1f;

    [Header("Spawn Direction")]
    public bool spawnHorizontal = true; // false = spawn vertically

    private BoxCollider boxCollider;
    private List<GameObject> spawnedBricks = new List<GameObject>();
    [Header("Spike? yes or no?")]
    public GameObject spiker;
    public bool spawnSpiker;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        SpawnBricks();
        AdjustCollider();
    }

    void SpawnBricks()
    {
        Vector3 spawnPos;
        for (int i = 0; i < brickCount; i+=1)
        {
            if (spawnHorizontal)
            {
                // spawn bricks along X axis
                spawnPos = transform.position + new Vector3(
                    i * (brickSize.x + spacing), 0, 0);
            }
            else
            {
                // spawn bricks along Y axis (stacked)
                spawnPos = transform.position + new Vector3( 0,  i * (brickSize.y + spacing),  0 );
            }

            GameObject brick = Instantiate(brickPrefab, spawnPos, transform.rotation);
            brick.transform.localScale = brickSize;

            // make sure brick has no collider
            BoxCollider brickCollider = brick.GetComponent<BoxCollider>();
            if (brickCollider != null)
            {
                Destroy(brickCollider);
            }

            spawnedBricks.Add(brick);

        }

        if (spawnSpiker)
        {
            Instantiate(spiker, spawnedBricks[spawnedBricks.Count-1].transform.position + new Vector3(0,0.95f,0), transform.rotation);

        }

    }

    void AdjustCollider()
    {
        if (boxCollider == null) return;

        if (spawnHorizontal)
        {
            // total width of all bricks + spacing between them
            float totalWidth = (brickCount * brickSize.x) + ((brickCount - 1) * spacing);

            // size the collider to wrap all bricks
            boxCollider.size = new Vector3(totalWidth, brickSize.y, brickSize.z);

            // center it between first and last brick
            boxCollider.center = new Vector3(
                (totalWidth / 2) - (brickSize.x / 2),
                0,
                0
            );
        }
        else
        {
            // total height of all bricks stacked
            float totalHeight = (brickCount * brickSize.y) + ((brickCount - 1) * spacing);

            boxCollider.size = new Vector3(brickSize.x, totalHeight, brickSize.z);

            boxCollider.center = new Vector3(
                0,
                (totalHeight / 2) - (brickSize.y / 2),
                0
            );
        }
    }
}


