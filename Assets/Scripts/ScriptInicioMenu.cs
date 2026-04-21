using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptInicioMenu : MonoBehaviour
{
public GameObject Menu;
public GameObject Opciones;

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
        SceneManager.LoadScene("Juego");
    }
    
}
