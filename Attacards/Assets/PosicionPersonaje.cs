using UnityEngine;

public class PosicionPersonaje : MonoBehaviour
{
    void Start()
    {
        // Verificar si hay datos guardados
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");

            // Restaurar la posición
            transform.position = new Vector3(x, y, z);
        }
    }
}
