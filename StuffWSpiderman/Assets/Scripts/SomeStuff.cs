using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SomeStuff : MonoBehaviour
{
    public Text ScoreBoard_Text;
    public bool ScreenTouch;
    public bool IsGameStartPumpkin, IsGameStartSpace; // When Pressed Start Button, It gonna creat Pumpkin and active jump.

    RaycastHit2D hit;

    DataBase DatabaseScript;
    BlockScript BlocksScript;

    GameObject[] Blocks, BlocksRight;
    int BlocksCount = 10;
    public GameObject Block;

    public Animator anim;

    public int Score = 0;
    bool StopClimping;

    public Vector3 StartPos;
    void Start()
    {
        StartPos = transform.position;
        anim = GetComponent<Animator>();
        DatabaseScript = GameObject.Find("Main Camera").GetComponent<DataBase>();
    }
    public bool Jump, SpaceUse = true, LeftRight /*True=Right*/ ;  //Jump Parameters

    public bool grounded, Falling;     //Animator --> TriggerWall, Animator --> IsDead

    //It's checking it is trigger wall or not.
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatisGround;
    //

    void Update()
    {
        if (transform.position.y <= -0.6f && DatabaseScript.PlayerMoveUp)                              //Start Climping
            transform.Translate(Vector2.up * 1f * Time.deltaTime);      //Start Climping

        if (IsGameStartPumpkin)
        {
            PumpkingCreat();
            IsGameStartPumpkin = false;
        }
        ScoreBoard_Text.text = Score.ToString();
        if (!Falling)
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatisGround);
        anim.SetBool("IsDead", Falling);
        anim.SetBool("TriggerWall", grounded);
        if (Falling && GetComponent<Renderer>().isVisible)
        {
            transform.Translate(Vector2.down * 4f * Time.deltaTime);
            switch (SpideyOnLeft)
            {
                case true: transform.Translate(Vector2.right * 1f * Time.deltaTime); break;
                case false: transform.Translate(Vector2.right * 1f * Time.deltaTime); break;
            }
        }
        RaycastHit hit3d;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),  out hit3d))
        {
            if (Input.GetMouseButtonDown(0))
            {
                TouchScreen();
            }
        }
       
        if (Jump)                               // Jump Speed
        {
            SpaceUse = false;
            if (SpideyOnLeft)
            {
                transform.position += new Vector3(7f * Time.deltaTime, 0f, 0f);
            }
            else
            {
                transform.position -= new Vector3(7f * Time.deltaTime, 0f, 0f);
            }

        }
    }

    bool SpideyOnLeft;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Block")                                                  // Game Over!!!!!
        {
            DatabaseScript.IsGameOver = true;
            Falling = true;
            grounded = false;

        }
        if (!Falling)
        {
            if (coll.gameObject.tag == "Left_Side")
            {
                SpideyOnLeft = true;
                Jump = false;
                SpaceUse = true;
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            }

            else
            {
                SpideyOnLeft = false;
                Jump = false;
                SpaceUse = true;
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
        }
    }

    public void PumpkingCreat()
    {
        //Creat Blocks
        Blocks = BlocksRight = new GameObject[BlocksCount];

        float BlockRandom;
        for (int i = 0; i < BlocksCount; i++)
        {
            float minRandom = DatabaseScript.Zones[2 * i] * 1f, maxRandom = DatabaseScript.Zones[2 * i + 1] * 1f;
            BlockRandom = Random.Range(minRandom, maxRandom);
            if (i % 2 == 0 || i == 0)
            {
                // GameObject GoLeft=Instantiate(Block, new Vector3)
                GameObject GoLeft = Instantiate(Block, new Vector3((float)-1.85, BlockRandom, -.1f), Quaternion.identity) as GameObject;
                Blocks[i] = GoLeft;
            }
            else
            {
                GameObject GoLeft = Instantiate(Block, new Vector3((float)1.85, BlockRandom, -.1f), Quaternion.identity) as GameObject;
                Blocks[i] = GoLeft;
            }
            Blocks[i].name = "BlockClone_" + i;
        }
        //

    }

    public void RestartPumpkin()
    {
        int RandomBackup = 0, BlockRandom;
        for (int i = 0; i < BlocksCount; i++)
        {
        RndLeight:
            BlockRandom = Random.Range(8 * (i + 1), 10 * (i + 1));
            if (!(BlockRandom - RandomBackup >= 2.5f || RandomBackup - BlockRandom >= 2.5f))
            {
                goto RndLeight;
            }
            if (i % 2 == 0 || i == 0)
            {
                Blocks[i].transform.position = new Vector3(-2f, BlockRandom, 0);
            }
            else
            {
                Blocks[i].transform.position = new Vector3(2f, BlockRandom, 0);
            }
        }
    }

     void TouchScreen()
    {
        #region Spidey Move
        if (IsGameStartSpace)
        {
            if (/*Input.touchCount > 0Input.GetKeyDown(KeyCode.Space) &&*/ SpaceUse)
            {
                Jump = true;
            }

            
        }
        #endregion
    }

}
