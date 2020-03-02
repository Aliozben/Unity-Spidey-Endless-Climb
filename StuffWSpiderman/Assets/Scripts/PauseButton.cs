using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour
{
    SomeStuff SpideyScript;
    SoundScript SoundScriptt;

    public bool IsGamePaused;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Scrpits()
    {
        SoundScriptt = GameObject.Find("Sound Button").GetComponent<SoundScript>();
        SpideyScript = GameObject.Find("Spidey").GetComponent<SomeStuff>();

        // Stop Sound
        SoundScriptt.auidos.volume = 0f;
        SoundScriptt.Sound_On = false;
        //

        SpideyScript.anim.speed = 0f;
        IsGamePaused = true;
        SpideyScript.IsGameStartSpace = false;
        //SoundScriptt.Sound_On = false;
    }
}
