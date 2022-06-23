using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    private Vector2 moveInput;

    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        bool success = MovePlayer(moveInput);


        if(!success){
            success = MovePlayer(new Vector2(moveInput.x, 0));

            if(!success){
                success = MovePlayer(new Vector2(0, moveInput.y));
                }
            }


            if(moveInput.x != 0){
                if(moveInput.x > 0){
                    print("Show Right");
                }else{
                    print("Show Left");
                }
            }


        }

        
   

    // Update is called once per frame
    /*void Update()
    {
        Vector3 pos = transform.position;
 
         if (Input.GetKey ("w")) {
             pos.y += moveSpeed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.y -= moveSpeed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             pos.x += moveSpeed * Time.deltaTime;
         }
         if (Input.GetKey ("a")) {
             pos.x -= moveSpeed * Time.deltaTime;
         }
             
 
         transform.position = pos;
    }
   */
    public bool MovePlayer(Vector2 direction){
       
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );
        if(count == 0){
            Vector2 moveVector = direction * moveSpeed * Time.fixedDeltaTime;


            // No collisions
            rb.MovePosition(rb.position + moveVector);
            return true;
        }
        else{
            // Print Collissions
            foreach (RaycastHit2D hit in castCollisions){
                print(hit.ToString());                
            }

            return false;
        }
    }


    void PhysicsUpdate(){
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    
    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

}