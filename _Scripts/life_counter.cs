using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_counter : MonoBehaviour
{
    [SerializeField] float health;

    public void SetHealth(float healthSet) {
        health = healthSet;
    }
    public void DealDamage(float damage) {
        if (health - damage <= 0) {
            GameObject.Destroy(gameObject);
        }
        else {
            health -= damage;
        }
    }
}
