using UnityEngine;

public class ActivacionBoss : MonoBehaviour
{
    public GameObject cuerpoBoss;
    private string cuentaActivacionBossKey = "cuentaActivacionBoss";
    private int numeroEnemigos = 3;



    void Start()
    {
        CheckAndActivateBoss();
    }

    // Función para comprobar si se cumplen las condiciones y activar al jefe
    private void CheckAndActivateBoss()
    {
        if (PlayerPrefs.GetInt(cuentaActivacionBossKey, 0) >= numeroEnemigos)
        {
            cuerpoBoss.SetActive(true);
        }
        else
        {
            cuerpoBoss.SetActive(false);
        }
    }
    public void IncrementaCuentaActivacionBoss()
    {
        int cuentaActivacionBoss = PlayerPrefs.GetInt(cuentaActivacionBossKey, 0);
        cuentaActivacionBoss++;
        PlayerPrefs.SetInt(cuentaActivacionBossKey, cuentaActivacionBoss);
        PlayerPrefs.Save();
        Debug.Log("Incrementando cuentaActivacionBoss: " + cuentaActivacionBoss);

        CheckAndActivateBoss();
    }

}
