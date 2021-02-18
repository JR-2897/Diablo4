using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int damage;
    public GameObject player;

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "sword")
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                player.GetComponent<PlayerController>().health += 40;
                Destroy(gameObject);
            }
        }
    }
}