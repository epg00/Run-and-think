using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    private bool haptics;
    
    void Start()
    {
        PlayerDetection.onDoorHit += Vibrate;
        Enemy.onRunnerDied += Vibrate;
        GameManager.onGameStateChanged += GameStateChangedCallBack;
    }

    private void OnDestroy(){
        PlayerDetection.onDoorHit -= Vibrate;
        Enemy.onRunnerDied -= Vibrate;
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }

    private void GameStateChangedCallBack(GameManager.GameState gameState){

        if(gameState == GameManager.GameState.LevelComplete){
            Vibrate();
        }
        else if(gameState == GameManager.GameState.GameOver){
            Vibrate();
        }

    }

    private void Vibrate(){
         //if (GUI.Button(new Rect(0, 10, 100, 32), "Vibrate!"))
         if(haptics){
            Handheld.Vibrate();
         }
            
    }

    public void DisableVibration(){
        haptics = false;
    }

    public void EnableVibration(){
        haptics = true;
    }

}
