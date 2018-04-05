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
    Logica logica;
	// Use this for initialization
	void Start () {
        logica = new Logica();
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
	
	// Update is called once per frame
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
            print(go.GetComponent<Renderer>().material.color);
            //if (go.GetComponent <Renderer >().material .)
            if (go.GetComponent<Renderer>().material .color == Color.white)
            {
                if (player)
                {
                    print(player);
                    go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    player = false;
                }
                else
                {
                    go.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    player = true; 
                }
            }
            
         
        }
       
    }
}
