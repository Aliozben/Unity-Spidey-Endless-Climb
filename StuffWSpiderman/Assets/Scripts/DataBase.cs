using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{
    SomeStuff PlayerScript;
    PauseButton PauseScript;
    SoundScript SoundButton;

    public Text BestScore_EndgameText, Score_EndgameText, BestScore_IngameText;
    public GameObject Player, NewScore;
    public GameObject[] GameOver_EnableObjects, GameOver_DisableObject;
    public Sprite[] BadMemes, HighMemes, LeaveMemes;
    public Image SpideyMeme;

    public bool PlayerMoveUp = true;
    bool JoinGameOver = true;
    float Clock = 0f;
    public float[] Zones;
    // public int Best_Score;
    public bool IsGameOver = false;

    public void PumpkinDistanceses()
    {
        float pumpkinDistance = 2.5f;
        Zones[0] = 5.5f;
        for (int i = 0; i < Zones.Length - 1; i++)
        {
            Zones[i + 1] = Zones[i] + pumpkinDistance;
        }
    }
    void Start()
    {
        PumpkinDistanceses();
        BestScore_IngameText.text += PlayerPrefs.GetInt("BestScore");
    }

    // Update is called once per frame
    void Update()
    {
        Clock += Time.deltaTime;
        if (Clock >= 6f)
        {
            if (!Player.GetComponent<Renderer>().isVisible && IsGameOver)
            {
                GameOver();
                for (int i = 0; i < GameOver_EnableObjects.Length; i++)
                {
                    GameOver_EnableObjects[i].SetActive(true);
                }
                for (int i = 0; i < GameOver_DisableObject.Length; i++)
                {
                    GameOver_DisableObject[i].SetActive(false);
                }

                IsGameOver = false;
            }
        }
    }

    void GameOver()
    {
        PlayerScript = GameObject.Find("Spidey").GetComponent<SomeStuff>();
        PauseScript = GameObject.Find("Pause Button").GetComponent<PauseButton>();
        SoundButton = GameObject.Find("Sound Button").GetComponent<SoundScript>();

        GameObject[] PumpkinDestroy;
        PumpkinDestroy = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < PumpkinDestroy.Length; i++)
        {
            Destroy(PumpkinDestroy[i]);
        }
        PauseScript.IsGamePaused = false;
        PlayerScript.Falling = false;
        PlayerMoveUp = false;
        PlayerScript.IsGameStartSpace = false;

        if (PlayerScript.Score>(PlayerPrefs.GetInt("BestScore")/2))
        {
            int rnd = Random.Range(0, HighMemes.Length);
            SpideyMeme.sprite = HighMemes[rnd];
        }
        else
        {
            int rnd = Random.Range(0, BadMemes.Length);
            SpideyMeme.sprite = BadMemes[rnd];
        }
        SoundButton.auidos.Stop();
        if (PlayerScript.Score > PlayerPrefs.GetInt("BestScore"))                       //
        {                                                                               // Save Best Score.
            PlayerPrefs.SetInt("BestScore", PlayerScript.Score);                        //        
            NewScore.SetActive(true);
        }

        BestScore_EndgameText.text = "Best Score:\n" + PlayerPrefs.GetInt("BestScore").ToString();
        Score_EndgameText.text = "Score: " + PlayerScript.Score.ToString();

        Player.transform.position = PlayerScript.StartPos;                              // Restart the player's position.
        PlayerScript.RestartPumpkin();
        PlayerScript.Score = 0;

    }

    public void Exit()
    {
        int rnd = Random.Range(0, LeaveMemes.Length);
        SpideyMeme.sprite = LeaveMemes[rnd];
        Invoke("Quit", 3f);
    }

    public void Quit()
    {
        Debug.Log("Game Closed");
        Application.Quit();
    }
   
}
