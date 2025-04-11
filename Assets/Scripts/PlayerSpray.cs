using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpray : MonoBehaviour
{
    public GameObject spray;
    public GameObject flies;

    public bool sprayActivated = false;
    public float timer;
    public float maxSprayTime;

    public float killFlyDist;
    void Start()
    {
        
    }

    void Update()
    {
        float DistanceToFlies = Vector3.Distance(spray.transform.position, flies.transform.position);

        if (sprayActivated && DistanceToFlies <= killFlyDist)
        {
            flies.SetActive(false);
        }

        if (sprayActivated)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            sprayActivated = true;
            Debug.Log("spray activated");
            spray.SetActive(true);
        }

        if (timer >= maxSprayTime)
        {
            sprayActivated = false;
            timer = 0f;
            spray.SetActive(false)
;
        }
    }
}
