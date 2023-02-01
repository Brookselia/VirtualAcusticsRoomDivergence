using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartThrow : EventCallbacks.Event<OnStartThrow>
{
    public OnStartThrow() : base("Event, that will be fired, when the ball is grabbed.")
    {
        FireEvent(this);
    }
}
