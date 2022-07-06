using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Change_Trigger : MonoBehaviour
{   
    [Header("Coordinates for next map")]
    [SerializeField]
    public float x;
    [SerializeField]
    public float y;
    [Header("What scene to change into")]
    [SerializeField]
    public int levelIndex;
    [SerializeField]
    public Level_Loader loader;
    [SerializeField]
    private Game_Master gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
    }

   private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Player")){
        gm.lastCheckPointPos = new Vector2(x, y);
        loader.LoadNextLevel(levelIndex);
    }
    
   }

}
