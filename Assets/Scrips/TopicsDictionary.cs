using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopicsDictionary : MonoBehaviour
{
    Dictionary<string, List<string>> topics = new Dictionary<string, List<string>>();
    List<string> tProgramacionOrientadaAObjetos = new List<string>();
    List<string> tMetodologia = new List<string>();
    List<string> tAlgoritmo = new List<string>();
    List<int> listIndex = new List<int>();
    int con = 0;

    private void Start()
    {
        StarDictionary();
        GetRandomTopic();
        //GetRandomKeyword();
    }
    public void StarDictionary()
    {
        //agrego los temas y las palabras clave a un diccionario
        tProgramacionOrientadaAObjetos.Add("PARADIGMA");
        tProgramacionOrientadaAObjetos.Add("HERENCIA");
        tProgramacionOrientadaAObjetos.Add("CLASES");
        topics.Add("ProgramacionOrientadaAObjetos", tProgramacionOrientadaAObjetos);

        tMetodologia.Add("MARCO DE TRABAJO");
        tMetodologia.Add("SCRUM");
        tMetodologia.Add("ESTRUCTURAR, PLANIFICAR Y CONTROLAR");
        topics.Add("Metodologia", tMetodologia);

        tAlgoritmo.Add("CONJUNTO DE INSTRUCCIONES");
        tAlgoritmo.Add("RESOLVER PROBLEMAS");
        tAlgoritmo.Add("ENTRADA, PROCESO, SALIDA");  
        topics.Add("Algoritmo", tAlgoritmo);
    }

    public void GetRandomTopic()
    {
        var rnd = new System.Random();
        var randomEntry = topics.ElementAt(rnd.Next(0, topics.Count));
        string randomKey = randomEntry.Key;
        GameManager.Instance.Topic = randomKey;
    }
    public string GetRandomKeyword()
    {
        string topic = GameManager.Instance.Topic;
        List<string> value;
        bool hasValue = topics.TryGetValue(topic, out value);
        if (hasValue)
        {
            var rnd = new System.Random();
            
            int index = rnd.Next(0, value.Count);
            int cont = 0;
            while(listIndex.Contains(index) && cont < value.Count*2 )
            {
                index = rnd.Next(0, value.Count);
                cont++;
            }
            listIndex.Add(index);
            Debug.Log("Keyword: " + value[index]);
            return value[index];
        }
        else
        {
            Debug.Log("No hay Keyword");
            return null;
        }
    }
    /*public List<string> SelectordKeyWord(String topic)
    {
        switch (topic)
        {
            case ("Programacion Orientada a Objetos"):
                return topics["Programacion Orientada a Objetos"];   
            case ("Metodologia"):
                return topics["Metodologia"];
            case ("Algoritmo"):
                return topics["Algoritmo"];
            default:
                return null;
        }
    }*/
}
