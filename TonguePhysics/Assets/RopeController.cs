using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour{
    [Header("Debug")]

    public GameObject placeObj;
    public GameObject segmentPrefab;
    public GameObject TongueSetDress;
    public bool isShowingLinesBetweenObjects, isShowingDirectionBetweenObjects, isShowingMaxDistanceBetweenSegments;
    Vector3 startPoint;

    [SerializeField] List<GameObject> tongueSetDress;


    [Header("Data")]

    [SerializeField] float  maxSegmentDistance;
    [SerializeField] int    amountOfSegments;

    [SerializeField] List<GameObject>   ropeSegments;
    [SerializeField] List<float>        distanceBetweenSegments;
    [SerializeField] List<Vector3>      directionBetweenSegments;
    void Start(){
        GenerateRope();
        distanceBetweenSegments     = new List<float>   (new float  [ropeSegments.Count - 1]);
        directionBetweenSegments    = new List<Vector3> (new Vector3[ropeSegments.Count - 1]);
    }

    void GenerateRope(){
        for (int i = 0; i < amountOfSegments; i++){
            ropeSegments.Add(Instantiate(segmentPrefab, transform));
            ropeSegments[i].transform.position = new Vector3(startPoint.x + i, startPoint.y, startPoint.z);
            
            if (i == 0){ropeSegments[0].name = "start";}
        }
        for (int j = 0; j < amountOfSegments; j++)
        {
            tongueSetDress.Add(Instantiate(TongueSetDress, transform));
        }
    }

    // Update is called once per frame
    void FixedUpdate(){
        FindDistanceBetweenSegemnts();
        FindDirectionBetweenSegments();
        DrawLinesBeteenObjects();
        PlaceDebugObj();
        DebugShoot();
        SetDressTongue();

    }

    void SetDressTongue(){
        for (int i = 0; i < amountOfSegments - 1; i++){
            tongueSetDress[i].transform.position = ropeSegments[i].transform.position + (directionBetweenSegments[i] / 2);
            tongueSetDress[i].transform.LookAt(ropeSegments[i].transform);
            Transform goChild = tongueSetDress[i].transform.GetChild(0);
            goChild.transform.localScale = new Vector3(goChild.transform.localScale.x, (distanceBetweenSegments[i] * 2.3f), goChild.transform.localScale.z);
        }
    }

    void DebugShoot(){
        if (Input.GetKeyDown(KeyCode.E)){
            ropeSegments[0].GetComponent<Rigidbody>().AddExplosionForce(10, (ropeSegments[0].transform.position + (directionBetweenSegments[0].normalized)), 10,1);
        }
    }

    void PlaceDebugObj(){

        //    placeObj.transform.position = ropeSegments[0].transform.position + (directionBetweenSegments[0].normalized * maxSegmentDistance );
        //    ropeSegments[1].transform.position = placeObj.transform.position;
        //ropeSegments[i + 1].transform.position = ropeSegments[i].transform.position + (directionBetweenSegments[i].normalized * maxSegmentDistance) - (directionBetweenSegments[i] / 10);

        for (int i = 0; i < amountOfSegments -1; i++){
            if (distanceBetweenSegments[i] > maxSegmentDistance){
                ropeSegments[i + 1].transform.position = Vector3.Lerp(ropeSegments[i + 1].transform.position,  ropeSegments[i].transform.position + (directionBetweenSegments[i].normalized * maxSegmentDistance) - (directionBetweenSegments[i] / 10), Time.deltaTime * 10);

            }
        }
    }

    void FindDirectionBetweenSegments(){
        for (int i = 0; i < amountOfSegments -1; i++){
            directionBetweenSegments[i] = -(ropeSegments[i].transform.position - ropeSegments[i + 1].transform.position);
            if (isShowingDirectionBetweenObjects){
                Debug.DrawRay(ropeSegments[i].transform.position, directionBetweenSegments[i], Color.green);
            }
            if (isShowingMaxDistanceBetweenSegments){
                Debug.DrawRay(ropeSegments[i].transform.position, (directionBetweenSegments[i].normalized) * (maxSegmentDistance), Color.magenta);
            }
        }
    }



    void FindDistanceBetweenSegemnts(){
        for (int i = 0; i < amountOfSegments -1; i++){
            distanceBetweenSegments[i] = Vector3.Magnitude(ropeSegments[i].transform.position - ropeSegments[i + 1].transform.position);
        }
    }

    void DrawLinesBeteenObjects(){
        if (isShowingLinesBetweenObjects){
            for (int i = 0; i < amountOfSegments -1; i++){
                Debug.DrawLine(ropeSegments[i].transform.position, ropeSegments[i + 1].transform.position, Color.red);
            }
        }
    }
}
