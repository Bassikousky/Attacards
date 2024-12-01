using UnityEngine;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private float vidaMaxima = 100f; // Vida máxima del enemigo.
    [SerializeField] private Transform barraDeVida; // Transform del plano que representa la barra de vida.

    private float vidaActual;

    void Start()
    {
        // Inicializa la vida actual como la vida máxima.
        vidaActual = vidaMaxima;
        ActualizarBarraDeVida();
    }

    public void AplicarDaño(float daño)
    {
        // Reduce la vida actual por el daño recibido.
        vidaActual -= daño;

        // Asegurarse de que la vida no sea menor que 0.
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        // Actualiza la escala de la barra de vida.
        ActualizarBarraDeVida();
    }

    private void ActualizarBarraDeVida()
    {
        // Calcula el porcentaje de vida restante.
        float porcentajeVida = vidaActual / vidaMaxima;

        // Ajusta la escala de la barra en el eje X, manteniendo los otros ejes iguales.
        barraDeVida.localScale = new Vector3(porcentajeVida/10, barraDeVida.localScale.y, barraDeVida.localScale.z);
    }
}
