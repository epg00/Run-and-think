using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Button adButton;
    [SerializeField] private SkinButton[] skinButtons;    
    [SerializeField] private Sprite[] skins;

    [SerializeField] private int skinPrice;
    [SerializeField] private TextMeshProUGUI priceText;


    public static Action<int> onSkinSelected;
    

    private void Awake() {
        UnlockSkin(0);
        priceText.text = skinPrice.ToString();
    }


    IEnumerator Start()
    {
        RewardedAd.onRewardedAd += RewardPlayer;

       ConfigureButtons(); 
       UpdatePurchaseButton();

       yield return null;

       SelectSkin(GetLastSelectedSkin()); //Asi aseguramos que el PLAYERSELECTOR se ha suscrito al evento antes del cambio de skin
    }

    private void OnDestroy(){
        RewardedAd.onRewardedAd -= RewardPlayer;
    }

    private void RewardPlayer(){
        DataManager.instance.AddCoins(8);
        UpdatePurchaseButton();
    }

    private void ConfigureButtons()
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            bool unlocked = PlayerPrefs.GetInt("skinButton" + i)==1;

            skinButtons[i].Configure(skins[i],unlocked);

            int skinIndex = i;

            skinButtons[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex));
        }
    }

    public void UnlockSkin(int skinIndex){
        PlayerPrefs.SetInt("skinButton" + skinIndex, 1);
        skinButtons[skinIndex].Unlock();
    }

    public void UnlockSkin(SkinButton skinButton){
        int skinIndex = skinButton.transform.GetSiblingIndex(); //El numero de la posicion del hijo
        UnlockSkin(skinIndex);
        SelectSkin(skinIndex);
    }

    private void SelectSkin(int skinIndex){

        for(int i=0; i<skinButtons.Length; i++){
            if(skinIndex == i){
                skinButtons[i].Select();
            }
            else{
                skinButtons[i].DeSelect();
            }
        }

        onSkinSelected?.Invoke(skinIndex);
        SaveLastSelectedSkin(skinIndex);
    }

    public void PurchaseSkin(){
        List<SkinButton> skinButtonsList = new List<SkinButton>();

        for(int i=0; i<skinButtons.Length;i++){
            if(!skinButtons[i].IsUnlocked()){
                skinButtonsList.Add(skinButtons[i]);
            }
        }
        if(skinButtonsList.Count <=0){
            return;
        }

        SkinButton randomSkinButton = skinButtonsList[UnityEngine.Random.Range(0,skinButtonsList.Count)];

        UnlockSkin(randomSkinButton);

        DataManager.instance.UseCoins(skinPrice);

        UpdatePurchaseButton();    
    }

    public void UpdatePurchaseButton(){
        if(DataManager.instance.GetCoins() < skinPrice){
            purchaseButton.interactable = false;
            adButton.interactable=true;
        }
        else{
            purchaseButton.interactable = true;
            adButton.interactable=true;
        }
    }
    

    private int GetLastSelectedSkin(){
        return PlayerPrefs.GetInt("lastSelectedSkin",0);
    }

    private void SaveLastSelectedSkin(int skinIndex){
        PlayerPrefs.SetInt("lastSelectedSkin",skinIndex);
    }
}
