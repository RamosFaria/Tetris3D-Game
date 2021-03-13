using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    
    public int score;
    public Text scoreText;
    public Text scoreTextLose;
    public Text highScoreText;
    public GameObject loseUI;

    private GridBuilter grid;
    private EndGame Ed;
    

    public GameObject[] blocks;

    public List<GameObject> cubes = new List<GameObject>();

    void Start()
    {
        
        
        grid = GameObject.Find("Grid").GetComponent<GridBuilter>();
        Ed = GameObject.Find("EndGame").GetComponent<EndGame>();
        Invoke("RandomBlock", 1);
    }

    
    void Update()
    {
        scoreText.text = "Score: " + score;
        scoreTextLose.text = "Score: " + score;
        highScoreText.text = "HighScore: " + GameManager.highScore;
    }

    public void AddScore()
    {
        score += 200;
        if (score> GameManager.highScore)
        {

            GameManager.highScore = score;
        }

        
    }

    public void CheckLines()
    {
        int l = 0;
        while (l < grid.Height)
        {
            cubes.Clear();
            cubes = GameObject.FindGameObjectsWithTag("Blocks").ToList();

            if (cubes.Count(p => p.transform.position.x >=0  && p.transform.position.y == l) == 121)
            {
                
                foreach (GameObject block in cubes)
                {
                    
                    if (block.transform.position.y == l)
                    {
                        Destroy(block);
                    }
                }
                
                foreach(GameObject block in cubes)
                {
                    if(block.transform.position.y >= l)
                    {
                        block.transform.position -= new Vector3(0, 1, 0);
                    }
                    
                }
                AddScore();
                l = 0;
            }
           
            else
            {
                l++;
            }
        }
        RandomBlock();
    }


    public void RandomBlock()
    {          
        if(!Ed.CheckIfGameOver())
        {
            Instantiate(blocks[Random.Range(0, blocks.Length)], transform.position, Quaternion.identity);
            
        }
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        loseUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
