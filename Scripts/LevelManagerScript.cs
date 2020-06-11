using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour {

    public Text highestScoreUI;
    public Text antipoisonUI;
    //To have access to levels created in the code, for example the level list
    [System.Serializable]
    //Class level that contain all the necessary information about each level
    public class Level{
        public string levelTxt;
        public bool habilitado;
        public int desbloqueado;
    }
    public GameObject btn;
    public Transform btnPosition;
    public List<Level> levelList;

    void ListAdd(){
        foreach(Level level in levelList){
            //Instantiate returns an object, as GameObject works like a typecasting
            GameObject btnNew = Instantiate(btn) as GameObject;

            //Getting the script inside the fase_UI(button), to store those information
            BtnLevel btnNovo = btnNew.GetComponent<BtnLevel> ();
            btnNovo.levelTxtBTN.text = level.levelTxt;
            //btnNovo.desbloqueadoBTN = level.desbloqueado;
            //btnNovo.GetComponent<Button>().interactable = level.habilitado; 
            //btnNovo.desbloqueadoBTN = level.desbloqueado;  
            if(PlayerPrefs.GetInt("Level"+btnNovo.levelTxtBTN.text) == 1){
                level.desbloqueado = 1;
                level.habilitado = true;
            }
            btnNovo.desbloqueadoBTN = level.desbloqueado;
            btnNovo.GetComponent<Button>().interactable = level.habilitado;

            //getting the event click
            btnNovo.GetComponent<Button>().onClick.AddListener(() => ClickLevel(int.Parse(btnNovo.levelTxtBTN.text)));
            //SetParent , false - to not make the size really huge
            btnNew.transform.SetParent(btnPosition, false);
        }
    }
    void ClickLevel(int levelNumb){
        PlayerPrefs.SetInt("CurrentLevel", levelNumb);
        SceneManager.LoadScene("LevelCentral");
    }
    
    // Start is called before the first frame update
    void Start(){
         //PlayerPrefs.DeleteAll();
        ListAdd();
        highestScoreUI = GameObject.Find("SCORE_NUMBER").GetComponent<Text>();
        antipoisonUI = GameObject.Find("ANTIPOISON_NUMBER").GetComponent<Text>();
        if(PlayerPrefs.HasKey("highestScore")){
            highestScoreUI.text = PlayerPrefs.GetInt("highestScore").ToString();
        }
        else{
            PlayerPrefs.SetInt("highestScore", 0);
            highestScoreUI.text = PlayerPrefs.GetInt("highestScore").ToString();
        }
        if(PlayerPrefs.HasKey("antipoisonQuantity")){
            antipoisonUI.text = PlayerPrefs.GetInt("antipoisonQuantity").ToString();
        }
        else{
            PlayerPrefs.SetInt("antipoisonQuantity", 3);
            antipoisonUI.text = PlayerPrefs.GetInt("antipoisonQuantity").ToString();
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
