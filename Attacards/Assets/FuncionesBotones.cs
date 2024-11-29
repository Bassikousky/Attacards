using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class FuncionesBotones : MonoBehaviour
{
    public string escenaInicio;
    public string escenaMenu;


    public void empezarJuego()
    {
        Debug.Log("Empezar juego");
        if (!string.IsNullOrEmpty(escenaInicio))
        {
            SceneManager.LoadScene(escenaInicio);
        }
        else
        {
            Debug.LogError("No se ha especificado el nombre de la escena a cargar.");
        }
    }

    public void salirJuego()
    {
        Debug.Log("Salir del juego");
        Application.Quit();

    }

    public void volverMenu()
    {
        if (!string.IsNullOrEmpty(escenaMenu))
        {
            SceneManager.LoadScene(escenaMenu);
        }
        else
        {
            Debug.LogError("No se ha especificado el nombre de la escena a cargar.");
        }
    } 
}
