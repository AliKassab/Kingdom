using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{

    [SerializeField] Transform Weapon;
    Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();   
    }

    private void AimWeapon()
    {
        if (Target != null)
            Weapon.LookAt(Target);
        else
            Weapon.transform.rotation= Quaternion.identity;
       
    }
}
