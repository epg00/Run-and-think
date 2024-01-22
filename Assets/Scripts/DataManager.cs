using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [SerializeField] private TextMeshProUGUI[] coinsTexts;
    private int coins;

    private void Awake() {

        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance=this;
        }


        coins = PlayerPrefs.GetInt("coins", 0);
    }

    void Start() {
        UpdateCoinsTexts();
    }

    private void UpdateCoinsTexts(){
        foreach(TextMeshProUGUI coinText in coinsTexts){
            coinText.text = coins.ToString();
        }
    }

    public void AddCoins(int amount){
        coins+=amount;

        UpdateCoinsTexts();

        PlayerPrefs.SetInt("coins", coins);
    }

    public int GetCoins(){
        return coins;
    }

    public void UseCoins(int amount){
        coins-=amount;

        UpdateCoinsTexts();

        PlayerPrefs.SetInt("coins", coins);
    }
}
