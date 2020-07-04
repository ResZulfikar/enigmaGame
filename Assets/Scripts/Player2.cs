using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player2 : MonoBehaviour
{


    public GameObject peluru;
    public float moveSpeed = 10f;
    public float timer = 2f;
    float acuanTimer;
    // Start is called before the first frame update
    void Start()
    {
        acuanTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //exit ke main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Title");
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.32f, 8.17f), Mathf.Clamp(transform.position.y, -3.18f, 4.34f), 0);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(peluru, transform.position, transform.rotation);
            timer = acuanTimer;
        }
    }

    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical2") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;

        var deltaX = Input.GetAxis("Horizontal2") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;

        transform.position = new Vector2(newXPos, newYPos);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("VirusHanan"))
        {
            SceneManager.LoadScene("Game2");
        }
    }

}
