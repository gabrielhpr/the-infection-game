using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class openLevelsScene : MonoBehaviour
{
    public static openLevelsScene instance;
    public Button playBtn;

    void Awake(){
        if(instance == null){
            instance = this;
            //DontDestroyOnLoad(instance.gameObject);
        }
        else{
            Destroy(gameObject);
        }
        SceneManager.sceneLoaded += Load;
    }
    void Load(Scene scene, LoadSceneMode mode){
        playBtn.onClick.AddListener(CarregaLevelsScene);
    }
    void CarregaLevelsScene(){
        SceneManager.LoadScene("Level_Game");
    }
    
}
