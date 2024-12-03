using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena.
using UnityEngine.UI; // Necesario para trabajar con botones y UI.

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 100f; // Vida máxima del enemigo.
    [SerializeField] private Transform barraDeVida; // Transform del plano que representa la barra de vida.
    [SerializeField] private GameObject botonCambioEscena; // Botón para cambiar de escena.
    [SerializeField] private GameObject mensajeFinCombate; // Texto que aparece al terminar el combate.
    [SerializeField] private string nombreSiguienteEscena; // Nombre de la siguiente escena.

    private float vidaActual;

    void Start()
    {
        // Inicializa la vida actual como la vida máxima.
        vidaActual = vidaMaxima;
        ActualizarBarraDeVida();

        // Asegúrate de que el botón está desactivado al inicio.
        if (botonCambioEscena != null)
        {
            botonCambioEscena.SetActive(false);
        }
        if (mensajeFinCombate != null)
        {
            mensajeFinCombate.SetActive(false);
        }
    }

    public void AplicarDaño(float daño)
    {
        // Reduce la vida actual por el daño recibido.
        vidaActual -= daño;

        // Asegúrate de que la vida no sea menor que 0.
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        // Actualiza la escala de la barra de vida.
        ActualizarBarraDeVida();

        // Comprueba si la vida llegó a 0 para terminar el combate.
        if (vidaActual <= 0)
        {
            TerminarCombate();
        }
    }

    private void ActualizarBarraDeVida()
    {
        // Calcula el porcentaje de vida restante.
        float porcentajeVida = vidaActual / vidaMaxima;

        // Ajusta la escala de la barra en el eje X, manteniendo los otros ejes iguales.
        barraDeVida.localScale = new Vector3(porcentajeVida/10, barraDeVida.localScale.y, barraDeVida.localScale.z);
    }

    private void TerminarCombate()
    {
        Debug.Log("¡Combate terminado!");

        if (mensajeFinCombate != null)
        {
            mensajeFinCombate.SetActive(true);
        }

        // Activa el botón de cambio de escena si está configurado.
        if (botonCambioEscena != null)
        {
            botonCambioEscena.SetActive(true);
        }
    }

    // Método para cambiar de escena llamado desde el botón.
    public void CambiarEscena()
    {
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}
