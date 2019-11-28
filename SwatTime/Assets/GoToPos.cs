using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPos : MonoBehaviour{

    Rigidbody rb;
    [SerializeField]
    GameObject[] targetList;
    GameObject currentTarget;
    int currentTargetNum;

   public GameObject particles;
   
    GameManager manager;
    void Start(){
        manager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        SetTarget(Random.Range(0,targetList.Length));
        //Debug.LogWarning(targetList.Length);

      //  manager = FindObjectOfType<GameManager>();
    }

    void SetTarget(int choice){
        if (coolDown <= 0){
            if (choice != currentTargetNum){
                coolDown = coolDownReset;
                currentTargetNum = choice;
                currentTarget = targetList[choice];
            }
            else{
                SetTarget(Random.Range(0, targetList.Length));
                Debug.LogWarning("sameVal on selection");
            }
        }
    }
    float speed = 3f;
    float coolDown= 0;
    float coolDownReset = .6f;

    void Update(){
        if (manager.play == true){
            if (coolDown > 0){
                coolDown -= Time.deltaTime;
            }
            rb.position = Vector3.Lerp(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }

      
    }

    private void OnTriggerStay(Collider other ){
        if (other.gameObject.tag == "target"){
            SetTarget(Random.Range(0, targetList.Length));
        }
    }

    private void OnDestroy()
    {
        particles.transform.position = transform.position;
        Instantiate(particles);
        Camera.main.GetComponent<cameraShake>().LargeShake();
    }



}
