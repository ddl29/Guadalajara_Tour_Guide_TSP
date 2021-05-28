using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Toggle[] checkLugares;
    public Toggle regresoCheck;
    private int[] selectedPlaces;
    private int size = 32;
    public CheckedPlaces places;
    public Button calcularBoton;
    public MatrizLugares matrizCompleta;
    public double[,] matrizSelected;
    // Start is called before the first frame update
  
    public void setArrayPlaces(){
        Queue fila = new Queue();
        for(int i=0;i<size;i++){
            if(checkLugares[i].isOn){
                fila.Enqueue(i+1);
            }
        }
        int tamaño = fila.Count+1;
        this.selectedPlaces = new int[tamaño];
        this.selectedPlaces[0] = 0; //el origen siempre es el TEC
        for(int i = 1;i<tamaño;i++){
            this.selectedPlaces[i] = (int)fila.Dequeue();
        }
        

        makeMatrizSelected();
        Algoritmo calculator = new Algoritmo(this.matrizSelected);
        int[] rutaOptima = calculator.algoritmo(0,regresoCheck.isOn);

        int[] ruta = new int[rutaOptima.Length];
        for(int i=0;i<rutaOptima.Length;i++){
            ruta[i] = this.selectedPlaces[rutaOptima[i]];
        }
        
        //IMPRIME RUTA
        /*string res = "";
        for(int i=0;i<selectedPlaces.Length;i++){
            res+=ruta[i]+",";
        }
        print(res);*/
        
        places.setRuta(ruta, regresoCheck.isOn);
        SceneManager.LoadScene("Mapa");
    }

    public void makeMatrizSelected(){
        this.matrizSelected = new double[selectedPlaces.Length,selectedPlaces.Length];

        for(int fila = 0;fila<selectedPlaces.Length;fila++){
            for(int col=0;col<selectedPlaces.Length;col++){
                this.matrizSelected[fila,col] = matrizCompleta.getMatrizCompleta()[selectedPlaces[fila],selectedPlaces[col]];
            }
        }
    }

    void printArray(int[] array){
        string uno = "";
        for(int i=0;i<array.Length;i++){
            uno+=array[i]+",";
        }
        print(uno);
    }
}
