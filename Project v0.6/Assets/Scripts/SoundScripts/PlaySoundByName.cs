using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundByName : MonoBehaviour
{
    [SerializeField] private string soundName;
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent(soundName, gameObject);
    }
}
