using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmiterScript : MonoBehaviour
{
    public GameObject[] Asteroids;
    public float MinDelay, MaxDelay;
    float NextAsteroidTime;

    public GameObject Enemy;
    public float MinEnemyDelay, MaxEnemyDelay;
    float NextEnemyTime;

    public GameObject Shield;
    public float MinShieldDelay, MaxShieldDelay;
    float NextShieldTime;
    void Update()
    {
        if(Time.time > NextAsteroidTime)
        {
            var PosY = 0;
            var PosZ = transform.position.z;
            var PozX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);

            NextAsteroidTime = Time.time + Random.Range(MinDelay, MaxDelay);
            Instantiate(Asteroids[Random.Range(0,Asteroids.Length)],new Vector3(PozX,PosY,PosZ),Quaternion.identity);
        }

        if (Time.time > NextEnemyTime)
        {
            var PosY = 0;
            var PosZ = transform.position.z;
            var PozX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);

            NextEnemyTime = Time.time + Random.Range(MinEnemyDelay, MaxEnemyDelay);
            Instantiate(Enemy, new Vector3(PozX, PosY, PosZ), Quaternion.Euler(0,180,0));
        }
        if (Time.time > NextShieldTime)
        {
            var PosY = 0;
            var PosZ = transform.position.z;
            var PozX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);

            NextShieldTime = Time.time + Random.Range(MinShieldDelay, MaxShieldDelay);
            Instantiate(Shield, new Vector3(PozX, PosY, PosZ), Quaternion.Euler(-90, 180, 0));
        }
    }
} 
