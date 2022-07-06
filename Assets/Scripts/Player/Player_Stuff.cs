using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stuff : MonoBehaviour
{
    // Start is called before the first frame update
    private Game_Master gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        this.transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
