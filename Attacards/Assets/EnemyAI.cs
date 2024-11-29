using UnityEngine;

internal class EnemyAI : MonoBehaviour
{
    public Transform player; // Asigna el objeto del jugador en el inspector
    public float speed = 3.0f;

    private bool isChasing = false;

    void Update()
    {
        if (isChasing)
        {
            // Persigue al jugador
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void StartChasingPlayer()
    {
        isChasing = true;
    }

    public void StopChasingPlayer()
    {
        isChasing = false;
    }
}
