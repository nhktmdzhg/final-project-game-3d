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

    public void IncrementCoin()
    {
        IncreaseCoin(1);
        coinText.text = "COIN: " + coin.ToString();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
