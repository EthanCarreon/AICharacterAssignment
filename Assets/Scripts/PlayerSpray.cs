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
        // get the float distance between flies and spray
        float DistanceToFlies = Vector3.Distance(spray.transform.position, flies.transform.position);

        // if the spray is being used, and the distance between them is close enough, set the visibility to false
        if (sprayActivated && DistanceToFlies <= killFlyDist)
        {
            flies.SetActive(false);
        }

        // if spray is activated, set a timer
        if (sprayActivated)
        {
            timer += Time.deltaTime;
        }

        // keybind to spray, set boolean to true and set its visibility to true
        if (Input.GetKeyDown(KeyCode.F))
        {
            sprayActivated = true;
            Debug.Log("spray activated");
            spray.SetActive(true);
        }

        // if the spray time reaches its max time being open, set it back to false, reset timer
        if (timer >= maxSprayTime)
        {
            sprayActivated = false;
            timer = 0f;
            spray.SetActive(false)
;
        }
    }
}
