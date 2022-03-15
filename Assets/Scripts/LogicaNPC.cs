using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaNPC : MonoBehaviour
{

    //public GameObject simboloMision; 
    public Animation jugador; 
    public GameObject panelNPC; //interaccion
    public GameObject panelNPC2; //texto
    public GameObject panelNPCMision; //texto cuando aceptas
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numObjetivos;
    public GameObject botonMision;

    // Start is called before the first frame update
    void Start()
    {
        numObjetivos = objetivos.Length;
        textoMision.text = "Recoge las muestras" + "   " + numObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>();
        //simboloMision.SetActive(true);
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && aceptarMision == false)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);

            jugador.animator.SetFloat("vertical", 0);
            jugador.animator.SetFloat("horizontal", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false); //Panel pulsar Z
            panelNPC2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            jugadorCerca = true;
            if (aceptarMision == false)
            {
                panelNPC.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            jugadorCerca = false;

            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }

    public void OpcionNo()
    {
        jugador.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
    }

    public void OpcionSi()
    {
        jugador.enabled = true;
        aceptarMision = true;
        for(int i = 0; i<objetivos.Length; i++)
        {
            objetivos[i].SetActive(true); //activa las muestras
        }
        jugadorCerca = false;
        //simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }
}
