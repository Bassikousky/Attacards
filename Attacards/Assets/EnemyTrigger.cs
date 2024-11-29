using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class EnemyTriggerZone : MonoBehaviour
{
    public Transform enemy;         // Asigna el transform del enemigo en el inspector
    public Transform cameraTransform; // Asigna la cámara del juego
    public float cameraMoveSpeed = 2.0f; // Velocidad a la que la cámara se mueve hacia el enemigo
    public string sceneToLoad;      // Nombre de la escena a cargar
    public MonoBehaviour cameraController; // El script de control manual de la cámara

    private bool isCameraMoving = false; // Bandera para mover la cámara
    private Vector3 originalCameraPosition; // Para guardar la posición original de la cámara

    void Start()
    {
        // Guarda la posición original de la cámara
        if (cameraTransform != null)
        {
            originalCameraPosition = cameraTransform.position;
        }
        else
        {
            Debug.LogError("La cámara no está asignada en el inspector.");
        }

        // Comprueba si el controlador de la cámara está asignado
        if (cameraController == null)
        {
            Debug.LogWarning("No se asignó un controlador de cámara manual. Asegúrate de configurarlo en el inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el jugador entra en el área
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado, moviendo la cámara hacia el enemigo.");
            isCameraMoving = true; // Activa el movimiento de la cámara

            // Desactiva el control manual de la cámara
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
            // Mueve la cámara suavemente hacia el enemigo
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, enemy.position, cameraMoveSpeed * Time.deltaTime);

            // Opcional: Rotar la cámara para mirar al enemigo
            cameraTransform.LookAt(enemy);

            // Si la cámara está cerca del enemigo, cambia de escena
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
        // Reactiva el control manual de la cámara si el script se desactiva
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }
    }
}
