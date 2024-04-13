using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayDialog : MonoBehaviour
{
     //& WE NEED 
    // To display status when status button is clicked from a range of 1-5
    // we need to play audio clips when spawning animals
    [SerializeField] private UIManager uiManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameIntro;
    [SerializeField] private AudioClip twominutespassed;
    [SerializeField] private AudioClip fourminutespassed;
    [SerializeField] private AudioClip sixminutespassed;
    [SerializeField] private AudioClip eightminutespassed;
    [SerializeField] private AudioClip oneMinuteLeft;
    [SerializeField] private AudioClip Objectivereached;


    [SerializeField] private AudioClip EnteredDaySceneFirstTime;
    [SerializeField] private AudioClip EnteredNightSceneFirstTime;
    [SerializeField] private AudioClip EnteredHurricaneSceneFirstTime;

    [SerializeField] private AudioClip gameVictory;
    [SerializeField] private AudioClip gameLoss;

    [SerializeField] private AudioClip SpawnedAlligator;
    [SerializeField] private AudioClip SpawnedToad;
    [SerializeField] private AudioClip SpawnedRabbit;
    [SerializeField] private AudioClip SpawnedBass;
    [SerializeField] private AudioClip SpawnedCat;
    [SerializeField] private AudioClip SpawnedPython;
    [SerializeField] private AudioClip opensettings;



    void FixedUpdate()
    {
        playAudioCueONtimedEvent();
    }
    void playAudioBasedOnObjective()
    {

    }
    void playAudioCueONtimedEvent()
    {
        if (uiManager.min == 7 && uiManager.sec == 59 && audioSource.clip != twominutespassed)
        {
            audioSource.clip = twominutespassed;
            audioSource.Play();
        }
        if (uiManager.min == 5 && uiManager.sec == 59 && !audioSource.isPlaying)
        {
            audioSource.clip = fourminutespassed;
            audioSource.Play();
        }
        if (uiManager.min == 3 && uiManager.sec == 59 && !audioSource.isPlaying)
        {
            audioSource.clip = sixminutespassed;
            audioSource.Play();
        }
        if (uiManager.min == 1 && uiManager.sec == 59 && !audioSource.isPlaying)
        {
            audioSource.clip = eightminutespassed;
            audioSource.Play();
        }
        if (uiManager.min == 0 && uiManager.sec == 59 && !audioSource.isPlaying)
        {
            audioSource.clip = oneMinuteLeft;
            audioSource.Play();
        }
    }

    public void playerDaySceneEntered()
    {
        audioSource.clip = EnteredDaySceneFirstTime;
        audioSource.Play();
    }
    public void playerNightSceneEntered()
    {
        audioSource.clip = EnteredNightSceneFirstTime;
        audioSource.Play();
    }
    public void playerHurricaneSceneEntered()
    {
        audioSource.clip = EnteredHurricaneSceneFirstTime;
        audioSource.Play();
    }
}
