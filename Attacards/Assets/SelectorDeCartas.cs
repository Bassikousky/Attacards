using UnityEngine;

public class SelectorDeCartas : MonoBehaviour
{
    [SerializeField] private BarraDeVida barraDeVida; // Referencia a la barra de vida del enemigo.
    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;
    public GameObject carta4;
    public GameObject carta5;

    private int defensa;


    public void SeleccionarOpcion(int opcion)
    {
        // Define los daños asociados a cada opción (carta).
        float daño = 0;
        

        switch (opcion)
        {
            case 1: // Carta 1
                daño = 10f; // Daño bajo.
                carta1.SetActive(false);
                break;
            case 2: // Carta 2
                daño = 25f; // Daño medio.
                carta2.SetActive(false);
                break;
            case 3: // Carta 3
                daño = 50f; // Daño alto.
                carta3.SetActive(false);
                break;
            case 4:
                defensa += 1;
                carta4.SetActive(false);
                break;
            case 5:
                defensa += 1;
                carta5.SetActive(false);
                break;
            default:
                Debug.LogWarning("Opción no válida.");
                return;
        }

        // Aplica el daño al enemigo.
        barraDeVida.AplicarDaño(daño);
        barraDeVida.AplicarDefensa(defensa);
    }

    public void ResetCartas()
    {
        carta1.SetActive(true);
        carta2.SetActive(true);
        carta3.SetActive(true);
        carta4.SetActive(true);
        carta5.SetActive(true);
    }
}
