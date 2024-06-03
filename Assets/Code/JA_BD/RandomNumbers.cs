using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumbers : MonoBehaviour
{
    public int puntuacion;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateRandom(){
        puntuacion = Random.Range(1, 100);
        text.text = puntuacion.ToString();
    }
}
