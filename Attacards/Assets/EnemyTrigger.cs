using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class EnemyTriggerZone : MonoBehaviour
{
    public Transform enemy;         // Asigna el transform del enemigo en el inspector
    public GameObject cuerpoEnemigo;
    public Transform cameraTransform; // Asigna la c�mara del juego
    public float cameraMoveSpeed = 2.0f; // Velocidad a la que la c�mara se mueve hacia el enemigo
    public string sceneToLoad;      // Nombre de la escena a cargar
    public MonoBehaviour cameraController; // El script de control manual de la c�mara
    public string idEnemigo;
    private bool isCameraMoving = false; // Bandera para mover la c�mara
    private Vector3 originalCameraPosition; // Para guardar la posici�n original de la c�mara

    void Start()
    {

         // Comprueba si el enemigo ya ha sido derrotado.
        if (PlayerPrefs.GetInt(idEnemigo, 0) == 1)
        {
            // Desactiva el objeto enemigo si está derrotado.
            cuerpoEnemigo.SetActive(false);
        }

        // Guarda la posici�n original de la c�mara
        if (cameraTransform != null)
        {
            originalCameraPosition = cameraTransform.position;
        }
        else
        {
            Debug.LogError("La c�mara no est� asignada en el inspector.");
        }

        // Comprueba si el controlador de la c�mara est� asignado
        if (cameraController == null)
        {
            Debug.LogWarning("No se asign� un controlador de c�mara manual. Aseg�rate de configurarlo en el inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el jugador entra en el �rea
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado, moviendo la c�mara hacia el enemigo.");
            isCameraMoving = true; // Activa el movimiento de la c�mara

            // Desactiva el control manual de la c�mara
            if (cameraController != null)
            {
                cameraController.enabled = false;
            }
        }
    }

    void Update()
    {
        if (isCameraMoving)
        {
            // Mueve la c�mara suavemente hacia el enemigo
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, enemy.position, cameraMoveSpeed * Time.deltaTime);

            // Opcional: Rotar la c�mara para mirar al enemigo
            cameraTransform.LookAt(enemy);

            // Si la c�mara est� cerca del enemigo, cambia de escena
            if (Vector3.Distance(cameraTransform.position, enemy.position) < 0.5f)
            {
                Debug.Log("Cambiando de escena...");
                isCameraMoving = false; // Detenemos el movimiento
                ChangeScene(); // Cambia la escena
            }
        }
    }

    void ChangeScene()
    {

        PlayerPrefs.SetString("enemigo", idEnemigo);
        PlayerPrefs.Save();
        // Cambia a la escena especificada
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("No se ha especificado el nombre de la escena a cargar.");
        }
    }

    private void OnDisable()
    {
        // Reactiva el control manual de la c�mara si el script se desactiva
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }
    }
}
