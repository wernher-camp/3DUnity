using UnityEngine;
using System.Collections;
    



public class Esfera : MonoBehaviour


{

public float velocidad = 10;
int Monedas =0;
   Vector3 checkpointActual;
    Rigidbody MyRigidbody;
 

    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        checkpointActual = transform.position;
        
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        MyRigidbody.AddForce(new Vector3(horizontal,0,vertical) * velocidad);
    
    }

   void OnTriggerEnter(Collider otro)
    {
        //  Si se toca la esfera aparece en el ultimo check
        if (otro.CompareTag("Checkpoint"))
        {
            checkpointActual = otro.transform.position;
            Debug.Log("Checkpoint alcanzado " );
        }

        // cuando pierde se transporta al ultimo check
        else if (otro.CompareTag("Enemigo"))
        {

            transform.position = checkpointActual;
            
            // Se elimina velocidad y rotacion para que no avance
            MyRigidbody.linearVelocity = Vector3.zero;
            MyRigidbody.angularVelocity = Vector3.zero;
            
            Debug.Log("Has perdido. Reapareciendo en el último punto, cuidado con los enemigos");
        }

        //  se manda mensaje cuando pasas cada punto
        else if (otro.CompareTag("Salida"))
        {
            Debug.Log("Felicidades, has llegado con " + Monedas + " monedas y continuas al siguiente nivel");
        }
        else if (otro.CompareTag("Moneda"))
        {
            otro.gameObject.SetActive(false);
            Monedas++;
        }
    }
}