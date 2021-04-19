using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{     
  
      public float times =1f;
      private Text clock;
      public float n=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    if(n <= 24.0){    
    n = n + 0.001f;
    }else{
        n = 0.0f;
    }   
    string hour =  n.ToString();
    
    clock.text = hour;
   
    Time.timeScale = times;
    }
    
    public float GetN(){
        return n;
    }
    
}
