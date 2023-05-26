using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]

public class EnemyHeatlh : MonoBehaviour
{
    [SerializeField] float maxHealth = 5;
    [SerializeField] int difficultyRamp = 1;
    [SerializeField] float damage = 1;
    float currentHealth;

    Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        enemy= GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            gameObject.SetActive(false);
            maxHealth += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
