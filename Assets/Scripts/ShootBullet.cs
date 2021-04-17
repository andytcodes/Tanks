using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject m_projectile;
    public AudioClip m_shootSound;

    private AudioSource m_source;

    public bool isTurn;

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
                GameObject shootThis = Instantiate(m_projectile, transform.position, transform.rotation);
                Rigidbody rb = shootThis.GetComponent<Rigidbody>();
                rb.AddRelativeForce(new Vector3(0, 0, 2000));

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
                transform.Rotate((float)-0.1, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (isTurn)
            {
                transform.Rotate((float)0.1, 0, 0);
            }
        }
    }
}
