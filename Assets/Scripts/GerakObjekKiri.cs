using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakObjekKiri : MonoBehaviour
{
    //konsep: setiap perubahan frame, virus bergerak ke kiri

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //mengubah posisi virus, ke kiri (modif sumbu y aja)
        //used Vector3 cuz transform has x,y,z values
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
