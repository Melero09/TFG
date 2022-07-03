using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    private bool menuActivado;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuActivado = !menuActivado;
        }

        if (menuActivado == true)
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}

