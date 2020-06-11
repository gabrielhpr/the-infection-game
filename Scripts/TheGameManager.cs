using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheGameManager : MonoBehaviour{

    public static TheGameManager instance;
    //PARTICLE SYSTEM
    public ParticleSystem particle1;
    public ParticleSystem particle2;

    public int currentLevel;

    void Awake(){
        if(instance == null){
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }
    // Start is called before the first frame update
    void Start(){
        //Freeze the particle system of congrats to the user
        particle1.Stop();
        particle2.Stop();
        ScoreManager.instance.GameStartScore();
        AntiPoisonManager.instance.StartAntiPoisonQuantity();
    }

    // Update is called once per frame
    void Update(){
        //ScoreManager.instance.UpdateCurrentScore(1);
        UIManager.instance.UpdateUI();
    }

    public void ActiveParticleSystem(){
        particle1.Play();
        particle2.Play();
    }
    public void RestartTheGame(){
        SceneManager.LoadScene("LevelCentral");
    }
    public void GoToMenu(){
        SceneManager.LoadScene("Level_Game");
    }
    public void GoToMenuAfterWinning(){
        UnlockNextLevel();
        SceneManager.LoadScene("Level_Game");
    }
    public void NextLevel(){
        UnlockNextLevel();
        SceneManager.LoadScene("LevelCentral");
    }

    public void UnlockNextLevel(){
        currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        PlayerPrefs.SetInt("CurrentLevel", currentLevel+1);
        PlayerPrefs.SetInt("Level"+(currentLevel+1), 1);
    }
}
