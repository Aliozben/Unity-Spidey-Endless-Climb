using UnityEngine;
using System.Collections;

public class WallsRmoving : MonoBehaviour
{
    RaycastHit2D hit2d;
    PauseButton PauseScript;

    void Start()
    {
        PauseScript = GameObject.Find("Pause Button").GetComponent<PauseButton>();
    }

    bool OneTimeMomentInvoke = true;
    void Update()
    {
        if (!PauseScript.IsGamePaused)
            transform.Translate(Vector2.down * 2f * Time.deltaTime);                // Moving Code !!!!
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "MainCamera")
        {
            if (gameObject.tag == "Left_Side")
            {
                transform.position = new Vector2(-3.04f, 11.4f);
            }
            else
                transform.position = new Vector2(3.04f, 11.4f);
        }
    }
    void Invokes()
    {


    }
    void Moment()
    {

    }
}
