using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject StartObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Speaker"))
        {
            new OnSpeakerHit(collision.gameObject);
        }
        else if (collision.gameObject.Equals(StartObject))
        {
            new OnStartThrow();
        }
    }
}
