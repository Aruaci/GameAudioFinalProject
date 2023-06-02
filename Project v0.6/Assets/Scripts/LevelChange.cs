using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string level;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        AkSoundEngine.PostEvent("Play_Door_Open", gameObject);
        SceneManager.LoadSceneAsync(level);

    }
}
