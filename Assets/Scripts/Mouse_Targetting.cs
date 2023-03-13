 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Targetting : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Character_Movement playerMovement;
    private Character_Attack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<Character_Movement>();
        playerAttack = player.GetComponent<Character_Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if(hit.collider != null)
            {
                switch (hit.collider.tag)
                {
                    case "Attackable":
                        playerMovement.StopMovement();
                        playerAttack.SetTarget(hit.collider.gameObject);
                        break;

                    default:
                        playerMovement.SetDestination(mousePos);
                        playerAttack.ClearTarget();
                        break;
                }
            }
            else
            {
                playerMovement.SetDestination(mousePos);
                playerAttack.ClearTarget();
            }
            
        }
    }
}
