using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource runnerDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource moneditaSound;

    void Start() {
        PlayerDetection.onDoorHit += PlayDoorHitSound;

        PlayerDetection.onCoinHit += PlayMoneditaSound;

        GameManager.onGameStateChanged += GameStateChangedCallBack;

        Enemy.onRunnerDied += PlayRunnerDiedSound;
    }

    private void OnDestroy() {
        PlayerDetection.onDoorHit -= PlayDoorHitSound;

        PlayerDetection.onCoinHit -= PlayMoneditaSound;

        GameManager.onGameStateChanged -= GameStateChangedCallBack;

        Enemy.onRunnerDied -= PlayRunnerDiedSound;
    }

    private void GameStateChangedCallBack(GameManager.GameState gameState){

        if(gameState == GameManager.GameState.LevelComplete){
            levelCompleteSound.Play();
        }
        else if(gameState == GameManager.GameState.GameOver){
            gameOverSound.Play();
        }

    }

    public void DisableSounds(){
        doorHitSound.volume = 0;
        runnerDieSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        buttonSound.volume = 0;
        moneditaSound.volume = 0;
    }

    public void EnableSounds(){
        doorHitSound.volume = 1;
        runnerDieSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
        buttonSound.volume = 1;
        moneditaSound.volume = 1;
    }

    private void PlayDoorHitSound(){
        doorHitSound.Play();
    }

    private void PlayRunnerDiedSound(){
        runnerDieSound.Play();
    }

    private void PlayMoneditaSound(){
        moneditaSound.Play();
    }
}
