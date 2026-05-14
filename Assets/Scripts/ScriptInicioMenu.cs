using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptInicioMenu : MonoBehaviour
{
public GameObject Menu;
public GameObject Opciones;
public AudioSource miMusica;

public void AbrirOpciones()
    {
        Opciones.SetActive(true);
        Menu.SetActive(false);
    }

    public void RegresarMenu()
    {
        Menu.SetActive(true);
        Opciones.SetActive(false);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void CambiarEscena()
 {
        SceneManager.LoadScene("Nivel 1");
    }
    
public void CambiarVolumen(float valor)
    {
        miMusica.volume = valor;
    }

    public void OnOffMusica(bool estado)
    {
        miMusica.mute = !estado;
    }
}
