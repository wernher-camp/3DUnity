using UnityEngine;
using System.Collections;
    



public class Esfera : MonoBehaviour


{

public float velocidad = 10;

    Rigidbody MyRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        MyRigidbody.AddForce(new Vector3(horizontal,0,vertical) * velocidad);
    
    }
}
