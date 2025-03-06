using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera camera; // Referência à câmera
    public float zoomSpeed = 1f; // Velocidade do zoom
    public float minSize = 5f; // Tamanho mínimo da câmera
    public float maxSize = 20f; // Tamanho máximo da câmera

    void Update()
    {
        // Obtém a rotação da roda do mouse (valor entre -1 e 1)
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Ajusta o tamanho (size) da câmera ortográfica para dar o efeito de zoom
        camera.orthographicSize -= scrollInput * zoomSpeed;

        // Limita o valor do tamanho para os valores mínimo e máximo
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minSize, maxSize);
    }
}
