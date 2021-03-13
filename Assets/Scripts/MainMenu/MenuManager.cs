using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
        GameManager.Load();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        GameManager.Save();
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

}
