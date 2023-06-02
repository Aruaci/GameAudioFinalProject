using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
   [SerializeField] private int decreasePlayerHealthBy; 
   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         DataStorage.instance.DecreaseHealth(decreasePlayerHealthBy);
         AkSoundEngine.PostEvent("Play_enemy_collision", gameObject);
      }
   }
}