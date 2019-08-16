using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairsScript : MonoBehaviour
{
    public void CallMessage()
    {
        transform.Rotate(new Vector3(transform.rotation.x, Mathf.Lerp(transform.rotation.y, 180f, 0.1f), transform.rotation.z));
        Debug.Log("chair");
    }
}
