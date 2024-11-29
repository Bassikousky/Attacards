using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class FuncionesBotones : MonoBehaviour
{
    public string escenaInicio;
    

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
    }
}
