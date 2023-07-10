using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float groundDrag;
    public float movementSpeed;

    [Header("Player Components")]
    private GameObject playerObject;
    private PlayerMovement playerAttributes;

    [Header("Animation")]
    public Animator animator;

    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerAttributes = playerObject.GetComponent<PlayerMovement>();
        rb.freezeRotation = true;
        
        rb = this.GetComponent<Rigidbody>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAttributes.grounded)
        {            
            // TODO: Hit player
            // TODO: Knockback when hit by player

            MoveToPlayer();
        }

        // Animation variables
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void MoveToPlayer()
    {
        this.transform.LookAt(playerObject.transform.position);
        
        rb.AddForce(this.transform.forward * movementSpeed * 10f, ForceMode.Force);
        rb.drag = groundDrag;
    }
}
