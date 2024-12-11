using UnityEngine;

public class SelectorDeCartas : MonoBehaviour
{
    [SerializeField] private BarraDeVida barraDeVida; // Referencia a la barra de vida del enemigo.

    public void SeleccionarOpcion(int opcion)
    {
        // Define los daños asociados a cada opción (carta).
        float daño = 0;

        switch (opcion)
        {
            case 1: // Carta 1
                daño = 10f; // Daño bajo.
                break;
            case 2: // Carta 2
                daño = 25f; // Daño medio.
                break;
            case 3: // Carta 3
                daño = 50f; // Daño alto.
                break;
            default:
                Debug.LogWarning("Opción no válida.");
                return;
        }

        // Aplica el daño al enemigo.
        barraDeVida.AplicarDaño(daño);
        
    }
}
