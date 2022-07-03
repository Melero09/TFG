using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dialogo : MonoBehaviour
{

    public GameObject panelNPC;
    public GameObject panelNPC2;
    public bool jugadorCerca;
    public TextMeshProUGUI textoMision;
    public Animation jugador;

    // Start is called before the first frame update
    void Start()
    {
        textoMision.text = "Ten cuidado por ahi";
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>();
        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) &&  jugadorCerca == true)
        {

            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);

            jugador.animator.SetFloat("vertical", 0);
            jugador.animator.SetFloat("horizontal", 0);
            jugador.enabled = true;
            panelNPC.SetActive(false); //Panel pulsar Z
            panelNPC2.SetActive(true);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            panelNPC.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;

            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }
}
