using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairsScript : MonoBehaviour
{
    public enum SelfStates
    {
        state1 = 0,
        state2 = 1,
    }
    public SelfStates states = SelfStates.state1;
    public SelfStates previosState = SelfStates.state1;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();    
    }
    public void CallMessage()
    {
        if (states == SelfStates.state1)
        {
            states = SelfStates.state2;
        }
        else if (states == SelfStates.state2)
        {
            states = SelfStates.state1;
        }
    }
    private void Update()
    {
        if (states != previosState)
        {
            if (states == SelfStates.state1)
            {
                anim.SetInteger("stateInt",0);
                previosState = states;
            }
            else if (states == SelfStates.state2)
            {
                anim.SetInteger("stateInt", 1);
                previosState = states;
            }
        }
    }
}
