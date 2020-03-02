using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Block_Spawn : MonoBehaviour
{
    DataBase DataBaseScript;
    // Use this for initialization
    void Start()
    {
        DataBaseScript = GameObject.Find("Main Camera").GetComponent<DataBase>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    int BlockCount = 0; int BlockPosBackup = 0;
    void OnCollisionEnter2D(Collision2D coll)
    {
        int[] BlockPosX = { -1, 1 }; // Left or Right
        if (coll.transform.tag == "Block")
        {
           
            float random = Random.Range(DataBaseScript.Zones[13], DataBaseScript.Zones[14]);
            int x = Random.Range(0, 2); // Left or Right
            
            coll.transform.position = new Vector3(BlockPosX[x] * coll.transform.position.x, random);
         
        }
    }
}

