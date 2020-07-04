using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeluruMovement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("VirusHanan"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
