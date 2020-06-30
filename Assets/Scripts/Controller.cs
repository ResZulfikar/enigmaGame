using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private Animator myAnim1;
    private Collider2D myCollider;
    public float kecLoncat = 500f;
    public Text scoreText;
    private float startTime;
    private int sisaLoncat = 2;

    //animasi mati
    private float bunnyHurtTime = -1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnim1 = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (bunnyHurtTime == -1)
        {

            //gerakan setelah space ditekan
            if (Input.GetButtonUp("Jump") && sisaLoncat > 0)
            {
                if (myRigidBody.velocity.y < 0) //not cancel out second jump while falling
                {
                    myRigidBody.velocity = Vector2.zero;
                }

                if (sisaLoncat == 1)
                {
                    myRigidBody.AddForce(transform.up * kecLoncat * 0.75f);
                }
                else
                {

                    myRigidBody.AddForce(transform.up * kecLoncat);
                }
                sisaLoncat--;
            }

            //animator set velocity karakter terhadap sumbu y
            myAnim1.SetFloat("vVelocity", myRigidBody.velocity.y);
            //menampilan score berdasarkan waktu
            scoreText.text = (Time.time - startTime).ToString("0.0");
        }
        else
        {
            if (Time.time > bunnyHurtTime + 2)
            {
                Application.LoadLevel(Application.loadedLevel);

            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            foreach (PrefabsSpawner spawner in FindObjectsOfType<PrefabsSpawner>())
            {
                spawner.enabled = false;
            }

            foreach (GerakObjekKiri gerakKiri in FindObjectsOfType<GerakObjekKiri>())
            {
                gerakKiri.enabled = false;
            }

            bunnyHurtTime = Time.time + 1;
            myAnim1.SetBool("bunnyHurt", true);

            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(transform.up * kecLoncat);
            myCollider.enabled = false;

        }
        //control game play max dua kali loncat
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            sisaLoncat = 2;
        }
    }
}
