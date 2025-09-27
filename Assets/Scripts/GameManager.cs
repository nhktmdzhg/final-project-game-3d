using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int coin = 0;
    public static GameManager instance;

    public TextMeshProUGUI coinText;
    PlayerController playerController;

    public void IncrementCoin()
    {
        IncreaseCoin(1);
        coinText.text = "COIN: " + coin.ToString();
        playerController.speed += 0.1f;
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
