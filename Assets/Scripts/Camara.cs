using UnityEngine;

public class Camara : MonoBehaviour
{

    public GameObject Esfera;
    Vector3 Distancia;

    void Start()
    {
        Distancia = transform.position - Esfera.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Esfera.transform.position + Distancia;
    }
}



