using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using JetBrains.Annotations;

public class PlayerDetection : MonoBehaviour
{

    [SerializeField] private CrowdSystem crowdSystem;

    public static Action onDoorHit;

    public static Action onCoinHit;

    void Update() {
        if(GameManager.instance.IsGameState()){
            DetectColliders();
        }
        
    }

    private void DetectColliders(){
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1.5f);
    
        for(int i=0; i<detectedColliders.Length; i++){
            if(detectedColliders[i].TryGetComponent(out Doors doors)){
                
                int bonusAmount = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType = doors.GetBonusType(transform.position.x);

                doors.Disable();

                onDoorHit?.Invoke();

                crowdSystem.ApplyBonus(bonusType,bonusAmount);
            }
            else if(detectedColliders[i].CompareTag("Finish"))
            {

                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") +1);
                
                GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);
                
                //SceneManager.LoadScene(0);


            }
            else if(detectedColliders[i].CompareTag("Coin")){
                Destroy(detectedColliders[i].gameObject);

                onCoinHit?.Invoke();

                DataManager.instance.AddCoins(1);
            }
        }
    }
}
