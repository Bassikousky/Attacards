using UnityEngine;
using TMPro;

public class HealthIndicator : MonoBehaviour
{
    public TMP_Text healthText; // Asignar el texto del indicador desde el Inspector.
    public int currentHealth; // Salud actual del jugador.
    public int vidaInicial;

    void Start()
    {
        InitializeHealth(vidaInicial);
    }
    // Configura la salud inicial.
    public void InitializeHealth(int startingHealth)
    {
        currentHealth = startingHealth;
        UpdateHealthText();
    }

    // Método para aplicar daño.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce la salud.
        currentHealth = Mathf.Max(currentHealth, 0); // Asegúrate de que no sea menor a 0.
        UpdateHealthText();

        if (currentHealth == 0) {
            //Que vaya a pantalla game over
        }
    }

    // Actualiza el texto del indicador.
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString(); // Actualiza el texto.
        }
    }
}
