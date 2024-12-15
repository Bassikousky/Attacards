using UnityEngine;
using UnityEngine.EventSystems;

public class ImageHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalPosition;

    // Define la nueva posición a la que quieres mover la imagen
    public Vector3 newPosition = new Vector3(256.2f,-271.97525f,-426.898987f);

    void Start()
    {
        // Guarda la posición original de la imagen
        originalPosition = transform.localPosition;
    }

    // Cuando el cursor entra en la imagen
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localPosition = newPosition;
    }

    // Cuando el cursor sale de la imagen
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localPosition = originalPosition;
    }
}
