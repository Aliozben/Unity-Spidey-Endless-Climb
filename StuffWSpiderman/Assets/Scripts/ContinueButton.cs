using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour
{
    SomeStuff SpideyScript;
    SoundScript SoundScriptt;
    PauseButton PauseScript;

    public GameObject CountDown, Pause;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CancelPause()
    {

        // SpideyScript.IsGameStartPumpkin = SpideyScript.IsGameStartSpace = true;
    }

    public void CountDownInvoke()
    {
        Invoke("CountDownCalculation", 6f);
    }
    void CountDownCalculation()
    {
        SpideyScript = GameObject.Find("Spidey").GetComponent<SomeStuff>();
        SoundScriptt = GameObject.Find("Sound Button").GetComponent<SoundScript>();
        PauseScript = GameObject.Find("Pause Button").GetComponent<PauseButton>();

        SoundScriptt.SoundImageChange();
        SpideyScript.anim.speed = 1f;
        SpideyScript.IsGameStartSpace = true;
        PauseScript.IsGamePaused = false;
        CountDown.SetActive(false);
        Pause.SetActive(true);
    }
}
