using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    public enum State{
        NONE,
        Z,
        HERO,
        T,
        L
    }
    public State state;

    [HideInInspector]
    public bool canMove = true;

    private InGameManager mg;
    private GridBuilter grid;
    public Transform[] child;

    void Start()
    {
        mg = GameObject.Find("GameManager").GetComponent<InGameManager>();
        child = GetComponentsInChildren<Transform>();
        grid = GameObject.Find("Grid").GetComponent<GridBuilter>();
        InvokeRepeating("DropBlock", 1.2f, 1.2f);
    }

    
    void Update()
    {
        
        if (canMove)
        {
            CheckKey();
            Rotate();    
        }
    }

    private void CheckKey()
    {
        //+z
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (IsLeavingeGrid(Vector3.forward))
            {
                
                transform.position -= new Vector3(0, 0, 1);

            }
            transform.position += new Vector3(0, 0, 1);
            
            
        }

        //-z
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            if (IsLeavingeGrid(Vector3.back))
            {
                
                transform.position += new Vector3(0, 0, 1);
            }
            transform.position -= new Vector3(0, 0, 1);
            

        }
        //+x
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            if(IsLeavingeGrid(Vector3.right))
            {
                transform.position -= new Vector3(1, 0, 0);
            }
            transform.position += new Vector3(1, 0, 0);
        }
        //-x
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           
            if (IsLeavingeGrid(Vector3.left))
            {
                transform.position += new Vector3(1, 0, 0);
            }
            transform.position -= new Vector3(1, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            GoToFloor();
           
        }

    }


    private void Rotate()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            
            transform.Rotate(90, 0, 0);

            if(IsLeavingeGrid(Vector3.right)|| IsLeavingeGrid(Vector3.left) || IsLeavingeGrid(Vector3.up) || IsLeavingeGrid (Vector3.down) ||
               IsLeavingeGrid(Vector3.forward) || IsLeavingeGrid(Vector3.back))
            {
                transform.Rotate(-90,0,0);
            }
        }

        if (Input.GetKeyDown(KeyCode.A) )
        { 
            transform.Rotate(0, 90, 0);
            if (IsLeavingeGrid(Vector3.right) || IsLeavingeGrid(Vector3.left) || IsLeavingeGrid(Vector3.up) || IsLeavingeGrid(Vector3.down) ||
               IsLeavingeGrid(Vector3.forward) || IsLeavingeGrid(Vector3.back))
            {
               
                transform.Rotate(0, -90, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) )
        {
            transform.Rotate(0, 0, 90);
            if (IsLeavingeGrid(Vector3.right) || IsLeavingeGrid(Vector3.left) || IsLeavingeGrid(Vector3.up) || IsLeavingeGrid(Vector3.down) ||
               IsLeavingeGrid(Vector3.forward) || IsLeavingeGrid(Vector3.back))
            {
                
                transform.Rotate(0, 0, -90);
            }
        }
    }

    private bool IsLeavingeGrid(Vector3 dir)
    {
        foreach(Transform T in child)
        {
            Ray ray = new Ray(T.transform.position, dir);
            if (Physics.Raycast(ray, out RaycastHit hit,1f, LayerMask.GetMask("Grid")))
            {
                
                if (hit.collider != null ) 
                {
                    
                    return true;
                    
                }
            }
        }

        return false;
    }

    private void DropBlock()
    {
        if(IsLeavingeGrid(Vector3.down))
        {
            mg.CheckLines();
            Destroy(gameObject.GetComponent<PieceMovement>());
        }

        transform.position -= new Vector3(0, 1, 0);
        if(IsLeavingeGrid(Vector3.down))
        {
            
            foreach (var obj in child)
            {
                
                obj.parent = null;
                obj.position = new Vector3(Mathf.Round(obj.position.x), Mathf.Round(obj.position.y), Mathf.Round(obj.position.z));
                obj.gameObject.layer = LayerMask.NameToLayer("Grid");
           }
            
            mg.CheckLines();
            Destroy(gameObject.GetComponent<PieceMovement>()); 
        }
    }

    private void GoToFloor()
    {
        CancelInvoke("DropBlock");
        canMove = false;
        while(!IsLeavingeGrid(Vector3.down))
        {
            transform.position -= new Vector3(0, 1, 0);
        }

        transform.position += new Vector3(0, 1, 0);
        DropBlock();
    }

   

}
