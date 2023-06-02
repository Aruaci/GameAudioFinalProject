using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fly());
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private IEnumerator Fly()
    {
        while (true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            var enemyStats = other.GetComponentInParent<EnemyStats>();
            enemyStats.ReduceHealth(2);
            AkSoundEngine.PostEvent("Play_Enemy_Hit", gameObject);
        }
    }
}
