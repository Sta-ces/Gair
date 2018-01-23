using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControler : MonoBehaviour {

    [Header("Character Parameters")]
    [Range(1f, 20f)]
    public float m_speedWalking = 5f;
    [Range(1f, 10f)]
    public float m_higherJump = 5f;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movement();
    }


    private void Movement()
    {
        // RIGHT and LEFT - HORIZONTAL
        float m_moveHorizontal = Input.GetAxisRaw("Horizontal") * m_speedWalking;

        if ( m_moveHorizontal == 0f )
            m_moveHorizontal = 0f;


        // JUMP - VERTICAL
        float m_jumping = m_rigidbody.velocity.y;
        RaycastHit hitInfo;

        if ( Physics.Raycast(transform.position, Vector3.down, out hitInfo) )
        {
            if ( hitInfo.distance == 1f && Input.GetButtonDown("Jump") )
                m_jumping = m_higherJump;
            else
                m_jumping = m_rigidbody.velocity.y;
        }


        m_rigidbody.velocity = new Vector2( m_moveHorizontal, m_jumping );
    }


    private Rigidbody m_rigidbody;
}
