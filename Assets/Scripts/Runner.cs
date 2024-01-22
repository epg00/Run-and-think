using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    private bool isTarget;

    public bool IsTarget()
    {
       return isTarget;
    }

    public void SetTarget()
    {
       isTarget = true;
    }      
   
}
