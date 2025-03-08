# Attacards

## Descripción

Attacards es un juego de aventuras y estrategia por turnos ambientado en un mundo abierto. Explora un vasto territorio, enfréntate a enemigos en intensos combates por turnos y utiliza cartas para atacar, defenderte y desatar habilidades especiales. ¿Podrás derrotar al jefe final y convertirte en el campeón definitivo?

## NOVEDADES

*   **Nuevo sistema de ataque:** Ahora el ataque enemigo varía de forma aleatoria en cada turno, añadiendo un elemento de imprevisibilidad y desafío estratégico.
*   **Nuevos efectos de sonido:** El uso de cartas y los ataques enemigos ahora cuentan con diferentes efectos de sonido, mejorando la inmersión y la experiencia de juego.
*   **Jefe final:** El jefe final se desbloquea una vez que todos los enemigos comunes han sido derrotados, proporcionando un desafío final y una meta clara para el jugador.

## Características Principales

*   **Mundo Abierto:** Explora un mundo extenso y descubre secretos ocultos.
*   **Combate por Turnos Basado en Cartas:** Utiliza una mano de 5 cartas por turno para realizar ataques, defensas y otras acciones estratégicas.
*   **Sistema de Salud:** Tanto el jugador como los enemigos tienen una barra de salud que determina la victoria o la derrota.
*   **Jefe Final:** Enfréntate a un jefe final desafiante que pondrá a prueba tus habilidades y estrategias.
*   **Rejugabilidad:** Si pierdes, ¡vuelve a intentarlo! Aprende de tus errores y mejora tus estrategias en cada partida.

## Cómo Jugar

1.  **Exploración:** Utiliza las teclas WASD para moverte por el mundo abierto.
2.  **Combate:** Al entrar en contacto con un enemigo, el juego cambiará a la fase de combate por turnos.
3.  **Selección de Cartas:** Utiliza el ratón para seleccionar las cartas de tu mano (5 cartas). Haz clic en la carta que deseas usar y luego confirma tu selección.
4.  **Estrategia:** Planifica tus turnos cuidadosamente, teniendo en cuenta los ataques y defensas disponibles en tus cartas.
5.  **Objetivo:** Reduce la salud del enemigo a cero para ganar el combate y regresa al mundo abierto. Si tu salud llega a cero, ¡Game Over!

## Controles

*   **Movimiento del Personaje:**
    *   `W`: Mover hacia adelante
    *   `A`: Mover hacia la izquierda
    *   `S`: Mover hacia atrás
    *   `D`: Mover hacia la derecha
    *   `Espacio` : Saltar

*   **Selección de Cartas (Combate):**
    *   `Ratón`: Clic para seleccionar la carta deseada y clic para confirmar.

## Scripts del Juego

A continuación, se describen los scripts principales que componen el juego, incluyendo una descripción detallada de su funcionalidad e intención:

*   **`EnemyAI.cs`:**
    *   **Descripción:** Este script controla el comportamiento de la Inteligencia Artificial (IA) de los enemigos en el mundo abierto. Define cómo el enemigo detecta al jugador, lo persigue y, en última instancia, lo obliga a entrar en la zona de combate. La velocidad de persecución y el objetivo de la persecución (el jugador) son configurables a través del Inspector de Unity.
    *   `public Transform player`: Asigna el objeto del jugador para que el enemigo lo persiga. Esto se hace arrastrando el objeto del jugador al campo correspondiente en el Inspector.
    *   `public float speed`: Determina la velocidad a la que el enemigo se mueve mientras persigue al jugador. Ajustar este valor permite controlar la dificultad y el comportamiento del enemigo.
    *   `StartChasingPlayer()`: Este método se llama para iniciar la persecución del jugador. Activa el comportamiento de persecución del enemigo.
    *   `StopChasingPlayer()`: Este método se llama para detener la persecución del jugador. Detiene el movimiento del enemigo y su comportamiento de persecución.
    *   **Intención:** El propósito principal de este script es crear un comportamiento de enemigo dinámico y desafiante en el mundo abierto, animando al jugador a entrar en la fase de combate y añadiendo una capa de peligro a la exploración.

*   **`EnemyTriggerZone.cs`:**
    *   **Descripción:** Este script es responsable de gestionar la transición entre el mundo abierto y la escena de combate. Detecta cuando el jugador entra en una zona específica alrededor del enemigo (la "zona de activación"), desactiva el control manual de la cámara en el mundo abierto y mueve la cámara hacia el enemigo para crear una escena dramática antes de cargar la escena de combate. También guarda la posición del jugador en el mundo abierto para que pueda volver al mismo lugar después del combate. Utiliza `PlayerPrefs` para persistir información sobre si el enemigo ha sido derrotado y así evitar que reaparezca.
    *   `public Transform enemy`: El `Transform` del enemigo al que está asociada esta zona de activación.
    *   `public GameObject cuerpoEnemigo`: El objeto del enemigo, utilizado para desactivarlo si ya ha sido derrotado.
    *   `public Transform cameraTransform`: El `Transform` de la cámara del juego, utilizada para la animación de la transición.
    *   `public float cameraMoveSpeed`: La velocidad a la que la cámara se mueve hacia el enemigo durante la transición.
    *   `public string sceneToLoad`: El nombre de la escena de combate que se cargará al finalizar la transición.
    *   `public MonoBehaviour cameraController`: El script que controla el movimiento manual de la cámara en el mundo abierto. Se desactiva durante la transición.
    *   `public string idEnemigo`: Un identificador único para cada enemigo, utilizado para guardar el estado de "derrotado" en `PlayerPrefs`.
    *   **Intención:** La intención de este script es proporcionar una transición fluida e inmersiva entre la exploración del mundo abierto y el combate, creando una experiencia de juego más cohesiva y atractiva. También asegura que el juego recuerde el progreso del jugador (posición y enemigos derrotados).

*   **`FuncionesBotones.cs`:**
    *   **Descripción:** Este script maneja la funcionalidad de los botones en la interfaz de usuario del juego, como los botones de inicio, salida y retorno al menú principal. Cada método en el script está vinculado a un botón específico y ejecuta la acción correspondiente (cargar una escena o cerrar la aplicación).
    *   `public string escenaInicio`: El nombre de la escena que se carga cuando el jugador presiona el botón "Empezar Juego".
    *   `public string escenaMenu`: El nombre de la escena del menú principal.
    *   `empezarJuego()`: Carga la escena de inicio del juego.
    *   `salirJuego()`: Cierra la aplicación completamente.
    *   `volverMenu()`: Carga la escena del menú principal.
    *   **Intención:** La intención de este script es centralizar la gestión de las interacciones del usuario con los botones en la interfaz del juego, facilitando la navegación y el control del juego.

*   **`HealthIndicator.cs`:**
    *   **Descripción:** Este script actualiza la visualización de la salud del jugador en la interfaz de usuario (UI). Muestra la salud actual del jugador utilizando un objeto de texto de TextMeshPro y proporciona métodos para inicializar la salud, recibir daño y actualizar la visualización.
    *   `public TMP_Text healthText`: Asigna el objeto de texto de TextMeshPro desde el Inspector para mostrar la salud del jugador.
    *   `public int currentHealth`: La salud actual del jugador.
    *   `public int vidaInicial`: La salud inicial del jugador al comienzo del juego o al volver a la escena del mundo abierto.
    *   `InitializeHealth(int startingHealth)`: Establece la salud actual del jugador al valor inicial.
    *   `TakeDamage(int damage)`: Reduce la salud del jugador por una cantidad específica de daño y asegura que la salud no caiga por debajo de cero.
    *   `UpdateHealthText()`: Actualiza el texto del indicador de salud para reflejar la salud actual del jugador.
    *   **Intención:** Este script proporciona una manera clara y concisa de mostrar la salud del jugador al usuario, permitiéndole rastrear su estado y tomar decisiones informadas durante el juego.

*   **`InicioJuego.cs`:**
    *   **Descripción:** Este script se ejecuta al inicio de una nueva partida y reinicia todos los datos guardados en `PlayerPrefs`. Esto asegura que el juego comience en un estado limpio y predecible para cada nueva partida.
    *   `Start()`: Elimina todos los datos guardados en `PlayerPrefs`.
    *   **Intención:** El propósito principal de este script es asegurar que cada nueva partida comience en un estado fresco, eliminando cualquier dato persistente de partidas anteriores y proporcionando una experiencia consistente para el jugador.

*   **`PosicionPersonaje.cs`:**
    *   **Descripción:** Este script se encarga de restaurar la posición del personaje al cargar la escena del mundo abierto. Verifica si hay datos de posición guardados en `PlayerPrefs` y, si los hay, aplica esa posición al personaje.
    *   `Start()`: Comprueba si existen las claves "PlayerPosX", "PlayerPosY" y "PlayerPosZ" en `PlayerPrefs`. Si existen, recupera los valores y los aplica a la posición del personaje.
    *   **Intención:** La intención de este script es permitir que el jugador retome su aventura exactamente donde la dejó después de completar un combate, manteniendo la continuidad y la sensación de exploración en el mundo abierto.

*   **`SelectorDeCartas.cs`:**
    *   **Descripción:** Este script gestiona la selección y el uso de cartas durante las batallas por turnos. Permite al jugador seleccionar una de las 5 cartas disponibles en su mano, aplicar el efecto de la carta (daño o defensa) y luego desactiva la carta para evitar su uso repetido en el mismo turno. Las cartas se reactivan al comienzo del siguiente turno del jugador.
    *   `public BarraDeVida barraDeVida`: Una referencia al script `BarraDeVida` del enemigo para aplicar daño o defensa.
    *   `public GameObject carta1`, `carta2`, `carta3`, `carta4`, `carta5`: Objetos de juego que representan las cartas en la interfaz de usuario.
    *   `SeleccionarOpcion(int opcion)`: Un método llamado cuando el jugador selecciona una carta. Aplica el efecto de la carta correspondiente (daño o defensa) y desactiva la carta en la interfaz.
    *   `ResetCartas()`: Activa todos los objetos de carta al comienzo de un nuevo turno, permitiendo al jugador volver a usarlos.
    *   `HideCartas()`: Desactiva todos los objetos de carta, impidiendo al jugador usarlos.
    *   `GenerarDamage()`: Genera un valor de daño aleatorio para las cartas de ataque.
        * `limiteUsoCartas`: Número máximo de cartas a usar en un turno.

    *   **Intención:** Este script proporciona el núcleo de la jugabilidad basada en cartas, permitiendo al jugador tomar decisiones estratégicas durante el combate y adaptar sus tácticas en función de las cartas disponibles.

*   **`Trigger.cs`:**
    *   **Descripción:** Este script detecta cuando el jugador entra o sale de una zona de activación alrededor de un enemigo en el mundo abierto. Cuando el jugador entra en la zona, el script activa el comportamiento de persecución del enemigo (a través del script `EnemyAI`). Cuando el jugador sale de la zona, el script detiene la persecución.
    *   `public GameObject enemy`: Una referencia al objeto del enemigo al que está asociada esta zona de activación.
    *   `OnTriggerEnter(Collider other)`: Un método llamado cuando otro objeto entra en la zona de activación. Si el objeto que entra es el jugador, este método llama al método `StartChasingPlayer()` del script `EnemyAI` del enemigo.
    *   `OnTriggerExit(Collider other)`: Un método llamado cuando otro objeto sale de la zona de activación. Si el objeto que sale es el jugador, este método llama al método `StopChasingPlayer()` del script `EnemyAI` del enemigo.
    *   **Intención:** El propósito de este script es controlar el comportamiento de los enemigos en el mundo abierto, haciendo que solo persigan al jugador cuando estén cerca y evitando que lo persigan indefinidamente. Esto crea un mundo más dinámico y evita situaciones frustrantes para el jugador.

*   **`BarraDeVida.cs`:**
    *   **Descripción:** Este script controla la barra de vida tanto del enemigo como del jugador, gestiona la lógica del combate por turnos y la transición entre las escenas de combate y el mundo abierto. Incluye métodos para aplicar daño, actualizar la barra de vida visual, gestionar el final del combate y cargar otras escenas. También persiste la salud del jugador entre combates y se encarga de la gestion del turno del enemigo.
    *   `[SerializeField] private float vidaMaximaEnemigo = 100f`: La vida máxima del enemigo. Configurable desde el Inspector.
    *   `[SerializeField] private Transform barraDeVida`: El `Transform` del plano que representa la barra de vida del enemigo.
    *   `[SerializeField] private GameObject botonCambioEscena`: El botón que aparece al final del combate para permitir al jugador volver al mundo abierto.
    *   `[SerializeField] private GameObject mensajeFinCombate`: El mensaje que se muestra al final del combate para indicar la victoria.
    *   `[SerializeField] private string nombreSiguienteEscena`: El nombre de la escena del mundo abierto.
    *   `[SerializeField] private string idEnemigo`: Un identificador único para este enemigo. Utilizado para guardar el estado de "derrotado" del enemigo.
    *   `AplicarDaño(float daño)`: Reduce la vida del enemigo por una cantidad específica y actualiza la barra de vida visual.
    *   `ActualizarBarraDeVida()`: Actualiza la escala de la barra de vida visual para reflejar la vida restante del enemigo.
    *   `TerminarCombate()`: Se llama cuando la vida del enemigo llega a cero. Activa los elementos de UI correspondientes (botón de cambio de escena y mensaje de victoria).
    *   `CambiarEscena()`: Carga la escena del mundo abierto.
    *   `TakeDamage(int damage)`: Reduce la salud del jugador.
    *    `TurnoUsuario()`: Se encarga de resetear las cartas del usuario y generar el ataque que hará el enemigo en su turno.
    * `TurnoEnemigo()`: Se encarga de realizar el ataque del enemigo y settear valores para el turno del usuario.

    *  **Intención:** Este script proporciona la lógica central para el sistema de combate del juego, gestionando la salud de los combatientes, las interacciones entre ellos y la transición entre el combate y el mundo abierto. También asegura que el progreso del jugador (estado de los enemigos derrotados y salud restante) se conserve entre las escenas.

## Instalación

1.  Clona este repositorio.
2.  Abre el proyecto en Unity.
3.  Asegúrate de tener las dependencias necesarias instaladas (TextMeshPro, etc.).
4.  Configura las escenas y los objetos en el Inspector de Unity según sea necesario.

## Créditos

*   Desarrollado por: Francisco López Marín
*   Música y Sonido: https://downloads.khinsider.com/
