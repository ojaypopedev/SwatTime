using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_IntroText : MonoBehaviour
{
    GameManager manager;
   public  Text text_main;
    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Update(){
        text_main.text = manager.StartTimer > 0 ? Mathf.CeilToInt(manager.StartTimer).ToString() : "SWAT!!!";
    }

}
