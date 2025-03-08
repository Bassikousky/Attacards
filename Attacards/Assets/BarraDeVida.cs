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
    [SerializeField] public TMP_Text healthText; // Texto donde se va a indicar por pantalla la vida actual del usuario.
    [SerializeField] public TMP_Text defensaText; // Texto donde se va a indicar por pantalla los puntos de escudo del usuario.
    [SerializeField] public int vidaActualUsuario; // Salud actual del jugador.
    [SerializeField] public int vidaInicialUsuario; // Salud inicial del jugador.
    [SerializeField] private int defensa; // Puntos de escudo
    [SerializeField] private float vidaActualEnemigo; // Salud actual del enemigo.
    [SerializeField] public TMP_Text enemyDamageText; // Texto donde se va a indicar por pantalla cuanto daño va a realizar el enemigo en su próximo turno.
    [SerializeField] private int enemyDamage; // Daño que va a hacer el enemigo en su turno.
    [SerializeField] private GameObject botonCambioTurno; // Boton para cambiar de turno.
    [SerializeField] public SelectorDeCartas selectorCartas; //Script de las cartas.
    [SerializeField] public GameObject enemigo; //Game object que indica al enemigo común.
    [SerializeField] public GameObject boss; //Game object para el jefe.
    [SerializeField] public AudioClip sonidoHacha; //Sonido de ataque para el enemigo común.
    [SerializeField] public AudioClip sonidoFireball; //Sonido de ataque para el jefe.
    public ActivacionBoss activacionBoss;
    private AudioSource audioSource;

    void Start()
    {
        //Inicializa efectos de sonido
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Inicializa enemigo y su vida
        idEnemigo = PlayerPrefs.GetString("enemigo","enemigo");
        if (idEnemigo == "4") 
        {
            enemigo.SetActive(false);
            boss.SetActive(true);
        } 
        else
        {
            enemigo.SetActive(true);
            boss.SetActive(false);
        }
        vidaActualEnemigo = vidaMaximaEnemigo;
        ActualizarBarraDeVida();

        // Inicializa la vida actual como la vida máxima del usuario.
        InitializeHealth(vidaInicialUsuario);

        // El boton de cambio de turno se activa, ya que al principio, siempre es nuestro turno.
        if (botonCambioTurno != null)
        {
            botonCambioTurno.SetActive(true);
        }

        // Estos dos se desactivan hasta que el usuario gane.
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
        UpdateDefenseText(defensa);
    }

    //Metodo donde se indica que pasa en el turno del usuario.
    public void TurnoUsuario()
    {
        selectorCartas.ResetCartas();
        selectorCartas.ResetUsos();
        GenerarDamageEnemigo(); 
        IntencionEnemigo();

        if (botonCambioTurno != null)
        {
            botonCambioTurno.SetActive(true);
        }
    }

    //Metodo donde se indica que pasa en el turno del usuario.
    public void TurnoEnemigo()
    {
        if (botonCambioTurno != null)
        {
            botonCambioTurno.SetActive(false);
        }

        TakeDamage(enemyDamage);
        if (idEnemigo == "4") // Dependiendo de el enemigo, su ataque sonará de forma diferente.
        {
            audioSource.clip = sonidoFireball;
            audioSource.PlayOneShot(sonidoFireball);
        } else {
            audioSource.clip = sonidoHacha;
            audioSource.PlayOneShot(sonidoHacha);
        }
        defensa = 0;
        TurnoUsuario();
    }

    // Este metodo se activa cuando seleccionamos una carta de ataque.
    public void AplicarDaño(float daño)
    {
        vidaActualEnemigo -= daño;
        vidaActualEnemigo = Mathf.Clamp(vidaActualEnemigo, 0, vidaMaximaEnemigo);
        ActualizarBarraDeVida();

        // Comprueba si la vida llegó a 0 para terminar el combate.
        if (vidaActualEnemigo <= 0)
        {
            TerminarCombate();
        }
    }

    // Este metodo se activa cuando seleccionamos una carta de escudo.
    public void AplicarDefensa(int aumentoDefensa)
    {
        defensa += aumentoDefensa;
    }

    // Cuando atacamos, la barra de vida del enemigo cambiará.
    private void ActualizarBarraDeVida()
    {
        // Calcula el porcentaje de vida restante.
        float porcentajeVida = vidaActualEnemigo / vidaMaximaEnemigo;

        // Ajusta la escala de la barra en el eje X, manteniendo los otros ejes iguales.
        barraDeVida.localScale = new Vector3(porcentajeVida/2, barraDeVida.localScale.y, barraDeVida.localScale.z);
    }

    // Este método se llama cuando la vida del enemigo llega a cero. Se desactiva el botón de pasar turno y se activa el mensaje de victoria y el botón para volver al mundo.
    private void TerminarCombate()
    {
        Debug.Log("¡Combate terminado!");

        PlayerPrefs.SetInt(idEnemigo, 1); // 1 significa que el enemigo ha sido derrotado.
        PlayerPrefs.SetInt("Vida", vidaActualUsuario);
        PlayerPrefs.Save();
        activacionBoss.IncrementaCuentaActivacionBoss();

        if (mensajeFinCombate != null)
        {
            mensajeFinCombate.SetActive(true);
        }
        if (botonCambioTurno != null)
        {
            botonCambioTurno.SetActive(false);
        }
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

    // Setea la vida inicial a la actual.
    public void InitializeHealth(int vidaInicialUsuario)
    {
        vidaActualUsuario = PlayerPrefs.GetInt("Vida", vidaInicialUsuario);
        UpdateHealthText(vidaActualUsuario);
    }

    // Este metodo ocurre cuando termina el turno del enemigo. Recibimos daño dependiendo del poder del ataque y de nuestra defensa.
    public void TakeDamage(int damage)
    {
        int resto = 0;
        resto = defensa - damage;
        if (resto < 0)
        {
            vidaActualUsuario = vidaActualUsuario + resto; // Reduce la salud.
            vidaActualUsuario = Mathf.Max(vidaActualUsuario, 0); 
        }
        UpdateHealthText(vidaActualUsuario);

        if (vidaActualUsuario == 0)
        {
            SceneManager.LoadScene(escenaGameOver);
        }
    }

    // Actualiza el texto del indicador de salud.
    private void UpdateHealthText(int vida)
    {
        if (healthText != null) 
        {
            healthText.text = vida.ToString(); // Actualiza el texto.
        }
    }

    // Actualiza el texto del indicador de escudo.
    private void UpdateDefenseText(int defensa)
    {
        if (defensaText != null)
        {
            if (defensa == 0)
            {
                defensaText.text = "";
            } else
            {
                defensaText.text = defensa.ToString();
            }
        }
    }

    // En el turno del enemigo, este nos hará un daño variable.
    private void GenerarDamageEnemigo() 
    {
        System.Random random = new System.Random();
        // Si el enemigo es el boss, el daño aumenta.
        if (idEnemigo == "4") 
        {
            enemyDamage = random.Next(2, 5);
        }
        else
        {
            enemyDamage = random.Next(1, 4);
        }
    }

    // Actualiza el texto del indicador de ataque enemigo.     
    private void IntencionEnemigo()
    {
        if (enemyDamageText != null) {
            enemyDamageText.text = enemyDamage.ToString();
        }
    }
    
}
