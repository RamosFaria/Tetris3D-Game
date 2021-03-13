using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilter : MonoBehaviour
{

    [SerializeField]
    private GameObject grid;

    [HideInInspector]
    public uint Width = 10;
    [HideInInspector]
    public uint Height = 10;
    [HideInInspector]
    public uint Depth = 10;

    
    void Start()
    {
        
        SpawnGridFloor();
        //create wall behind
        for (uint x = 0; x <= Width; ++x)
        {
            for(uint y= 0; y <= Height; ++y)
            {
                var instantiated = Instantiate(grid, new Vector3(x , y + 2f, 10.5f), Quaternion.Euler(0,0,0)) as GameObject;
                instantiated.transform.parent = transform;
            }  
        }
        //create front wall
        for (uint x = 0; x <= Width; ++x)
        {
            for (uint y = 0; y <= Height; ++y)
            {
                var instantiated = Instantiate(grid, new Vector3(x, y + 2f, -0.5f), Quaternion.Euler(0, 180, 0)) as GameObject;
                instantiated.transform.parent = transform;
            }
        }

        //create left wall
        for (uint z = 0; z <= Depth; ++z)
        {
            for (uint y = 0; y <= Height; ++y)
            {
                var instantiated = Instantiate(grid, new Vector3(-0.5f, y + 2f, z), Quaternion.Euler(0, -90, 0)) as GameObject;
                instantiated.transform.parent = transform;
            }
        }
        //create right wall
        for (uint z = 0; z <= Depth; ++z)
        {
            for (uint y = 0; y <= Height; ++y)
            {
                var instantiated = Instantiate(grid, new Vector3(10.5f, y + 2f, z), Quaternion.Euler(0, 90, 0)) as GameObject;
                instantiated.transform.parent = transform;
            }
        }

    }
    //create floor
    private void SpawnGridFloor()
    {
        for(uint x =0; x <= Width; ++x)
        {
            for(uint z=0; z <= Depth; ++z)
            {
                var instantiated = Instantiate(grid, new Vector3(x,1.5f, z), Quaternion.Euler(90, 0, 0));
                instantiated.transform.parent = transform;
            }
        }
    }

    
}
