using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    void Start()
    {
        currentHealth= maxHealth;
    }

    public void TakeDamage(int _damagePoints)
    {
        currentHealth-= _damagePoints;
        if (currentHealth <=0){ 
            currentHealth=0;
            Die();
            
        }
    }

    public void Heal (int _lifePoints)
    {
        currentHealth += _lifePoints;
        if (currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
