using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    private Vector3 destination;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

            if (transform.position.x > destination.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (transform.position.x < destination.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    public void SetDestination(Vector3 target)
    {
        destination = target;
    }

    public void StopMovement()
    {
        destination = transform.position;
    }
}
