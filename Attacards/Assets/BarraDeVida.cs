using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena.
using UnityEngine.UI; // Necesario para trabajar con botones y UI.
using TMPro;
using System;

public class BarraDeVida : MonoBehaviour
{
    [SerializeField] private float vidaMaximaEnemigo = 100f; // Vida máxima del enemigo.
    [SerializeField] private Transform barraDeVida; // Transform del plano que representa la barra de vida.
    [SerializeField] private GameObject botonCambioEscena; // Botón para cambiar de escena.
    [SerializeField] private GameObject mensajeFinCombate; // Texto que aparece al terminar el combate.
    [SerializeField] private string nombreSiguienteEscena; // Nombre de la siguiente escena.
    [SerializeField] private string escenaGameOver; // Nombre de la siguiente escena.
    [SerializeField] private string idEnemigo; // Identificador único para el enemigo.

    [SerializeField] public TMP_Text healthText; // Asignar el texto del indicador desde el Inspector.
    [SerializeField] public int vidaActualUsuario; // Salud actual del jugador.
    [SerializeField] public int vidaInicialUsuario;
    [SerializeField] private int defensa;
    [SerializeField] private float vidaActualEnemigo;
    [SerializeField] public TMP_Text enemyDamageText;
    [SerializeField] private int enemyDamage;
    [SerializeField] private GameObject botonCambioTurno;
    [SerializeField] public SelectorDeCartas selectorCartas;

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
        TurnoUsuario();
    }

    void Update()
    {
        UpdateHealthText(vidaActualUsuario);
    }

    public void TurnoUsuario()
    {
        selectorCartas.ResetCartas();
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
        if (vidaActualUsuario == 0)
        {
            SceneManager.LoadScene(escenaGameOver);
        }
        defensa = 0;
        TurnoUsuario();
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

    public void AplicarDefensa(int defensa)
    {
        this.defensa = defensa;
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
        PlayerPrefs.SetInt("Vida", vidaActualUsuario);
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

    public void InitializeHealth(int vidaInicialUsuario)
    {
        vidaActualUsuario = PlayerPrefs.GetInt("Vida", vidaInicialUsuario);
        UpdateHealthText(vidaActualUsuario);
    }

    public void TakeDamage(int damage)
    {
        int resto = 0;
        resto = defensa - damage;
        if (resto < 0)
        {
            vidaActualUsuario = vidaActualUsuario + resto; // Reduce la salud.
            vidaActualUsuario = Mathf.Max(vidaActualUsuario, 0); // Asegúrate de que no sea menor a 0.
        }
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
        System.Random random = new System.Random();
        enemyDamage = random.Next(1, 4);
    }
    private void IntencionEnemigo()
    {
        if (enemyDamageText != null) {
            enemyDamageText.text = enemyDamage.ToString();
        }
    }
    
}
