using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeatlh : MonoBehaviour
{
    [SerializeField] float maxHealth = 5;
    [SerializeField] float damage = 1;
    float currentHealth;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
