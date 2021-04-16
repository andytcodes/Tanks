using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject m_projectile;
    public AudioClip m_shootSound;

    private AudioSource m_source;
    //once the shot hits the tank, switch the roles around

    void Start()
    {
        m_source = GetComponent<AudioSource>();
    }

    void Update()
    {

        if(this.tag == "Player")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                float vol = Random.Range(5, 10);
                m_source.PlayOneShot(m_shootSound, vol);
                GameObject shootThis = Instantiate(m_projectile, transform.position, transform.rotation);
                Rigidbody rb = shootThis.GetComponent<Rigidbody>();
                rb.AddRelativeForce(new Vector3(0, 0, 2000));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //angle the gun up
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //angle the gun down
            }
        }
        //else Enemy and they don't have controls
    }
}
