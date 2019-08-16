using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MessageScript : MonoBehaviour
{
    public void CallMessage()
    {
        var player = GameObject.Find("Player");
        player.GetComponentInChildren<AudioSource>().mute = false;
        player.SendMessage("DisableSound");
    }
}
