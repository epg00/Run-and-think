using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private ShopManager shopManager;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;

    void Start(){
        progressBar.value=0;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        levelText.text = "Nivel " + (ChunkManager.instance.GetLevel() +1);

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy(){
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    void Update(){
        UpdateProgressBar();
    }

    private void GameStateChangedCallback(GameManager.GameState gameState){
        if(gameState == GameManager.GameState.GameOver){
            ShowGameOver();
        }
            
        else if(gameState == GameManager.GameState.LevelComplete){
            ShowLevelComplete();
        }
    }
 
    public void PlayButtonPressed(){
        GameManager.instance.SetGameState(GameManager.GameState.Game);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    private void ShowLevelComplete(){
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }

    public void RetryButtonPressed(){
        InterstitialAd.instance.ShowAd();
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver(){
       
        gameOverPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void UpdateProgressBar(){

        if(!GameManager.instance.IsGameState()) return;

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }

    public void ShowSettingsPanel(){
        settingsPanel.SetActive(true);
    }

    public void HideSettingsPanel(){
        settingsPanel.SetActive(false);
    }

    public void ShowShop(){
        shopPanel.SetActive(true);
        shopManager.UpdatePurchaseButton();
    }

    public void HideShop(){
        shopPanel.SetActive(false);
    }
}
