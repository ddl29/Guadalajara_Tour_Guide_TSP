using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckedPlaces : MonoBehaviour
{   
    private int[] chosenPlaces;
    private bool regreso;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("lugares");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void setRuta(int[] places,bool regreso){
        this.chosenPlaces = places;
        this.regreso = regreso;
        
        //printArray(this.chosenPlaces);
    }

    void printArray(int[] array){
        string uno = "";
        for(int i=0;i<array.Length;i++){
            uno+=array[i]+",";
        }
        print(uno);
    }
    
    public int[] getArraySelected(){
        return this.chosenPlaces;
    }

    public bool regresoIsOn(){
        return this.regreso;
    }
}
