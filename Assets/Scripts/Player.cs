using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[System.Serializable]

public enum SIDE { Left, Mid, Right };
public class Player : MonoBehaviour
{

    public SIDE m_Side = SIDE.Mid;
    bool alive = true;
    float horizontalInput;
    float NewXPos = 0f;
    [HideInInspector]
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
        m_char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) return;
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        SwipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        if (SwipeLeft)
        {
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

        if (transform.position.y < -5)
        {
            Die();
        }

        Vector3 moveVector = new Vector3(x - transform.position.x, y*Time.deltaTime, FwdSpeed*Time.deltaTime);
        x = Mathf.Lerp(x,NewXPos, Time.deltaTime*SpeedDoge);
        m_char.Move(moveVector);
        Jump();
    }

    public void Jump()
    {
        if(m_char.isGrounded)
        {
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

    public void Die()
    {
        alive = false;
        Debug.log(alive);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
