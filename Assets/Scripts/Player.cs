using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public enum SIDE { Left, Mid, Right };
public class Player : MonoBehaviour
{

    bool isAlive = true;
    public SIDE m_Side = SIDE.Mid;
    float horizontalInput;
    float NewXPos = 0f;
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;
    public float XValue;
    private CharacterController m_char;
    private Animator m_Animator;
    private float x;
    public float SpeedDoge;
    public float JumpPower = 10f;
    private float y;
    public bool InJump;
    public float FwdSpeed = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAlive = true;
        m_char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        if (transform.position.y < -5)
        {
            Die();
        }

        if (SwipeLeft)
        {
            if (!(m_char.isGrounded))
            {
                if (m_char.velocity.y < -0.1f)
                {
                    m_Animator.Play("Falling");
                }
            }
            if (m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Left;
                m_Animator.Play("DodgeLeft");
            }
            else if (m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                m_Animator.Play("DodgeLeft");
            }
        }
        else if (SwipeRight)
        {
            if (!(m_char.isGrounded))
            {
                if (m_char.velocity.y < -0.1f)
                {
                    m_Animator.Play("Falling");
                }
            }
            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Right;
                m_Animator.Play("DodgeRight");
            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
                m_Animator.Play("DodgeRight");
            }
            
        }

        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 moveVector = new Vector3(x - transform.position.x, y*Time.deltaTime, FwdSpeed*Time.deltaTime);
        x = Mathf.Lerp(x,NewXPos, Time.deltaTime*SpeedDoge);
        m_char.Move(moveVector);
        Jump();
    }


    public void Jump()
    {
        if(m_char.isGrounded)
        {
            Debug.Log(m_char.isGrounded);
            if(m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Falling"))
            {
                m_Animator.Play("Landing");
                InJump = false;
            }
            if(SwipeUp)
            {
                y = JumpPower;
                m_Animator.CrossFadeInFixedTime("Jump", 0.1f);
                InJump = true;
            }
        }else
        {
            y -= JumpPower * 2 * Time.deltaTime;
            if(m_char.velocity.y<-0.1f)
            m_Animator.Play("Falling");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if(!isAlive) return;

        if (other.CompareTag("GroundTile")) return;

        if (other.CompareTag("Obstacle"))
        {
            Die();
            Debug.Log("Obstacle Hit!");
        }
    }



    public void Die()
    {
        isAlive = false;
        Debug.Log("hit");
        RestartLevel(); 
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetMoveSpeed(float newSpeedAdjustment)
    {
        FwdSpeed += newSpeedAdjustment;
    }

}
