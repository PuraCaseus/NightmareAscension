using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 100;
    int health;
    public GameObject DeathEffect;
    public GameObject HurtEffect;
    public GameObject Spawn;
    public Animator anim;

    public HealthBarBehavior Healthbar;
    
    void Start()
    {
        health = maxHealth;
        Healthbar.SetHealth(health, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Healthbar.SetHealth(health, maxHealth);
        anim.SetTrigger("isHurt");
        Instantiate(HurtEffect, transform.position, Quaternion.identity);
        if(health <= 0)
        {
            Die();
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Spawn.SetActive(true);
        }
    }
    void Die()
    {
        //print("oof");
        Destroy(gameObject);
  
    }

    
}
