using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikutplayer : MonoBehaviour
{

    public Transform TargetCamera;
    public float smoothspeed;
    public Vector3 offset;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -3f, 29f), 
            Mathf.Clamp(transform.position.y, -1f, 2f), 
            transform.position.z);
    }

    private void FixedUpdate()
    {
        Vector3 positioncamera = TargetCamera.localPosition + offset;
        Vector3 smoothCamera = Vector3.Lerp(transform.position, positioncamera, smoothspeed);
        transform.position = smoothCamera;
    }
}
