using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour{
    
    public static ScoreManager instance;
    public int currentScore, highestScore;

    void Awake(){
        if(instance == null){
            instance = this;
            //DontDestroyOnLoad(instance.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    public void GameStartScore(){
        Debug.Log("chegoou no game start score");
        if(PlayerPrefs.HasKey("highestScore")){
            highestScore = PlayerPrefs.GetInt("highestScore");
        }
        currentScore = 0;
        PlayerPrefs.SetInt("currentScore", currentScore);
    }
    public void UpdateCurrentScore(int pontuation){
        currentScore += pontuation;
    }

    public void SaveHighestScore(){
        if(currentScore > highestScore)
            PlayerPrefs.SetInt("highestScore", currentScore);
    }
}
