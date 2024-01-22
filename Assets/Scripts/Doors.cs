using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum BonusType {Addition, Difference, Product, Division}
public class Doors : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer rightDoor;
    [SerializeField] private SpriteRenderer leftDoor;

    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;

    [SerializeField] private Collider doorCollider;

    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;

    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color penaltyColor;

    void Start() {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        //RIGHT DOOR

        switch(rightDoorBonusType){
            case BonusType.Addition:

                rightDoor.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break;

            case BonusType.Difference:

                rightDoor.color = penaltyColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break;

            case BonusType.Product:

                rightDoor.color = bonusColor;
                rightDoorText.text = "x" + rightDoorBonusAmount;
                break;

            case BonusType.Division:

                rightDoor.color = penaltyColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
            
        }        

        //LEFT DOOR

        switch(leftDoorBonusType){
            case BonusType.Addition:

                leftDoor.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;

            case BonusType.Difference:

                leftDoor.color = penaltyColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;

            case BonusType.Product:

                leftDoor.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmount;
                break;

            case BonusType.Division:

                leftDoor.color = penaltyColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
            
        } 
    }


    public int GetBonusAmount(float xPosition){
        if(xPosition>0){
            return rightDoorBonusAmount;
        }
        else{
            return leftDoorBonusAmount;
        }
    }

    public BonusType GetBonusType(float xPosition){
        if(xPosition>0){
            return rightDoorBonusType;
        }
        else{
            return leftDoorBonusType;
        }
    }

    public void Disable(){
        doorCollider.enabled =false;
    }

}
