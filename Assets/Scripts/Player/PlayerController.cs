using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector3 m_Velocity;
    [SerializeField] private Vector3 m_Speed;
    // Start is called before the first frame update
    [SerializeField] KeyCode keyUp;
    [SerializeField] KeyCode keyDown;
    [SerializeField] KeyCode keyLeft;
    [SerializeField] KeyCode keyRight;
    bool isGrounded = false;
    void Start()
    {
        m_Velocity = GetComponent<Rigidbody>().velocity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        m_Velocity = GetComponent<Rigidbody>().velocity;
        if (Input.GetKey(keyUp))
            m_Velocity.z += m_Speed.z;
        if (Input.GetKey(keyDown))
            m_Velocity.z -= m_Speed.z;
        if (Input.GetKey(keyLeft))
            m_Velocity.x -= m_Speed.x;
        if (Input.GetKey(keyRight))
            m_Velocity.x += m_Speed.x;
        m_Velocity.y = GetComponent<Rigidbody>().velocity.y;
        GetComponent<Rigidbody>().velocity = m_Velocity;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
