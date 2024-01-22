using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState {Menu,Game,LevelComplete,GameOver}

    private GameState gameState;

    public static Action<GameState> onGameStateChanged;

    private void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance=this;
        }
    }

    public void SetGameState(GameState gameStateParameter){
        this.gameState = gameStateParameter;
        onGameStateChanged?.Invoke(gameStateParameter);
    }  

    public bool IsGameState(){
        return gameState == GameState.Game;
    } 
}
