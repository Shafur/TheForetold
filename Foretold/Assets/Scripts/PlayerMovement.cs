using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sprint;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private bool isDashing = false;
    private bool canDash = true;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash == true)
        {
            StartCoroutine(Dash());
        }

        change = Vector3.zero;

        float currentSpeed = isDashing ? sprint : speed;

        change.x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * currentSpeed;
        change.y = Input.GetAxisRaw("Vertical") * Time.deltaTime * currentSpeed;
        UpdateAnimationAndMove();
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)

        {
            MoveCharacter();
            // animator.SetFloat("moveX", change.x);
            // animator.SetFloat("moveY", change.y);
            // animator.SetBool("moving", true);
            transform.Translate(new Vector3(change.x, change.y));
        }
        // else
        // {
        //     animator.SetBool("moving", false);
        // }
    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
                 transform.position + change * speed * Time.deltaTime);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(.4f);
        isDashing = false;
        yield return new WaitForSeconds(.25f);
        canDash = true;
    }
       
}