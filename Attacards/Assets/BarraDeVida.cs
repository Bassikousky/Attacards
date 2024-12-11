using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena.
using UnityEngine.UI; // Necesario para trabajar con botones y UI.
using TMPro;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private float vidaMaximaEnemigo = 100f; // Vida máxima del enemigo.
    [SerializeField] private Transform barraDeVida; // Transform del plano que representa la barra de vida.
    [SerializeField] private GameObject botonCambioEscena; // Botón para cambiar de escena.
    [SerializeField] private GameObject mensajeFinCombate; // Texto que aparece al terminar el combate.
    [SerializeField] private string nombreSiguienteEscena; // Nombre de la siguiente escena.
    [SerializeField] private string idEnemigo; // Identificador único para el enemigo.

    [SerializeField] public TMP_Text healthText; // Asignar el texto del indicador desde el Inspector.
    [SerializeField] public int vidaActualUsuario = 1; // Salud actual del jugador.
    [SerializeField] public int vidaInicialUsuario;
    [SerializeField] private float vidaActualEnemigo;
    [SerializeField] public TMP_Text enemyDamageText;
    [SerializeField] private int enemyDamage;
    [SerializeField] private bool isPlayerTurn = true;
    [SerializeField] private GameObject botonCambioTurno;

    void Start()
    {
        // Inicializa la vida actual como la vida máxima.
        vidaActualEnemigo = vidaMaximaEnemigo;
        ActualizarBarraDeVida();
        InitializeHealth(vidaInicialUsuario);

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

    void Update()
    {
        UpdateHealthText(vidaActualUsuario);
        if (isPlayerTurn)
        {
            TurnoUsuario();
        } else {
            TurnoEnemigo();
        }
    }

    public void TurnoUsuario()
    {
        GenerarDamageEnemigo(); 
        IntencionEnemigo();

        if (botonCambioTurno != null)
        {
            botonCambioTurno.SetActive(true);
        }
    }

    public void TurnoEnemigo()
    {
        if (botonCambioTurno != null)
        {
            botonCambioTurno.SetActive(false);
        }

        TakeDamage(enemyDamage);
        isPlayerTurn = true;
    }

    public void AplicarDaño(float daño)
    {
        // Reduce la vida actual por el daño recibido.
        vidaActualEnemigo -= daño;

        // Asegúrate de que la vida no sea menor que 0.
        vidaActualEnemigo = Mathf.Clamp(vidaActualEnemigo, 0, vidaMaximaEnemigo);

        // Actualiza la escala de la barra de vida.
        ActualizarBarraDeVida();

        // Comprueba si la vida llegó a 0 para terminar el combate.
        if (vidaActualEnemigo <= 0)
        {
            TerminarCombate();
        }
    }

    private void ActualizarBarraDeVida()
    {
        // Calcula el porcentaje de vida restante.
        float porcentajeVida = vidaActualEnemigo / vidaMaximaEnemigo;

        // Ajusta la escala de la barra en el eje X, manteniendo los otros ejes iguales.
        barraDeVida.localScale = new Vector3(porcentajeVida/10, barraDeVida.localScale.y, barraDeVida.localScale.z);
    }

    private void TerminarCombate()
    {
        idEnemigo = PlayerPrefs.GetString("enemigo","enemigo");

        Debug.Log("¡Combate terminado!");

        PlayerPrefs.SetInt(idEnemigo, 1); // 1 significa que el enemigo ha sido derrotado.
        PlayerPrefs.Save();

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

    public void CambiarTurno()
    {
        isPlayerTurn = false;
    }

    public void InitializeHealth(int vidaInicialUsuario)
    {
        vidaActualUsuario = vidaInicialUsuario;
        UpdateHealthText(vidaActualUsuario);
    }

    public void TakeDamage(int damage)
    {
        vidaActualUsuario -= damage; // Reduce la salud.
        vidaActualUsuario = Mathf.Max(vidaActualUsuario, 0); // Asegúrate de que no sea menor a 0.
        UpdateHealthText(vidaActualUsuario);

        if (vidaActualUsuario == 0) {
            //Que vaya a pantalla game over
        }
    }

    // Actualiza el texto del indicador.
    private void UpdateHealthText(int vida)
    {
        if (healthText != null) {
            healthText.text = vida.ToString(); // Actualiza el texto.
        }
        
    }

    private void GenerarDamageEnemigo() 
    {
        enemyDamage = 1;
    }
    private void IntencionEnemigo()
    {
        if (enemyDamageText != null) {
            enemyDamageText.text = enemyDamage.ToString();
        }
    }
    
}
