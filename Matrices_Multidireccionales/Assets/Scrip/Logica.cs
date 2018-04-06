using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logica : MonoBehaviour {
    int inicio;
    int final;
    int position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Metodo_juego(GameObject [,] grid_,int x,int y)
    {
        position = y;
        if ((x-3) >= 0)
        {
            inicio = (x - 3);
        }
        else
        {
            inicio = 0;
        }
        if ((x + 3) <= 9)
        {
            final = (x + 3);
        }
        else
        {
            final = 9;
        }
    }

    void Vertical()
    {
        for (int i=inicio;i <=final;i++)
        {

        }
    }

    void Horizontal(GameObject [,] grid__)
    {
        for (int i = inicio; i <= final; i++)
        {
            //if (grid__[position, i].GetComponent<Renderer>().material.color)
        }
    }

    void Deagonal()
    {

    }
}
