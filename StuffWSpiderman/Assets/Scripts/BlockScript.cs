using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour
{
    SomeStuff SSScpirt;
    SoundScript SoundScripT;
    PauseButton PauseScrpit; 

    void Start()
    {
        SSScpirt = GameObject.FindGameObjectWithTag("Player").GetComponent<SomeStuff>();
        SoundScripT = GameObject.Find("Sound Button").GetComponent<SoundScript>();
        PauseScrpit = GameObject.Find("Pause Button").GetComponent<PauseButton>();
    }

    RaycastHit2D hit;
    bool Score_Enable = true;
    public AudioClip CoinSound;
    bool StopScore;

    void Update()
    {
        if (transform.position.x >= 0)
            gameObject.layer = 11;  //Right_Pumpkin

        else gameObject.layer = 10; //Left_Pumpkin

        if (!GetComponent<Renderer>().isVisible)
        {
            Score_Enable = true;
        }
        
        if(!PauseScrpit.IsGamePaused)
        transform.Translate(Vector2.down * 4f * Time.deltaTime);                                           //Moving Code !!!!!!!!

        if (gameObject.layer == 11) //Right_Pumpkin
            hit = Physics2D.Raycast(transform.position - new Vector3(1, 0, 0), Vector2.left);

        else hit = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right);

        if (hit.collider != null && hit.collider.name == "Spidey")
        {
            if (Score_Enable&&!StopScore)
            {
                SSScpirt.Score++;
                if (SoundScripT.Sound_On)
                {
                    AudioSource.PlayClipAtPoint(CoinSound, transform.position);
                }

                Score_Enable = false;
            }

        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name=="Spidey")
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(true);
            }
            StopScore = true;
            Invoke("DestroyGameObject", 0.5f);
        }
    }
    void DestroyGameObject()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
