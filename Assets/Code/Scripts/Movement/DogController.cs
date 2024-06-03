using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    public static DogController sharedInstance;

    [SerializeField] float speed = 3;
    [SerializeField] float gravity = -20;

    private bool isGrounded;
    [HideInInspector] public bool controllingActive;
    [HideInInspector] public bool movementBlocked;

    Vector3 velocity;
    CharacterController controller;
    
    [HideInInspector] public Animator anim;

    private Vector3 current_pos;
    private Vector3 last_pos;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        current_pos = transform.position;
        last_pos = transform.position;
    }

    void Update()
    {
        // Calculate dog speed
        current_pos = transform.position;
        float playerSpeed = (current_pos - last_pos).magnitude/Time.deltaTime;
        last_pos = current_pos;

        anim.SetFloat("speed", playerSpeed);
        
        if (!controllingActive || movementBlocked) return;

        Move();
    }

    private void Move(){
        isGrounded = controller.isGrounded;
        
        Vector3 move = new Vector3(SimpleInput.GetAxis("Horizontal"), 0, SimpleInput.GetAxis("Vertical"));
        controller.Move(move.normalized * Time.deltaTime * speed);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
