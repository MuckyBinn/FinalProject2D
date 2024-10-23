using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hp : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        CurHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            TakeDamage(20);
        }

    }
    void TakeDamage(int damage)
    {
        CurHealth -= damage;
        healthBar.SetHealth(CurHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Zombie"))
        {
            TakeDamage(30);
        }
    }
    public bool IsDead()
    {
        if(CurHealth <= 0)
        {
            return true;
        }
        return false;
    }
}

