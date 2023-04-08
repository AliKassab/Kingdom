using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{

    [SerializeField] Transform Weapon;
    [SerializeField] ParticleSystem arrows;
    [SerializeField] float Range = 15f;
    Transform Target;

    // Update is called once per frame
    void Update()
    {
        TargetClosestEnemy(); 
        AimWeapon();
    }

    private void TargetClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        Target = closestTarget;
    }

    private void AimWeapon()
    {

        float targetDistance  = Vector3.Distance(transform.position, Target.position);

            Weapon.LookAt(Target);

        if (targetDistance < Range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = arrows.emission;
        emissionModule.enabled = isActive;
    }
}
