using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouCheatDeath: MonoBehaviour
{
    public Transform rESPAWNTHINGY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -24)
        { 
            transform.position = rESPAWNTHINGY.position;
        }
    }
}
