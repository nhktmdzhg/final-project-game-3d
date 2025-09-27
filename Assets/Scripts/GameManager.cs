using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int coin = 0;
    public static GameManager instance;

<<<<<<< HEAD
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] Canvas gameOverUI;
    [SerializeField] PlayerController playerController;
=======
    public TextMeshProUGUI coinText;
    PlayerController playerController;
>>>>>>> 7e4657a0207de7de8ceca7969d6315954c81556a

    public void IncrementCoin()
    {
        IncreaseCoin(1);
        coinText.text = "COIN: " + coin.ToString();
<<<<<<< HEAD
        playerController.speed += playerController.speedIncreasePerPoint;
=======
        playerController.speed += 0.1f;
>>>>>>> 7e4657a0207de7de8ceca7969d6315954c81556a
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
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
