using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour
{

    SomeStuff SpideyScript;
    DataBase DbScript;
    PauseButton PauseScript;
    SoundScript SoundScriptt;

    public GameObject Player;
    public GameObject[] ThingsEnable;

    public void RestartScript()
    {
        SpideyScript = GameObject.Find("Spidey").GetComponent<SomeStuff>();
        DbScript = GameObject.Find("Main Camera").GetComponent<DataBase>();
        PauseScript = GameObject.Find("Pause Button").GetComponent<PauseButton>();

        Player.transform.position = SpideyScript.StartPos;

        GameObject[] PumpkinDestroy;
        PumpkinDestroy = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < PumpkinDestroy.Length; i++)
        {
            Destroy(PumpkinDestroy[i]);
        }
        DbScript.PumpkinDistanceses();

        DbScript.PlayerMoveUp = true;
        PauseScript.IsGamePaused = false;
        Invoke("CountDownClose", 6f);
        if (gameObject.name == "Restart Button II")
        {
            SoundScriptt = GameObject.Find("Sound Button").GetComponent<SoundScript>();
            SpideyScript.anim.speed = 1f;
            PauseScript.IsGamePaused = false;
            SpideyScript.Score = 0;
        }

    }

    //public GameObject CountDown;
    void CountDownClose()
    {
        SpideyScript.IsGameStartSpace = true;
        SpideyScript.PumpkingCreat();
        for (int i = 0; i < ThingsEnable.Length - 1; i++)
        {
            ThingsEnable[i].SetActive(true);
        }
        ThingsEnable[ThingsEnable.Length - 1].SetActive(false);
        if (gameObject.name == "Restart Button II")
        {
            SoundScriptt.SoundImageChange();
        }
    }
}
