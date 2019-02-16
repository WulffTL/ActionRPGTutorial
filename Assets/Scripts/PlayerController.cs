using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Animator animator;
    private bool isMoving;
    private Vector2 lastMove;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool shouldMoveVertically = (verticalInput != 0 && (horizontalInput == 0 || lastMove.x != 0));
        bool shouldMoveHorizontally = (horizontalInput != 0 && (verticalInput == 0 || lastMove.y != 0));
        isMoving = false;
        if(shouldMoveHorizontally)
        {
            transform.Translate(new Vector3(moveSpeed * horizontalInput * Time.deltaTime, 0f));
            isMoving = true;
            if(verticalInput == 0)
            {
                lastMove = new Vector2(horizontalInput, 0);
            }
        }
        if (shouldMoveVertically)
        {
            transform.Translate(new Vector3(0f, moveSpeed * verticalInput * Time.deltaTime));
            isMoving = true;
            if(horizontalInput == 0)
            {
                lastMove = new Vector2(0, verticalInput);
            }
        }
        animator.SetFloat("MoveX", shouldMoveHorizontally ? horizontalInput : 0);
        animator.SetFloat("MoveY", shouldMoveVertically ? verticalInput : 0);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
        animator.SetBool("IsMoving", isMoving);
    }
}
