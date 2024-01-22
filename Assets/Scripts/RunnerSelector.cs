using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSelector : MonoBehaviour
{

    public void SelectRunner(int runnerIndex){
        for(int i=0; i<transform.childCount; i++){
            if(i==runnerIndex){
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else{
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
