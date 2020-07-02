using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical2") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;

        var deltaX = Input.GetAxis("Horizontal2") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;

        transform.position = new Vector2(newXPos, newYPos);
        
    }
}
