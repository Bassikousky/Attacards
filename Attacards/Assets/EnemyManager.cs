using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject finalBoss; // Asigna el GameObject del jefe final en el Inspector
    public int initialEnemyCount; // Número de enemigos al inicio
    private int enemiesRemaining;

    void Start()
    {
        enemiesRemaining = initialEnemyCount;

        // Asegúrate de que el jefe final está desactivado al inicio
        if (finalBoss != null)
        {
            finalBoss.SetActive(false);
        }
        else
        {
            Debug.LogError("Final Boss no asignado al EnemyManager!");
        }
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;
        Debug.Log("Enemigos restantes: " + enemiesRemaining);

        if (enemiesRemaining <= 0)
        {
            ActivateFinalBoss();
        }
    }

    void ActivateFinalBoss()
    {
        Debug.Log("Todos los enemigos derrotados! Activando al jefe final!");
        if (finalBoss != null)
        {
            finalBoss.SetActive(true); // Activa el jefe final
        }
    }
}