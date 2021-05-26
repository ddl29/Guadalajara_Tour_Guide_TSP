using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lugares : MonoBehaviour
{

    private Transform [] lugaresSelected;
    private int currentTargetIndex;
    Transform currentTargetPoint;
    private bool regreso;
    Vector2 movement;
    private IEnumerator patrullar;
    private float speed = .8f;
    public GameObject[] allLugares;
    private CheckedPlaces arraySelected;

    void Awake(){
        arraySelected = GameObject.FindGameObjectsWithTag("lugares")[0].GetComponent<CheckedPlaces>();
        int[] indexes = arraySelected.getArraySelected();
        
        this.lugaresSelected = new Transform[indexes.Length+1];
        this.lugaresSelected[0] = allLugares[0].transform;
        for(int i=0;i<indexes.Length;i++){
            GameObject lugarN = allLugares[indexes[i]];
            lugaresSelected[i+1] = lugarN.transform;
            lugarN.SetActive(true);
        }
        this.regreso = arraySelected.regresoIsOn();
    }


    //private float lineDrawSpeed = 100f;
    void Start()
    {
        currentTargetIndex = 0;
        currentTargetPoint = lugaresSelected[currentTargetIndex];
        transform.right = currentTargetPoint.position - transform.position;
        patrullar = avanzar();
        StartCoroutine(patrullar);

        ////////////////////////////////////
        ////////////DrawLine////////////////
        ////////////////////////////////////

    }

    

    // Update is called once per frame
    void Update()
    {     
        if(regreso) {
        if (Vector2.Distance(transform.position, currentTargetPoint.position) < 0.2f)
        {
            if(currentTargetIndex + 1 < lugaresSelected.Length){
                currentTargetIndex ++;
                print(currentTargetIndex);
                }
            else{
               currentTargetIndex = 0;
            }
            currentTargetPoint = lugaresSelected[currentTargetIndex];
        }
        }
        else{
          if (Vector2.Distance(transform.position, currentTargetPoint.position) < 0.2f)
        {
            if(currentTargetIndex + 1 < lugaresSelected.Length){
                currentTargetIndex ++;
                //print(currentTargetIndex);
                }
     
            currentTargetPoint = lugaresSelected[currentTargetIndex];
        }
        }
    }
    IEnumerator avanzar(){
        while(true){
            transform.right = currentTargetPoint.position - transform.position;
            movement = (currentTargetPoint.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, lugaresSelected[currentTargetIndex].position,speed * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }
    }
}
