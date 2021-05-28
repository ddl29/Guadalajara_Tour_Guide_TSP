using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class MatrizLugares : MonoBehaviour
{
    private string[] nombreVertice;
    private double[,] matriz;
    private int size;

    void Start()
    {
        var reader = new StreamReader(File.OpenRead(@"C:\Users\Daniel Díaz López\OneDrive - Instituto Tecnologico y de Estudios Superiores de Monterrey\6to Semestre\Análisis y diseño de algoritmos\Proyecto_viajero_extranjero.csv"));
        
        //Leer la primera linea, los nombres de los lugares.
        string[] line = reader.ReadLine().Split(',');
        this.size = line.Length-3;
        matriz = new double[this.size,this.size];
        this.nombreVertice = new string[this.size];

        for(int i=0;i<size;i++){
            nombreVertice[i] = line[i+1];
        }
        
        //Rellenamos la matriz de adyacencias
        for(int fila = 0;fila<this.size;fila++){
            line = reader.ReadLine().Split(',');
            for(int col=0;col<this.size;col++){
                matriz[fila,col] = Convert.ToDouble(line[col+1]);
            }
        }
        //Cerramos el archivo CSV
        reader.Close();
        //imprimeMatriz();
    }

    public string getNombreVertex(int i){
        return this.nombreVertice[i];
    }

    public double[,] getMatrizCompleta(){
        return this.matriz;
    }

    private void imprimeMatriz(){
       for(int fila = 0;fila<size;fila++){
            string row = nombreVertice[fila]+" ->";
            for(int col=0;col<size;col++){
                row += matriz[fila,col]+", ";
            }
            print(row);
        }
    }
}
