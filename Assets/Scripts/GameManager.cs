using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int coin = 0;
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] Canvas gameOverUI;
    [SerializeField] PlayerController playerController;

    public void IncrementCoin()
    {
        IncreaseCoin(1);
        coinText.text = "COIN: " + coin.ToString();
        playerController.speed += playerController.speedIncreasePerPoint;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;            
        }
        
    }
    public void IncreaseCoin(int amount)
    {
        coin += amount;
        Debug.Log("Score: " + coin);
    }
    public void GameOver()
    {
        gameOverUI.gameObject.SetActive(true);    // Use SetActive
        //Time.timeScale = 0f;          // Pause game
        Debug.Log("Game Over! Final Score: " + coin);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
