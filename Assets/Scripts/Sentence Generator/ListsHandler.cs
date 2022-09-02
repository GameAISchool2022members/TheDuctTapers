using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListsHandler : MonoBehaviour
{


    public TextAsset OusiastikaJSON;
    public TextAsset EpithetaJSON;

    private int _epithetaCount;
    private int _ousiastikaCount;
    private int _ranO;

    [System.Serializable]
    public class Epitheta
    {
        public string epitheto;
        public string genos;
    }

    [System.Serializable]
    public class Ousiastika
    {
        public string ousiastiko;
        public string genos;
    }


    [System.Serializable]
    public class EpithetaList
    {
        public Epitheta[] Epitheta;
    }
    public EpithetaList myEpithetaList = new EpithetaList();



    [System.Serializable]
    public class OusiastikaList
    {
        public Ousiastika[] Ousiastika;
    }
    public OusiastikaList myOusiastikaList = new OusiastikaList();





    public void Start()
    {
        myEpithetaList = JsonUtility.FromJson<EpithetaList>(EpithetaJSON.text);

        myOusiastikaList = JsonUtility.FromJson<OusiastikaList>(OusiastikaJSON.text);


        _epithetaCount = myEpithetaList.Epitheta.Length;
        _ousiastikaCount = myOusiastikaList.Ousiastika.Length;
        GW();
    }


    public void GW()
    {
        int epithetaCount = myEpithetaList.Epitheta.Length;
        int ranE = Random.Range(0, epithetaCount);

        int ousiastikaCount = myOusiastikaList.Ousiastika.Length;
        int ranO = Random.Range(0, ousiastikaCount);



        Debug.Log(myEpithetaList.Epitheta[ranE].epitheto + " " +  myOusiastikaList.Ousiastika[ranO].ousiastiko);
    }


    public string EpithetoGenerator()
    {
        return CheckGenos();
    }


    public string OusiastikoGenerator()
    {
        _ranO = Random.Range(0, _ousiastikaCount);
        return myOusiastikaList.Ousiastika[_ranO].ousiastiko;
    }

    public string CheckGenos()
    {
        if (myOusiastikaList.Ousiastika[_ranO].genos == "ou")
        {
            string str = myEpithetaList.Epitheta[Random.Range(0, _epithetaCount)].epitheto;
            str = str.Remove(str.Length - 1);
            str = str.Insert(str.Length, "ο");
            return str;
        }
        else
        {
            return myEpithetaList.Epitheta[Random.Range(0, _epithetaCount)].epitheto;
        }
    }
    
}
