using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MisionMuestras : MonoBehaviour
{

    public int numObjetivos;
    public TextMeshProUGUI textoMision;
    public GameObject botonMision;
    // Start is called before the first frame update
    void Start()
    {
        numObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length; //Busca objetos con el tag objetivo
        textoMision.text = "Recoge las muestras" + "   " + numObjetivos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "objetivo") //Si colisiono con objeto con esta etiqueta pasa esto
        {
            Destroy(other.transform.parent.gameObject);
            numObjetivos--;
            textoMision.text = "Recoge las muestras" + "   " + numObjetivos;
            if(numObjetivos <= 0)
            {
                textoMision.text = "Completado";
                botonMision.SetActive(true);
            }
        }
    }
}
