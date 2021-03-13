using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool CheckIfGameOver()
    {
        var everyBlocks = GameObject.FindGameObjectsWithTag("Blocks");
        foreach(var obj in everyBlocks )
        {
            if(obj.transform.position.y ==11)
            {
                
                return true;
            }
        }
        return false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
