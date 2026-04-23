using UnityEngine;
using System.Collections;
    



public class Esfera : MonoBehaviour


{

public float velocidad = 10;
int Monedas =0;
    Vector3 positionInicial;
    Rigidbody MyRigidbody;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        positionInicial = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        MyRigidbody.AddForce(new Vector3(horizontal,0,vertical) * velocidad);
    
    }

    void OnTriggerEnter(Collider otro){
        if (otro.CompareTag("Salida"))
        {
           Debug.Log ("Felicidades, has llegao y has recolectado " + Monedas + " monedas");
        }
        else if (otro.CompareTag("Enemigo"))
        {
            MyRigidbody.MovePosition(positionInicial);
            MyRigidbody.linearVelocity = Vector3.zero;
            MyRigidbody.angularVelocity = Vector3.zero;
            Monedas = 0;
        }
        else if (otro.CompareTag("Moneda"))
        {
            otro.gameObject.SetActive(false);
            Monedas= Monedas+1;
        }
    }
    
}
