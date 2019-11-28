using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{


     enum ShakeType { None, Small, Large}
     ShakeType shake = ShakeType.None;
    public float timer = 0f;

    private Vector3 startPoint;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)      
            timer -= Time.deltaTime;

        switch (shake)
        {
            case ShakeType.None:
                transform.localPosition = startPoint;
                startPoint = transform.localPosition;
              break;

            case ShakeType.Small:
                if (timer <= 0)
                {
                    shake = ShakeType.None;
                }
                transform.localPosition = startPoint + Random.insideUnitSphere/20;

                break;

            case ShakeType.Large:
                if (timer <= 0)
                {
                    shake = ShakeType.None;
                }
                transform.localPosition = startPoint + Random.insideUnitSphere / 6;

                break;
            default:
                break;
        }

    }

    public void SmallShake()
    {
        shake = ShakeType.Small;

        timer = 0.2f;
    }

    public void LargeShake()
    {
        shake = ShakeType.Large;
        timer = 0.5f;
            
    }
}
