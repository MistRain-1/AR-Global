using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceControl : MonoBehaviour
{
    public int buildindex;
    // Use this for initialization
    void Start()
    {
       
    }

   public void LoadSneneN()
    {
        SceneManager.LoadScene(buildindex);
    }
   public void QuitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}