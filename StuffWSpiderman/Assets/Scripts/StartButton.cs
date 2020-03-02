using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour
{
    SomeStuff SpideyScript;
    public GameObject[] StartClicks;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonClick()
    {   
        Invoke("InvokeCalculation", 6f);
    }

    void InvokeCalculation()
    {SpideyScript = GameObject.Find("Spidey").GetComponent<SomeStuff>();
        for (int i = 0; i < StartClicks.Length-1; i++)
        {
            StartClicks[i].SetActive(true);
        }
        SpideyScript.IsGameStartSpace = SpideyScript.IsGameStartPumpkin=true;
        StartClicks[StartClicks.Length-1].SetActive(false);
    }
}
