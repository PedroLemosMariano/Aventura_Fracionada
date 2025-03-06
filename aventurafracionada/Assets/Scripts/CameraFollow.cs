using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float edgeDistance = 100f; // Distância em pixels para a câmera começar a se mover
    public float moveSpeed = 0.1f; // Velocidade de movimentação da câmera
    private Vector3 initialPosition; // Posição inicial da câmera (do player)
    private bool isMouseInsideWindow = true; // Verifica se o mouse está dentro da janela

    void Start()
    {
        initialPosition = transform.localPosition; // Armazenar a posição inicial da câmera
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        // Pegar a posição do mouse na tela
        Vector3 mousePos = Input.mousePosition;


        // Verificar se o mouse está dentro da janela
        if (mousePos.x >= 0 && mousePos.x <= Screen.width && mousePos.y >= 0 && mousePos.y <= Screen.height)
        {
            isMouseInsideWindow = true; // O mouse está dentro da janela
        }
        else
        {
            isMouseInsideWindow = false; // O mouse saiu da janela
        }

        // Se o mouse está dentro da janela, mova a câmera com base nas bordas
        if (isMouseInsideWindow)
        {
            if (mousePos.x <= edgeDistance)
            {
                moveDirection.x = -1; // Move para a esquerda
            }
            else if (mousePos.x >= Screen.width - edgeDistance)
            {
                moveDirection.x = 1; // Move para a direita
            }

            if (mousePos.y <= edgeDistance)
            {
                moveDirection.y = -1; // Move para baixo
            }
            else if (mousePos.y >= Screen.height - edgeDistance)
            {
                moveDirection.y = 1; // Move para cima
            }
        }

        // Calcular a nova posição da câmera com base no movimento
        Vector3 newCameraPosition = initialPosition + moveDirection * moveSpeed;

        // Se o mouse saiu da janela, a câmera volta para a posição do personagem
        if (!isMouseInsideWindow)
        {
            newCameraPosition = initialPosition; // Retorna para a posição inicial do personagem
        }

        // Atualizar a posição da câmera
        transform.localPosition = Vector3.Lerp(transform.localPosition, newCameraPosition, Time.deltaTime);

    }
}
