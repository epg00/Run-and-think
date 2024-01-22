using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private Button thisButton;
    [SerializeField] private Image skinImage;
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject selector;

    private bool unlockedBool=false;


    public void Configure(Sprite skinSprite, bool unlocked){
        skinImage.sprite = skinSprite;

        this.unlockedBool=unlocked;

        if(unlocked){
            Unlock();
        }
        else{
            Lock();
        }
    }

    public void Unlock()
    {
        thisButton.interactable = true;
        skinImage.gameObject.SetActive(true);
        lockImage.SetActive(false);
        unlockedBool=true;
    }

    private void Lock()
    {
        thisButton.interactable = false;
        skinImage.gameObject.SetActive(false);
        lockImage.SetActive(true);
    }

    public void Select(){
        selector.SetActive(true);
    }

    public void DeSelect(){
        selector.SetActive(false);
    }

    public Button GetButton(){
        return thisButton;
    }

    public bool IsUnlocked(){
        return unlockedBool;
    }
}
