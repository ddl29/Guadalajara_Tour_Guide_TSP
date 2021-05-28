using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class AlgoritmoViajero : MonoBehaviour
{
	private double[,] matriz;
    private double costoOptimo = Int32.MaxValue;
    private int[] mejorRuta;

    private double costoMenor() {
		double minPosible = 0;
		for (int i = 0; i < matriz.GetLength(0); i++) {
			double min = Int32.MaxValue;
			for (int j = 0; j < matriz.GetLength(0); j++) {
				if(matriz[i,j] != 0 & matriz[i,j] < min) {
					min = matriz[i,j];
				}
			}
			minPosible+= min;
		}
		return minPosible;
	}

    private double calcularCosto(int[] ruta) {
		double costo = 0;
		for (int i = 0; i < matriz.GetLength(0); i++) {
			if(checarFila(i,ruta)) {
				double min = Int32.MaxValue;
				for (int j = 0; j < matriz.GetLength(0); j++) {
					if(checarColumna(j,ruta)) {
						if(matriz[i,j] != 0 & matriz[i,j] < min) {
							if(j != ruta[ruta.Length-1] && i != ruta[0]) {
								min = matriz[i,j];
							}
						}
					}
				}
				costo+= min;
			}
		}
		//Ahora, a costo agregamos los de ruta
		for (int i = 0; i < ruta.Length-1; i++) {
			int fila = ruta[i];
			int col = ruta[i+1];
			costo += matriz[fila,col];
		}
		return costo;
	}

    private bool checarFila(int index, int[] ruta) {
		for (int i = 0; i < ruta.Length-1; i++) {
			if(index == ruta[i]) {
				return false;
			}
		}
		return true;
	}
	
	private bool checarColumna(int index, int[] ruta) {
		for (int i = 1; i < ruta.Length; i++) {
			if(index == ruta[i]) {
				return false;
			}
		}
		return true;
	}

	void Start(){
		/*for(int i=0;i<grafo.selected.Length;i++){
			string row = "";
			for(int j=0;j<grafo.selected.Length;j++){
				row += matriz[3,4]+", ";
			}
			print(row);
        }*/
		
	}

    public int[] algoritmo(int origen, bool regresoOrigen) {
		double minPosible = costoMenor();
		PriorityQueue nodos = new PriorityQueue();
		
		//Agregamos el nodo origen a la PriorityQueue.
		int[] indices = {origen};
		nodos.Enqueue(new Nodo(indices,minPosible));
		
		while(!nodos.isEmpty()) {
			int[] origenIndices = nodos.Dequeue().indices;
			int[] hijosPosibles = hijosPosiblesMetodo(origenIndices);
			agregarHijos(origenIndices,hijosPosibles,nodos);
		}
		
		//Ahora, solo falta agregar el último nodo posible y el regreso al origen.
		int tamaño = 0;
		if(regresoOrigen) {
			tamaño = this.mejorRuta.Length+2;
		}else {
			tamaño = this.mejorRuta.Length+1;
		}
		
		int[] rutaFinal = new int[tamaño];
		
		for (int i = 0; i < this.mejorRuta.Length; i++) {
			rutaFinal[i] = this.mejorRuta[i];
		}
		int[] hijoUltimo = hijosPosiblesMetodo(this.mejorRuta);
		
		if(regresoOrigen) {
			rutaFinal[rutaFinal.Length-2] = hijoUltimo[0];
			rutaFinal[rutaFinal.Length-1] = origen;
		}else {
			rutaFinal[rutaFinal.Length-1] = hijoUltimo[0];
		}
		
		return rutaFinal;
	}

    private void agregarHijos(int[] origenIndices, int[] hijosPosibles, PriorityQueue nodos) {
		for (int i = 0; i < hijosPosibles.Length; i++) {
			int[] ruta = new int[origenIndices.Length+1];
			//Este for es para copiar los elementos de origenIndices a ruta.
			for (int j = 0; j < ruta.Length-1; j++) {
				ruta[j] = origenIndices[j];
			}
			ruta[ruta.Length-1] = hijosPosibles[i];

			//Ya tiene la ruta, ahora hay que calcular su costo.
			double costo = calcularCosto(ruta);
			
			if(ruta.Length == matriz.GetLength(0)-1 && costo < this.costoOptimo) {
				this.mejorRuta = ruta;
				this.costoOptimo = costo;
			}else {
				nodos.Enqueue(new Nodo(ruta, costo));
			}
		}
	}
    private int[] hijosPosiblesMetodo(int[] indices) {
		Queue<Int32> hijos = new Queue<Int32>();
		for (int i = 0; i < matriz.GetLength(0); i++) {
			bool check = true;
			for (int j = 0; j < indices.Length; j++) {
				if(i == indices[j]) {
					check = false;
				}
			}
			if(check) {
				hijos.Enqueue(i);
			}
		}
		
		int[] hijosPosibles = new int[hijos.Count];
		for (int i = 0; i < hijosPosibles.Length; i++) {
			hijosPosibles[i] = hijos.Dequeue();
		}

		return hijosPosibles;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			int[] ruta = algoritmo(0,true);
			for(int i=0;i<ruta.Length;i++){
				print(ruta[i]);
			}
			//}
			//print(matriz[3,4]);
			//print(matriz[0,3]);
			
		}
		//print(matriz[3,4]);
	}
    
}
