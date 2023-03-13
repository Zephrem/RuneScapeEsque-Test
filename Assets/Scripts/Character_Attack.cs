using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Attack : MonoBehaviour
{
    private GameObject target;
    private Character_Stats characterStats;
    private Character_Stats targetStats;
    private Character_Movement characterMovement;
    private float attackDelay;
    private float swingTimer;

    // Start is called before the first frame update
    void Start()
    {
        characterStats = GetComponent<Character_Stats>();
        characterMovement = GetComponent<Character_Movement>();
        attackDelay = characterStats.GetAttackDelay();
        swingTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (swingTimer > 0)
        {
            swingTimer -= Time.deltaTime;
        }

        if (target != null)
        {
            if (Vector3.Distance(target.transform.position, transform.position) > characterStats.GetRange())
            {
                characterMovement.SetDestination(target.transform.position);
            }
            else
            {
                Attack();
                characterMovement.StopMovement();
            }
        }

    }

    private void Attack()
    {
        if (swingTimer <= 0)
        {
            targetStats.TakeDamage((int)characterStats.GetStrength());
            swingTimer = attackDelay;
        }
    }

    public void SetTarget(GameObject enemy)
    {
        target = enemy;
        targetStats = target.GetComponent<Character_Stats>();
    }

    public void ClearTarget()
    {
        target = null;
    }
}
