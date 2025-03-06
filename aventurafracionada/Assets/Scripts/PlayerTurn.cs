using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 700f;  // Velocidade de rotação do personagem

    void Update()
    {
        // Checa as teclas WASD e gira para as direções diagonais
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            RotatePlayer(Vector3.forward); // nordeste
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            RotatePlayer(Vector3.left); // noroeste
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            RotatePlayer(Vector3.right); // sudeste
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            RotatePlayer(Vector3.back); // sudoeste
        }
        else if (Input.GetKey(KeyCode.W))
        {
            RotatePlayer(new Vector3(-1, 0, 1)); // olha norte
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RotatePlayer(new Vector3(1, 0, -1)); // olha sul
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotatePlayer(new Vector3(-1, 0, -1)); // olha oeste
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatePlayer(new Vector3(1, 0, 1)); // olha leste
        }
    }

    void RotatePlayer(Vector3 direction)
    {
        // Gira o personagem na direção indicada com uma velocidade controlada
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
