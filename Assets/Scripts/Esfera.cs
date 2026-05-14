using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro; // CAMBIO: Usamos esta librería para TextMesh Pro

public class Esfera : MonoBehaviour
{
    public float velocidad = 10;
    int Monedas = 0;
    Vector3 checkpointActual;
    Rigidbody MyRigidbody;
public TextMeshProUGUI textoContador;

    [Header("Ajustes de Victoria")]
    public GameObject ventanaVictoria; 
        public TextMeshProUGUI textoMensaje; // CAMBIO: Ahora sí te dejará arrastrar el texto

    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody>();
        checkpointActual = transform.position;
        ActualizarTextoPantalla();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        MyRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad);
    }

    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Checkpoint"))
        {
            checkpointActual = otro.transform.position;
        }
        else if (otro.CompareTag("Enemigo"))
        {
            Monedas = 0; 
            ActualizarTextoPantalla();

            transform.position = checkpointActual;
            MyRigidbody.linearVelocity = Vector3.zero;
            MyRigidbody.angularVelocity = Vector3.zero;
        }
        else if (otro.CompareTag("Salida"))
        {
            if (ventanaVictoria != null)
            {
                ventanaVictoria.SetActive(true);
                textoMensaje.text = "Felicidades, llegaste con " + Monedas + " de 8 monedas. ¿Continuar?";
                
                MyRigidbody.linearVelocity = Vector3.zero;
                Time.timeScale = 0; // Pausa el juego para que no se mueva la esfera atrás
                
                // IMPORTANTE: Si el mouse no aparece, añade esta línea:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else if (otro.CompareTag("Moneda"))
        {
            otro.gameObject.SetActive(false);
            Monedas++;
            ActualizarTextoPantalla();
        }

    }
        void ActualizarTextoPantalla()
            {
                if (textoContador != null)
                {
                    textoContador.text = "Monedas: " + Monedas;
                }
            }

    public void BotonSiguienteNivel()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BotonRegresarMenu() 
    {
        Time.timeScale = 1; // Siempre quita la pausa antes de cambiar de escena
        SceneManager.LoadScene(0); // El 0 suele ser la escena del Menú
    }
}