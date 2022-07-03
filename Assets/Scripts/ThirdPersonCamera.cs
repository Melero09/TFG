using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
   

    public Vector3 offset; //distancia entre camara y jugador
    private Transform target; //Jugador
    [Range (0, 1)]public float lerpValue;
    private float sensibilidad = 0;

    void Start()
    {
        target = GameObject.Find("Player").transform; //Decimos que target sea nuestro jugador
    }

    // Update is called once per frame
    void LateUpdate() //se ejecuta al final de cada frame
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue); //posicion de la camara
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
