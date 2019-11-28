using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFlies : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (FindObjectOfType<GameManager>().play)
        {
            if (other.tag == "Fly")
            {
                Destroy(other.gameObject);
            }
        }

    
    }
}
