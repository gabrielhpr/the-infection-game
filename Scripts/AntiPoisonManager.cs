using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiPoisonManager : MonoBehaviour
{
    public static AntiPoisonManager instance;
    public int antipoisonQuant;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    } 
    public void StartAntiPoisonQuantity(){
        antipoisonQuant = PlayerPrefs.GetInt("antipoisonQuantity");
    }
    //The method below is called when antipoison is used
    public void UpdateAntiPoisonQuantityAndSave(){
        antipoisonQuant = antipoisonQuant - 1;
        PlayerPrefs.SetInt("antipoisonQuantity", antipoisonQuant);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
