using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaMuestras : MonoBehaviour
{
    public LogicaNPC logicaNPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            logicaNPC.numObjetivos--;
            logicaNPC.textoMision.text = "Recoge las muestras" + "   " + logicaNPC.numObjetivos;
            if(logicaNPC.numObjetivos <= 0)
            {
                logicaNPC.textoMision.text = "Completado";
                logicaNPC.botonMision.SetActive(true);
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}
