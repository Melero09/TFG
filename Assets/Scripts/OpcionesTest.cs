using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class OpcionesTest : MonoBehaviour
{
    private Text texto;
    private Button button;
    private Image image;
    private Color color = Color.black;

    public Respuesta respuesta1 { get; set; }

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        texto = transform.GetChild(0).GetComponent<Text>();
        color = image.color;
    }

    public void seleccion(Respuesta respuesta, Action<OpcionesTest> callback)
    {
        texto.text = respuesta.texto;

        button.enabled = true;
        image.color = color;
        respuesta1 = respuesta;

        button.onClick.AddListener(delegate
        {
            callback(this);
        });
    }

    public void SetColor(Color c)
    {
        button.enabled = false;
        image.color = c;
    }
}
