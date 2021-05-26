using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Toggle[] checkLugares;
    public Toggle regresoCheck;
    private int size = 32;
    public CheckedPlaces places;
    public Button calcularRuta;
    // Start is called before the first frame update
  
    public void setArrayPlaces(){
        Queue fila = new Queue();
        for(int i=0;i<size;i++){
            if(checkLugares[i].isOn){
                fila.Enqueue(i+1);
            }
        }
        int tamaño = fila.Count;
        int[] selectedPlaces = new int[tamaño];
        for(int i = 0;i<tamaño;i++){
            selectedPlaces[i] = (int)fila.Dequeue();
        }
        places.setPlaces(selectedPlaces, regresoCheck.isOn);
        SceneManager.LoadScene("Mapa");
    }

    void printArray(int[] array){
        string uno = "";
        for(int i=0;i<array.Length;i++){
            uno+=array[i]+",";
        }
        print(uno);
    }
}
