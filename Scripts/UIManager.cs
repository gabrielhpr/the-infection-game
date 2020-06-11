using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour{

    public static UIManager instance;
    public Text scoreUI, antipoisonUI;
    public int useAntipoison;
    public GameObject loosePanel, winPanel, initialAdvicePanel, gotInfectedPanel;
    public Button useAntipoisonBtn, noUseAntipoisonBtn, noUseAntipoisonBtn2, watchAVideoToAntipoisonBtn;
    public Button restartBtn, nextLevelBtn, menuBtn, menuBtn2;

    void Awake(){
        if(instance == null){
            instance = this;
            //DontDestroyOnLoad(instance.gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
        //Every time a scene is loaded the pontuation game object is too
        SceneManager.sceneLoaded += Load;
        OnOffPanel();
    }
    //This function get the score_number gameObject
    void Load(Scene scene, LoadSceneMode mode){
        //scoreUI = GameObject.Find("Score_number").GetComponent<Text>();
        //loosePanel = GameObject.Find("looseScreenPanel");
        //winPanel = GameObject.Find("winScreenPanel");
        useAntipoisonBtn.onClick.AddListener(UseAntipoison);
        noUseAntipoisonBtn.onClick.AddListener(GameOverUI);
        noUseAntipoisonBtn2.onClick.AddListener(GameOverUI);
        watchAVideoToAntipoisonBtn.onClick.AddListener(watchVideoToAntipoison);
        restartBtn.onClick.AddListener(Restart);
        nextLevelBtn.onClick.AddListener(GoToNextLevel);
        menuBtn.onClick.AddListener(MenuAfterWinning);
        menuBtn2.onClick.AddListener(Menu);



    }
    public void UpdateUI(){
        scoreUI.text = ScoreManager.instance.currentScore.ToString();
        antipoisonUI.text = AntiPoisonManager.instance.antipoisonQuant.ToString();
        //antipoisonUI.text = ScoreManager.instance.currentAntipoisonQuantity.ToString();
    }
    public void Restart(){
        TheGameManager.instance.RestartTheGame();
    }
    public void GoToNextLevel(){
        TheGameManager.instance.NextLevel();
    }
    public void Menu(){
        TheGameManager.instance.GoToMenu();
    }
    public void MenuAfterWinning(){
        TheGameManager.instance.GoToMenuAfterWinning();
    }
    public void StartGameUI(){
        initialAdvicePanel.SetActive(false);
        //PlayerPrefs.DeleteAll();
    }
    public void WinGameUI(){
        StartCoroutine(loadWinPanel());
    }
    public void GameOverUI(){
        gotInfectedPanel.SetActive(false);
        loosePanel.SetActive(true);
    }
    public void GotInfectedUI(){
        PlayerPrefs.SetInt("useAntipoison", 0);
        if(AntiPoisonManager.instance.antipoisonQuant > 0){
            gotInfectedPanel.SetActive(true);
            gotInfectedPanel.transform.GetChild(2).gameObject.SetActive(false);
            gotInfectedPanel.transform.GetChild(1).gameObject.SetActive(true);
            StartCoroutine(chooseToUseTheAntipoison());
        }
        else{
            gotInfectedPanel.SetActive(true);
            gotInfectedPanel.transform.GetChild(1).gameObject.SetActive(false);
            gotInfectedPanel.transform.GetChild(2).gameObject.SetActive(true);
            StartCoroutine(chooseToWatchVideoToAntipoison());
        }
        
        
    }
    public void UseAntipoison(){
        AntiPoisonManager.instance.UpdateAntiPoisonQuantityAndSave();
        PlayerPrefs.SetInt("useAntipoison", 1);
        gotInfectedPanel.SetActive(false);
        playerBehaviour.instance.userSaved();
    }
    void OnOffPanel(){
        StartCoroutine(tempo());
    }
    void watchVideoToAntipoison(){
        PlayerPrefs.SetInt("useAntipoison",1);
        //Show a video
        gotInfectedPanel.SetActive(false);
        playerBehaviour.instance.userSaved();
    }
    IEnumerator tempo(){
        yield return new WaitForSeconds(0.0001f);
        //Close all the panels, except the initial advice panel
        loosePanel.SetActive(false);
        winPanel.SetActive(false);
        gotInfectedPanel.SetActive(false);
        initialAdvicePanel.SetActive(true);
    }
    IEnumerator loadWinPanel(){
        yield return new WaitForSeconds(2);
        winPanel.SetActive(true);
    }
    IEnumerator chooseToUseTheAntipoison(){
        yield return new WaitForSeconds(10);
        if(PlayerPrefs.GetInt("useAntipoison") == 0){
            gotInfectedPanel.SetActive(false);
            playerBehaviour.instance.die();
        }
    }
    IEnumerator chooseToWatchVideoToAntipoison(){
        yield return new WaitForSeconds(10);
        if(PlayerPrefs.GetInt("useAntipoison") == 0){
            gotInfectedPanel.SetActive(false);
            playerBehaviour.instance.die();
        }
        
    }
}
