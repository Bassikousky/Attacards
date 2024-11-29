using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Opcional: referencia al enemigo
    public GameObject enemy;

    // Se activa al entrar en el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si es el jugador
        {
            Debug.Log("Jugador detectado en el área del enemigo");
            // Ejemplo: activar un estado de persecución
            enemy.GetComponent<EnemyAI>().StartChasingPlayer();
        }
    }

    // Se activa al salir del trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si es el jugador
        {
            Debug.Log("Jugador salió del área del enemigo");
            // Ejemplo: detener la persecución
            enemy.GetComponent<EnemyAI>().StopChasingPlayer();
        }
    }
}
