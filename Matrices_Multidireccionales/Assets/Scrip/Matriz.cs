using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matriz : MonoBehaviour {
    public int size;
    public GameObject form;
    GameObject[,] grid;
    bool player;
    int x, y;
    Color colorbase;
    public int cont = 0;
    //Logica logica;
    // Use this for initialization
    void Start () {
        //logica = new Logica();
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
                if (player)
                {
                    //print(player);
                    go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    player = false;
                }
                else
                {
                    go.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    player = true; 
                }
                colorbase = go.GetComponent<Renderer>().material.color;
                comprobar(_x,_y,colorbase);
            }       
        }
       
    }

    void comprobar(int _x,int _y,Color color)
    {      
        int inicio;
        int final;
        int position;
        int v_inicio;
        int v_final;
      
        position = y;
        if ((_x - 3) >= 0)
        {
            inicio = (_x - 3);
        }
        else
        {
            inicio = 0;
        }
        if ((_x + 3) <= 9)
        {
            final = (_x + 3);
        }
        else
        {
            final = 9;
        }
        if ((_y - 3) >= 0)
        {
            v_inicio = (_y - 3);
        }
        else
        {
            v_inicio = 0;
        }
        if ((_y + 3) <= 9)
        {
            v_final = (_y + 3);
        }
        else
        {
            v_final = 9;
        }
        position = inicio;
      
        for (int i = inicio; i <= final; i++)
        {
            if (grid[i, _y].GetComponent<Renderer>().material.color == color)
            {
                cont = cont + 1;
            }
            else
            {
                cont = 0;
            }
            if (cont >= 4)
            {
                limpiar();
                break;
            }
        }
        for (int i = v_inicio; i <= v_final; i++)
        {
            if (grid[_x, i].GetComponent<Renderer>().material.color == color)
            {
                cont = cont + 1;
            }
            else
            {
                cont = 0;
            }
            if (cont >= 4)
            {            
                limpiar();
                break;
            }
        }

        int l = _x;
        int j = _y;
        cont = 0;
       while (j >=0 && l >= 0 )
        {
            if (grid[l, j].GetComponent<Renderer>().material.color == color)
            {
                cont = cont + 1;
                l = l - 1;
                j = j - 1;
            }
            else
            {
                j = -1;
                l = -1;
            }       
        }
        l = _x + 1;
        j = _y + 1;
        while (j <= 9 && l <= 9)
        {
            if (grid[l, j].GetComponent<Renderer>().material.color == color)
            {
                cont = cont + 1;
                l = l + 1;
                j = j + 1;
            }
            else
            {
                j = 10;
                l = 10;
            }
        }
        if (cont >=4)
        {
            limpiar();
        }
        else
        {
            cont = 0;
        }

    }
    void limpiar()
    {
        print("GANO");
        for (int i =0;i<size;i++)
        {
            for (int j =0;j<size;j++)
            {
                grid[i, j].GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
