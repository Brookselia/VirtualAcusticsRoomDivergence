using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpeakerHit : EventCallbacks.Event<OnSpeakerHit>
{
    public readonly GameObject Speaker;

    public OnSpeakerHit(GameObject _speaker) : base("Event, that will be fired, when a speaker is hit by the ball.")
    {
        Speaker = _speaker;
        FireEvent(this);
    }
}
