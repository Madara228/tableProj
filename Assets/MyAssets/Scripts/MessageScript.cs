using UnityEngine;

public class MessageScript : MonoBehaviour
{
    private bool isListen = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public void CallMessage()
    {
        if (!isListen)
        {
            player.GetComponentInChildren<AudioSource>().mute = false;
            player.SendMessage("DisableSound");
            isListen = true;
        }
        else
        {
            player.GetComponentInChildren<AudioSource>().mute = true;
            player.SendMessage("EnableSound");
            isListen = false;
        }
    }
}
