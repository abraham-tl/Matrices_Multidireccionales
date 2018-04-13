using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Matriz : MonoBehaviour {
// DECLARACION DE VARIABLES 
//tamaño de la matriz de juego (10 x 10)
    public int size;
    //vaariable para la forma de los opjetos (SPHERA)
    public GameObject form;
    //La matriz de opjentos
    GameObject[,] grid;
    //control el color del siguiente movimiento o jugador
    bool player;
    // variables para definir ancho y largo de la matriz de juego
    int x, y;
    //Variable para defir el color actual
    Color colorbase;
    //Variable para instanciar la clase del calculo de juego
   public Logica logica;
    //Variable para controlar si hay 4 en linea
   public  bool gano;

    //Variables de texto para actualizar canvas
    public Text puntaje1;
    public Text puntaje2;
    public Text turno;

    //Variables para controlar el Powerup del que va perdiento o regla adicional
    int diferencia;
    bool power;
    bool color_power;

 // Metodo star inicializar las variables y llenar la matriz de juego co los objetos (SPHERA)
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

    //Metodo Update
	void Update () {
      //toma la posicion del mouse en la pantalla
        Vector3 mposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //si presiona el mouseclick llama el subproceso  mouseclick
        if (Input.GetButtonDown ("Fire1"))
        {
            MouseClick(mposition);
        }
    }

    void MouseClick(Vector3 mousePosition)
    {
      //convierte la posicion en la pantalla a la matriz de juego
        int _x = (int)(mousePosition.x + 0.5f);
        int _y = (int)(mousePosition.y + 0.5f);

        if (_x >= 0 && _y >= 0 && _x < x && _y < y)
        {
            // toma el objeto de la matriz de juego en _x _y
            GameObject go = grid[_x, _y];
            //si esta activado el bool power repite color si no siegue el proximo jugador
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
                // asigna el color en juego
               colorbase = go.GetComponent<Renderer>().material.color;
                // envia el posicion, color de juego, la matriz y recibe un booleano  para controlar si hay o no punto
                gano = logica.Metodo_juego(grid, _x, _y, colorbase, y);
                //controla el turno siguiente
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
        //si gano llama los metodos limpiar y punto
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
    //Metodo que envia texto y color al Canvas del player que sigue en el turno  
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
    //Canvas del player que sigue en el turno se quita en 2 segundos
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        turno.text = "";
    }
}
