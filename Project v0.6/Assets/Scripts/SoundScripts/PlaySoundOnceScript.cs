using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnceScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Door_Close", gameObject);
    }
}
