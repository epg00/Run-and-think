using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public static PlayerController instance;

    [SerializeField] private CrowdSystem crowdSystem;
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private float roadWidth;
    private bool canMove;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    private void Awake(){
        if(instance!=null){
            Destroy(gameObject);
        }
        else{
            instance=this;
        }
    }


    void Start(){
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy() {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }
    
    void Update()
    {
        if(canMove){
            MoveForward();
            ManageControl();
        }
    }

    private void GameStateChangedCallback(GameManager.GameState gameState){
        if(gameState == GameManager.GameState.Game){
            StartMoving();
        }
        else if(gameState == GameManager.GameState.GameOver){
            StopMoving();
        }
        else if(gameState == GameManager.GameState.LevelComplete){
            StopMoving();
        }
        
    }

    private void StartMoving(){
        canMove = true;
        playerAnimator.Run();
    }

    private void StopMoving(){
        canMove = false;
        playerAnimator.Idle();
    }

    private void MoveForward(){
        transform.position += moveSpeed * Time.deltaTime * Vector3.forward;
    }

    private void ManageControl(){
        if(Input.GetMouseButtonDown(0)){ //Si tocas la pantalla
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0)){ //Mientras lo presiona
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
        
            xScreenDifference /= Screen.width;

            xScreenDifference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;

            position.x = Mathf.Clamp(position.x, -roadWidth/2 + crowdSystem.GetCrowdRadius(), roadWidth/2 - crowdSystem.GetCrowdRadius());

            transform.position = position;
        
        }
    }
}
