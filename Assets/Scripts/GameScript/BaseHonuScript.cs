using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHonuScript : MonoBehaviour
{
    public Rigidbody2D BaseHonuRigidBody;
    public Animator animator;
    public float SwimPower = 10;

    public GameLogicScript GameLogic;
    public bool IsAlive = true;
    float verticalMove = 0f;

    // public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsAlive)
        {
            BaseHonuRigidBody.velocity = Vector2.up * SwimPower;
            verticalMove = 1;
        }
        else if (BaseHonuRigidBody.velocity.y < 1)
        {
            verticalMove = 0;
        }
        animator.SetFloat("Speed", verticalMove);
        // if (transform.position.y > 17 || transform.position.y < -17 )  // off the screen 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     GameLogic.gameOver();
     IsAlive = false;
    }
}
