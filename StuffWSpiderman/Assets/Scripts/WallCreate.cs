using UnityEngine;
using System.Collections;

public class WallCreate : MonoBehaviour
{
    float Left_Walls_x = -3.05f, Right_Walls_x = 3.05f;
    int Wall_Lenght_Count = 37;


    public GameObject Wall;
    GameObject[] Walls;

    void Start()
    {
        float Start_y = -5.65f;
        for (int i = 0; i < Wall_Lenght_Count; i++)
        {
            GameObject Go_Left = Instantiate(Wall, new Vector2(Left_Walls_x, Start_y), Quaternion.identity) as GameObject;
            GameObject Go_Right = Instantiate(Wall, new Vector2(Right_Walls_x, Start_y), Quaternion.identity) as GameObject;
            Start_y += Wall.GetComponent<Renderer>().bounds.size.y;

            Go_Left.name = "Wall_Left_" + i;
            Go_Right.name = "Wall_Right_" + i;

            Go_Left.layer = Go_Right.layer = 9;

            Go_Left.tag = "Left_Side";
            Go_Right.tag = "Right_Side";
        }

    }

    void Update()
    {

    }
}
