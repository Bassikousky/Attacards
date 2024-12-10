using UnityEngine;
using UnityEngine.UI; // Para manejar botones y texto
using TMPro;

public class Combate : MonoBehaviour
{
    public HealthIndicator healthIndicator;
    public BarraDeVida barraDeVida;



    public int playerHealth;
    public float enemyHealth;

    public int playerDamage = 20; // Daño que el jugador inflige
    public int enemyDamage = 15;  // Daño que el enemigo inflige

    public Text turnText;         // Texto que muestra el turno actual
    public Text playerHealthText; // Texto que muestra la salud del jugador
    public Text enemyHealthText;  // Texto que muestra la salud del enemigo
    public TMP_Text enemyDamageText;  // Texto que muestra el daño que va a hacer el enemigo

    public Button endTurnButton;  // Botón para terminar el turno del jugador

    private bool isPlayerTurn = true; // Determina si es el turno del jugador o del enemigo

    void Start()
    {
        // Configurar los valores iniciales
        playerHealth = healthIndicator.vidaInicial;
        enemyHealth = barraDeVida.GetVidaEnemigo();
        UpdateUI();
        endTurnButton.onClick.AddListener(EndPlayerTurn); // Asociar la función al botón
    }

    void Update()
    {
        if (isPlayerTurn)
        {
            // Durante el turno del jugador, muestra el daño que el enemigo va a hacer
            enemyDamageText.text = enemyDamage.ToString();
        }
    }

    // Termina el turno del jugador y pasa al turno del enemigo
    void EndPlayerTurn()
    {
        if (!isPlayerTurn) return; // No hacer nada si no es el turno del jugador

        // Aplicar daño al enemigo
        enemyHealth -= playerDamage;

        // Comprobar si el enemigo ha sido derrotado
        if (enemyHealth <= 0)
        {
            enemyHealth = 0;
            turnText.text = "¡El jugador ha ganado!";
            return;
        }

        // Actualizar la UI
        UpdateUI();

        // Cambiar el turno
        isPlayerTurn = false;
        turnText.text = "Es el turno del enemigo.";

        // Comenzar el turno del enemigo
        Invoke("EnemyTurn", 1f); // Después de 1 segundo, se inicia el turno del enemigo
    }

    // Durante el turno del enemigo, el jugador recibe daño
    void EnemyTurn()
    {
        if (isPlayerTurn) return; // No hacer nada si es el turno del jugador

        // Aplicar daño al jugador
        playerHealth -= enemyDamage;

        // Comprobar si el jugador ha sido derrotado
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            turnText.text = "¡El enemigo ha ganado!";
            return;
        }

        // Actualizar la UI
        UpdateUI();

        // Cambiar al turno del jugador
        isPlayerTurn = true;
        turnText.text = "Es el turno del jugador.";
    }

    // Actualizar los textos de la UI
    void UpdateUI()
    {
        playerHealthText.text = $"Salud del jugador: {playerHealth}";
        enemyHealthText.text = $"Salud del enemigo: {enemyHealth}";
    }
}
