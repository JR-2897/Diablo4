using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject cameraToTrack; //this is the animated dummy imported from 3dsmax

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        this.transform.localPosition = new Vector3(cameraToTrack.transform.position.x+15, cameraToTrack.transform.position.y+10, cameraToTrack.transform.position.z);
    }
}
