using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canBeDestroyed : MonoBehaviour
{
    int minDistance = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.z > minDistance + transform.position.z){
            Destroy(gameObject);
        }
    }
}
