using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float aggroRange;

    private Character_Attack characterAttack;
    private Character_Movement characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        characterAttack = GetComponent<Character_Attack>();
        characterMovement = GetComponent<Character_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(playerObject.transform.position, transform.position) > aggroRange)
        {
            characterMovement.StopMovement();
            characterAttack.ClearTarget();
        }
        else
        {
            characterAttack.SetTarget(playerObject);
        }
    }
}
