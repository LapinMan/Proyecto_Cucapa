using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor_Movement : MonoBehaviour
{
    Camera cam;
    Vector3 objectivePos;
    private Game_Master gm;

    void Start()
    {
        gm =  GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        cam = Camera.main;
        objectivePos = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            objectivePos = cam.ScreenToWorldPoint(Input.mousePosition);
            objectivePos.z = this.transform.position.z;
        }
        transform.position = objectivePos;
    }
}
