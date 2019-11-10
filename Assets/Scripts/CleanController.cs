using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanController : MonoBehaviour
{
    [Header("Input Variables")]
    public float moveSpeed = .1f;
    public float normalJumpForce = 3500f;
    public float superJumpForce = 5000f;
    public float combustionCoolDown = 1f;

    [Header("References")]
    public GameObject rotationAxis, combustionPrefab;

    [HideInInspector]
    public Rigidbody2D p1;
    public Vector3 m_EulerAngleVelocity;

    // Private
    private float moveHorizontal, verticalAxis, moveX, jumpForce, currentTime;
    public int moveDirX, moveDirY;
    private bool jumped = false;
    private Vector3 deltaMove = new Vector3();
    private Animator anim;
    
    
    private void OnGUI()
    {
        Event e = Event.current;

        if (e.isKey)
        {
            // Vanlig input
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                Jump(normalJumpForce);
                Ability_Comb();
                Ability_BlackHole();
            }
            else // Speciell input
            {
                Jump(superJumpForce);
                Ability_Comb();
                Ability_BlackHole();
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        if (moveHorizontal > 0)
        {
            anim.SetBool("IsRunning", true);
            moveX = 1f;
            var angles = transform.rotation.eulerAngles;
            angles.y = 180;
            p1.transform.rotation = Quaternion.Euler(angles);

        }
        else if (moveHorizontal < 0)
        {
            anim.SetBool("IsRunning", true);
            moveX = -1f;
            var angles = transform.rotation.eulerAngles;
            angles.y = 0;
            p1.transform.rotation = Quaternion.Euler(angles);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            moveX = 0f;
        }

        p1.transform.position = new Vector3(p1.transform.position.x + moveX * moveSpeed, p1.transform.position.y, p1.transform.position.z);
    }

    void Ability_Comb()
    {
        if(Input.GetKeyDown(KeyCode.H) && Time.time - currentTime >= combustionCoolDown)
        {
            //anim.SetBool("",true);
            GameObject Combustion = Instantiate(combustionPrefab, transform);
            Combustion.SetActive(true);
            Combustion.transform.SetParent(null);
            currentTime = Time.time;
        }
    }

    void Ability_BlackHole()
    {

    }

    void Jump(float jumpForceWanted)
    {
        jumpForce = jumpForceWanted;

        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            jumped = true;
            anim.SetBool("IsJumping", true);
            Debug.Log(jumpForce);
            p1.AddForce(new Vector2(0f, jumpForce));
        }
    }


    void ResetJump()
    {
        jumped = false;
        anim.SetBool("IsJumping", false);
    }

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        p1 = GetComponent<Rigidbody2D>();
        currentTime = 0f;

        //Set the axis the Rigidbody rotates in (100 in the y axis)
        m_EulerAngleVelocity = new Vector3(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            ResetJump();
        }
    }
    // Kollar inputs och sätter variabler + animation.

    // Reset jump

    // 
}
