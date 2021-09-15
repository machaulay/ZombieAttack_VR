using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{

    public float mouseSensitivity = 100.0f;
    public Transform playerMesh;
    float xRotation = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
        
    void Update()
    {
        // OBTENDO O INPUT A PARTIR DO MOVIMENTO DO MOUSE
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        // CONFIGURA A ROTACAO DA VISAO PARA CIMA E BAIXO DO JOGADOR
        xRotation = mouseY;                                     // X RECEBE O INPUT DE Y DO MOUSE
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);      // RESTRINGE EM 90 GRAUS A ROTACAO


        // CONFIGURA A ROTACAO PARA A CAMERA
        playerMesh.Rotate(Vector3.up * mouseX);                 // Y DA CAMERA PARA O X DO MOUSE
        transform.Rotate(Vector3.left * xRotation);             // X DA CAMERA PARA O Y DO MOUSE
    }
}
