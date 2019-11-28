using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Timer : MonoBehaviour
{

    Text text;
    GameManager manager;
    string oldText;
    bool firstFrame = true;
    bool gameOver = false;

    public Image blackPanel;

    void Awake()
    {
        text = GetComponent<Text>();
        manager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {



        if (manager.play)
        {
            if (manager.timeLeft < 4)
            {
                text.color = Color.red;

            }

            if (manager.timeLeft > 0)
            {
                text.text = manager.timeLeft.ToString();

                if (text.text != oldText)
                {
                    GetComponent<Animator>().SetTrigger("Shake");

                }
            }
            else
            {
                if (!gameOver)
                {
                    GetComponent<Animator>().SetTrigger("End");
                    blackPanel.GetComponent<Animator>().SetTrigger("Fade");
                    text.text = "Game Over";
                    gameOver = true;
                }
                
            }




            oldText = text.text;
        }

        firstFrame = false;
        

       
    }
}
