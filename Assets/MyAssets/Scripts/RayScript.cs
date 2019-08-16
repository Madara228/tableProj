using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private Camera cam;
    public AudioSource _audio;
    void Start()
    {
        cam = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown (0)) 
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight/2, cam.nearClipPlane);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                //Debug.Log(hit.collider.gameObject.name);
                   hit.collider.gameObject.SendMessage("CallMessage");
                //Debug.DrawRay(transform.position, hit.point);
            }
        }
    }
    public void onClick()
    {
        Debug.Log("log");   
    }
    public void DisableSound()
    {
        _audio.mute = true;
    }
}
