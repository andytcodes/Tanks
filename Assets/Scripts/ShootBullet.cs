using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject m_projectile;
    public AudioClip m_shootSound;

    private AudioSource m_source;

    public bool isTurn;
    public bool leftPos;

    void Start()
    {
        m_source = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (isTurn)
            {
                float vol = Random.Range(5, 10);
                m_source.PlayOneShot(m_shootSound, vol);

                int scale = leftPos ? 1 : -1;
                Vector3 pos = new Vector3(transform.position.x+scale, transform.position.y, transform.position.z);
                GameObject shootThis = Instantiate(m_projectile, pos, transform.rotation);
                Rigidbody rb = shootThis.GetComponent<Rigidbody>();

                float force = leftPos ? 1000 : -1000;

                rb.AddRelativeForce(new Vector3(0, 0, force));
                rb.velocity = Vector3.zero;
                rb.angularDrag = 0;
                rb.angularVelocity = Vector3.zero;

                isTurn = false;
            }
            else
            {
                isTurn = true;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (isTurn)
            {
                Vector3 axis = new Vector3(0, 0, (leftPos ? 1 : -1));
                transform.parent.RotateAround(transform.parent.parent.position, axis, (float)0.1);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (isTurn)
            {
                Vector3 axis = new Vector3(0, 0, (leftPos ? -1 : 1));
                transform.parent.RotateAround(transform.parent.parent.position, axis, (float)0.1);
            }
        }
    }
}
