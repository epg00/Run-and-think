using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private VibrationManager vibrationManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundButtonImage;
    [SerializeField] private Image hapticsButtonImage;

    private bool soundsState = true;
    private bool hapticsState = true;

    private void Awake(){
        soundsState = PlayerPrefs.GetInt("sounds",1) == 1;
        hapticsState = PlayerPrefs.GetInt("haptics",1) == 1;
    }


    void Start(){
        SetUp();
    }

    private void SetUp(){
        if(soundsState){
            EnableSounds();
        }
        else{
            DisableSounds();
        }

        if(hapticsState){
            EnableHaptics();
        }
        else{
            DisableHaptics();
        }
    }

    public void ChangeSoundsState(){
        if(soundsState){
            DisableSounds();
        }
        else{
            EnableSounds();
        }

        soundsState = !soundsState;

        int soundsSaveState;

        if (soundsState){
            soundsSaveState=1;
        }
        else{
            soundsSaveState=0;
        }

        PlayerPrefs.SetInt("sounds",soundsSaveState); //soundsState?1 : 0
    }    

    private void DisableSounds(){
        soundManager.DisableSounds();
        soundButtonImage.sprite = optionsOffSprite;
    }
    
    private void EnableSounds(){
        soundManager.EnableSounds();
        soundButtonImage.sprite = optionsOnSprite; 
    }

    public void ChangeHapticsState(){
        if(hapticsState){
            DisableHaptics();
        }
        else{
            EnableHaptics();
        }

        hapticsState = !hapticsState;

        int hapticsSaveState;
        
        if (hapticsState){
            hapticsSaveState=1;
        }
        else{
            hapticsSaveState=0;
        }

        PlayerPrefs.SetInt("haptics",hapticsSaveState); //hapticsState?1 : 0
    }

    private void DisableHaptics(){
        vibrationManager.DisableVibration();
        hapticsButtonImage.sprite = optionsOffSprite;
    }

    private void EnableHaptics(){
        vibrationManager.EnableVibration();
        hapticsButtonImage.sprite = optionsOnSprite;
    }

}
