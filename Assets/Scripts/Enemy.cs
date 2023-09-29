using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed = 10f;


    public float startHealth = 100;
    
    public float health;
    public int worth = 50;

    public GameObject deathEffect;
    private bool isDead = false;

    // Start is called before the first frame update

   
    private void Start()
    {
        speed = startSpeed;
        health = startHealth*((float)(7+SceneFader.LevelToInt())/8);
    }
    public void TakeDamage (float amount)
    {
        health -= amount;


        if(health <= 0 && !isDead)
        {           
            Die();
        }
    }

    public void Slow (float percent)
    {
        speed = startSpeed * (1f - percent);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    

}
