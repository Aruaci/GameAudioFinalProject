using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

   

    // Start is called before the first frame update
  
    private void OnTriggerEnter(Collider other)
    {
        DataStorage.instance.IncreaseScore(1);
        //var dataStorage = globalData.GetComponent<DataStorage>();
        //dataStorage.IncreaseScore(1);
       // Debug.Log(DataStorage.score);
       // DataStorage.IncreaseScore(1);
       AkSoundEngine.PostEvent("Play_Coin_Collision", gameObject);
       Destroy(this.gameObject);
    }
    
}
