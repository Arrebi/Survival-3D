using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public Vector3 offset; // Offset para la posici�n de la c�mara

    void Update()
    {
        // Actualizar la posici�n de la c�mara para que siga al jugador con el offset
        transform.position = player.position + offset;
    }
}