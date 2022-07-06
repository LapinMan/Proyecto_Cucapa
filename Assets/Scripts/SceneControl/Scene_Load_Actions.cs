using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Load_Actions : MonoBehaviour
{
    private GameObject player; //drag player reference onto here
    private Game_Master gm; //here you store the position you want to teleport your player to
     
    private void Start(){
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
     {
         SceneManager.sceneLoaded += SceneLoaded; //You add your method to the delegate
     }
     
     private void OnDisable()
     {
         SceneManager.sceneLoaded -= SceneLoaded;
     }
     
     //After adding this method to the delegate, this method will be called every time
     //that a new scene is loaded. You can then compare the scene loaded to your desired
     //scenes and do actions according to the scene loaded.
     private void SceneLoaded(Scene scene, LoadSceneMode mode)
     {
         player.transform.position = gm.lastCheckPointPos;
     }
}
