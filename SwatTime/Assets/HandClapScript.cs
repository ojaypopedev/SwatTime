using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandClapScript : MonoBehaviour
{

    public void Clap()
    {

        Camera.main.GetComponent<cameraShake>().SmallShake();
    }

}
