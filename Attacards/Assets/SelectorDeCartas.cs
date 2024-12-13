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
    private int damage;
    private int limiteUsoCartas = 3;
    private int usos = 0;


    public void SeleccionarOpcion(int opcion)
    {
            switch (opcion)
            {
                case 1: // Carta 1
                    barraDeVida.AplicarDaño(GenerarDamage());
                    carta1.SetActive(false);
                    break;
                case 2: // Carta 2
                    barraDeVida.AplicarDaño(GenerarDamage());
                    carta2.SetActive(false);
                    break;
                case 3: // Carta 3
                    barraDeVida.AplicarDaño(GenerarDamage());
                    carta3.SetActive(false);
                    break;
                case 4: // Carta 4
                    barraDeVida.AplicarDefensa(1);
                    carta4.SetActive(false);
                    break;
                case 5: // Carta 5
                    barraDeVida.AplicarDefensa(1);
                    carta5.SetActive(false);
                    break;
                default:
                    Debug.LogWarning("Opción no válida.");
                    return;
            }

        usos++;
        if (usos == limiteUsoCartas)
        {
            HideCartas();
            usos = 0;
        }
    }

    public void ResetCartas()
    {
        carta1.SetActive(true);
        carta2.SetActive(true);
        carta3.SetActive(true);
        carta4.SetActive(true);
        carta5.SetActive(true);
    }

    public void HideCartas()
    {
        carta1.SetActive(false);
        carta2.SetActive(false);
        carta3.SetActive(false);
        carta4.SetActive(false);
        carta5.SetActive(false);
    }

    private int GenerarDamage() 
    {
        System.Random random = new System.Random();
        damage = random.Next(1, 26);
        return damage; 
    }
}
