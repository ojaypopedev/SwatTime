using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public float StartTimer = 3f;
    public bool play = false;

    float timer = 0;
    readonly private float timerTotal = 12f;
    public int timeLeft = 0;


    public Collider[] hands = new Collider[2];


    // Start is called before the first frame update
    void Start()
    {
        timer = timerTotal;
    }

    // Update is called once per frame
    void Update()
    {
        
       

        StartTimer -= Time.deltaTime;
        if(StartTimer < 0)
        {
            play = true;
        }

        if (play)
        {
            updateTimer();

            if (timeLeft < 0)
            {
                if (Input.GetKeyDown(KeyCode.Space)){
                    SceneManager.LoadScene(0);
                }
            }
        }

        if(FindObjectsOfType<GoToPos>().Length == 0){
            SceneManager.LoadScene(1);
        }
    }

    void updateTimer(){
        timer -= Time.deltaTime;
        timeLeft = Mathf.FloorToInt(timer);
    }
}
