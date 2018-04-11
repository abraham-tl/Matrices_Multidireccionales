using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Matriz : MonoBehaviour {
// DECLARACION DE VARIABLES 
    public int size;
    public GameObject form;
    GameObject[,] grid;
    bool player;
    int x, y;
    Color colorbase;
    
   public Logica logica;
   public  bool gano;

    public Text puntaje1;
    public Text puntaje2;
    public Text turno;

    int diferencia;
    bool power;
    bool color_power;
    void Start ()
    {
        power = false;
        gano = false;
        logica = new Logica();
        puntaje1.text = Clase_Global.punt_1.ToString();
        puntaje2.text = Clase_Global.punt_2.ToString();

        x = size;
        y = size;
        grid = new GameObject[x, y];
        for (int i =0;i<x;i++)
        {
            for (int j = 0;j < y;j++)
            {
                GameObject go = GameObject.Instantiate(form) as GameObject;
                Vector3 position = new Vector3(i, j, 0);
                go.transform.position = position;
                grid[i, j] = go;
            }
        }
        Turno_void(Color.blue);
	}
	void Update () {
      
        Vector3 mposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown ("Fire1"))
        {
            MouseClick(mposition);
        }
    }
    void MouseClick(Vector3 mousePosition)
    {
      
        int _x = (int)(mousePosition.x + 0.5f);
        int _y = (int)(mousePosition.y + 0.5f);
        if (_x >= 0 && _y >= 0 && _x < x && _y < y)
        {
            GameObject go = grid[_x, _y];
              if (go.GetComponent<Renderer>().material .color == Color.white)
              {
                if (power)
                {
                    if (color_power)
                    {
                        go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    }
                    else
                    {
                        go.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);             
                    }
                    power = false;
                }
                else
                {
                    if (player)
                    {
                        go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                        player = false;
                    }
                    else
                    {
                        go.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                        player = true;
                    }
                }
               colorbase = go.GetComponent<Renderer>().material.color;
               gano = logica.Metodo_juego(grid, _x, _y, colorbase, y);
                if (colorbase == Color .blue )
                {
                    Turno_void(Color .red );
                }
                else
                {
                    Turno_void(Color.blue);
                }
                
            }       
        }
        if (gano)
        {
            limpiar();
            gano = false;
            punto(colorbase);
        }
    }

   //ESTE PROCEDIMIENTO IMPRIME EL GANADOR Y LIMPIA DE COLOR LA MATRIZ
    void limpiar()
    {
        Debug.Log("GANO");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                grid[i, j].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }

  //ESTE PROCEDIMIENTO SUMA EL PUNTO AL GANADOR Y EN EL CANVAS
    void punto(Color colors)
    {
        if (colors == Color.red )
        {
            Clase_Global.punt_2 = Clase_Global.punt_2 + 1;
            puntaje2.text  = Clase_Global.punt_2.ToString();
           
        }
        else
        {
            
            Clase_Global.punt_1 = Clase_Global.punt_1 + 1;
            puntaje1.text = Clase_Global.punt_1.ToString();
        }
        Calc_diferenia();
    }

  //ESTE PROCEDIMIENTO CALCULA LA DIFERENCIA EN LOS PUNTAJES Y ACTIVA LA VENTAJA
    void Calc_diferenia()
    {
       
        diferencia = 0;
        if (Clase_Global.punt_1 > Clase_Global.punt_2)
        {
            diferencia = Clase_Global.punt_1 - Clase_Global.punt_2;
            color_power = true;
            player = true;
        }
        else
        {
            diferencia = Clase_Global.punt_2 - Clase_Global.punt_1;
            color_power = false;
            player = false;
        }
        print("Diferencia " + diferencia + " color " + color_power);
        if (diferencia >= 3  )
        {
            power = true;

        }
    }
    void Turno_void(Color coler)
    {
        if (coler == Color .blue)
        {
            turno.text = "PLAYER 1";
            turno.color = Color.blue;
        }
        else
        {
            turno.text = "PLAYER 2";
            turno.color = Color.red;
        }
       
       StartCoroutine (Timer());

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        turno.text = "";
    }
}
