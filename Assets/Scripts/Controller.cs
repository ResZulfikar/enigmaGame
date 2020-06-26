using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private Animator myAnim1;
    private Collider2D myCollider;
    public float kecLoncat = 500f;

    //animasi mati
    private float bunnyHurtTime = -1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim1 = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bunnyHurtTime == -1)
        {

            //gerakan setelah space ditekan
            if (Input.GetButtonUp("Jump"))
            {
                myRigidBody.AddForce(transform.up * kecLoncat);
            }

            //animator set velocity karakter terhadap sumbu y
            myAnim1.SetFloat("vVelocity", myRigidBody.velocity.y);
        }
        else
        {
            if(Time.time > bunnyHurtTime + 1)
            {
                Application.LoadLevel(Application.loadedLevel);
                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            foreach(PrefabsSpawner spawner in FindObjectsOfType<PrefabsSpawner>())
            {
                spawner.enabled = false;
            }

            foreach(GerakObjekKiri gerakKiri in FindObjectsOfType<GerakObjekKiri>())
            {
                gerakKiri.enabled = false;
            }

            bunnyHurtTime = Time.time + 1;
            myAnim1.SetBool("bunnyHurt", true);

            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(transform.up * kecLoncat);
            myCollider.enabled = false;

        }

    }
}
