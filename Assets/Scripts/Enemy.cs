using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed = 10f;

    public float health = 100;
    public int worth = 50;

    public GameObject deathEffect;

    // Start is called before the first frame update

    private void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage (float amount)
    {
        health -= amount;

        if(health <= 0)
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
        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    

}
