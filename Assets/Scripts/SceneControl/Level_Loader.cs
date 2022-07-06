using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    private Game_Master gm;
    private GameObject player;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadNextLevel(int index){
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int levelIndex){

        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);
        player.transform.position = gm.lastCheckPointPos;

        SceneManager.LoadScene(levelIndex);

    }

}
