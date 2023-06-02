using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShoot(InputValue inputValue)
    { 
        GameObject newBullet = Instantiate(bullet, Camera.main.transform.position, Quaternion.identity);
        newBullet.transform.LookAt(Camera.main.transform.position + Camera.main.transform.forward);
        newBullet.transform.Translate(Vector3.forward * Vector3.Distance(newBullet.transform.position, transform.position));
        AkSoundEngine.PostEvent("Play_Shoot", gameObject);
    }
}
