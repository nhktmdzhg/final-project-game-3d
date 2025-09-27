using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BackGame()
    {
        Time.timeScale = 1f; // Reset time scale in case it was paused
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
