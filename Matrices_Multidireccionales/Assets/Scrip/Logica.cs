using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logica  {
    int inicio;
    int final;
    int position;
    public int size;
    public int cont = 0;
    GameObject[,] grid;
    // Use this for initialization
    void Start () {
		
	}
	
    public bool  Metodo_juego(GameObject [,] grid_,int _x,int _y,Color color,int y)
    {

        grid = grid_;
        int inicio;
        int final;
        int position;
        int v_inicio;
        int v_final;
        int der;
        int izq;
        int abajo;
        int encima;
            position = y;
        if ((_x - 3) >= 0)
        {
            inicio = (_x - 3);
            der = (_x - 2);
        }
        else
        {
            inicio = 0;
            der = 0;
        }
        if ((_x + 3) <= 9)
        {
            final = (_x + 3);
            izq = (_x + 2);
        }
        else
        {
            final = 9;
            izq = 9;
        }
        if ((_y - 3) >= 0)
        {
            v_inicio = (_y - 3);
            abajo = (_y -1);
        }
        else
        {
            v_inicio = 0;
            abajo = 0;
        }
        if ((_y + 3) <= 9)
        {
            v_final = (_y + 3);
            encima = (_y + 1);
        }
        else
        {
            v_final = 9;
            encima = 9;
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
                return true;
             
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
              return true;
            }
        }

        for (int i = (inicio +1);i <= final; i ++)
        {
            for (int k =(v_inicio +1);k <= final ; k ++)
            {
                if (grid[_x, i].GetComponent<Renderer>().material.color == color)
                {
                   
                }
            }
        }

        int l = _x;
        int j = _y;
        cont = 0;
        while (l >= 0 && j >= 0)
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
        if (cont >= 4)
        {
            return true;
        }
        else
        {
            cont = 0;
        }
        l = _x;
        j = _y;
        while (l >= 0 && j <= 9)
        {

            if (grid[l, j].GetComponent<Renderer>().material.color == color)
            {
                cont = cont + 1;
                l = l - 1;
                j = j + 1;
            }
            else
            {
                j = 10;
                l = -1;
            }
        }

        l = _x + 1;
        j = _y - 1;
        while (l <= 9 && j >= 0)
        {
            if (grid[l, j].GetComponent<Renderer>().material.color == color)
            {
                cont = cont + 1;
                l = l + 1;
                j = j - 1;
            }
            else
            {
                j = 10;
                l = 10;
            }
        }
        if (cont >= 4)
        {
            return true;
        }
        else
        {
            cont = 0;
        }
        return false;
    }
   
}
