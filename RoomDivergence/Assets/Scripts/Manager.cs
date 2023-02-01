using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Manager : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> audioFilesInOrder;
    [SerializeField]
    [Tooltip("Needs to be the same size as AudioFilesInOrder")]
    private List<GameObject> speakersInOrder;
    [SerializeField]
    private AudioClip correctSound;
    [SerializeField]
    private AudioClip wrongSound;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject spawningPoint;

    private int currentStep = 0;
    private AudioSource audioSource;
    private bool hasPlayed = false;


    private void Awake()
    {
        OnStartThrow.RegisterListener(PlayAudioClip);
        OnSpeakerHit.RegisterListener(EvaluateSpeaker);
    }

    private void OnDestroy()
    {
        OnStartThrow.UnregisterListener(PlayAudioClip);
        OnSpeakerHit.UnregisterListener(EvaluateSpeaker);
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        InitBall();
    }

    private void InitBall()
    {
        ball.transform.position = spawningPoint.transform.position;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    private void PlayAudioClip(OnStartThrow grab)
    {
        audioSource.clip = audioFilesInOrder[currentStep];
        audioSource.Play();

        hasPlayed = true;

        InitBall();
    }

    private void EvaluateSpeaker(OnSpeakerHit speakerHit)
    {
        if (hasPlayed)
        {
            AudioSource speakerAudio = speakerHit.Speaker.GetComponent<AudioSource>();

            if (speakerHit.Speaker.Equals(speakersInOrder[currentStep]))
                speakerAudio.clip = correctSound;
            else
                speakerAudio.clip = wrongSound;
            speakerAudio.Play();

            currentStep++;
            if (currentStep == audioFilesInOrder.Count)
                currentStep = 0;

            hasPlayed = false;

            InitBall();
        }
    }
}
