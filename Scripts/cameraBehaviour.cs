using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraBehaviour : MonoBehaviour
{	
    public GameObject player;
    Rigidbody playerRb;
    float thrust = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate(){        
        //The camera only move if the ball has started to move and is not freezed
       if(player.transform.position.z != -4 && playerRb.constraints != RigidbodyConstraints.FreezeAll){
            transform.Translate(new Vector3(0,0,1) * Time.deltaTime * thrust, Space.World);
       }
    } 
}
