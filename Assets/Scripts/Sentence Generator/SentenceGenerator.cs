using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceGenerator : MonoBehaviour
{

    

    public TMPro.TextMeshProUGUI UI_FinalSentence;


    [Header("JSON files")]
    public TextAsset EventJSON;
    public TextAsset WhoJSON;
    public TextAsset VerbJSON;
    public TextAsset ObjJSON;


    public delegate void SentenceGeneration();
    public static event SentenceGeneration onGenerated;

    private int _epithetaCount;
    private int eventCount;
    private int whoCount;
    private int verbCount;
    private int objCount;
    private int _ranO;


    /// <summary>
    /// WHO JSON List
    /// </summary>
    ///

    [System.Serializable]
    public class Who
    {
        public string whoPhrase;
        public float whoFactor;
    }

    [System.Serializable]
    public class WhoList
    {
        public Who[] Who;
    }
    public WhoList myWhoList = new WhoList();


    /// <summary>
    /// Event JSON List
    /// </summary>

    [System.Serializable]
    public class EventClass
    {
        public string eventPhrase;
        public float eventFactor;
    }

    [System.Serializable]
    public class EventsList
    {
        public EventClass[] EventClass;
    }
    public EventsList myEventsList = new EventsList();

    /// <summary>
    /// Verb JSON List
    /// </summary>

    [System.Serializable]
    public class Verb
    {
        public string verbPhrase;
        public bool verbFactor;
    }

    [System.Serializable]
    public class VerbList
    {
        public Verb[] Verb;
    }
    public VerbList myVerbList = new VerbList();

    /// <summary>
    /// Verb JSON List
    /// </summary>

    [System.Serializable]
    public class Obj
    {
        public string objPhrase;
        public float objFactor;
    }

    [System.Serializable]
    public class ObjList
    {
        public Obj[] Obj;
    }
    public ObjList myObjList = new ObjList();


    public void Start()
    {
        myWhoList = JsonUtility.FromJson<WhoList>(WhoJSON.text);

        myEventsList = JsonUtility.FromJson<EventsList>(EventJSON.text);

        myVerbList = JsonUtility.FromJson<VerbList>(VerbJSON.text);

        myObjList = JsonUtility.FromJson<ObjList>(ObjJSON.text);


        //whoCount = myWhoList.Whos.Length;
        //_ousiastikaCount = myOusiastikaList.Ousiastika.Length;
        //GW();
        //GenerateSentence();
    }


    public void GW()
    {
        int whoCount = myWhoList.Who.Length;
        int ranE = Random.Range(0, whoCount);

        //int ousiastikaCount = myOusiastikaList.Ousiastika.Length;
        //int ranO = Random.Range(0, ousiastikaCount);



        //Debug.Log(myWhoList.Who[ranE].whoPhrase + " " + myWhoList.Who[ranE].whoFactor);
        //Debug.Log(myEventsList.EventClass[ranE].eventPhrase + " " + myEventsList.EventClass[ranE].eventFactor);
        //Debug.Log(myVerbList.Verb[ranE].verbPhrase + " " + myVerbList.Verb[ranE].verbFactor);
        //Debug.Log(myObjList.Obj[ranE].objPhrase + " " + myObjList.Obj[ranE].objFactor);
    }


    public string EpithetoGenerator()
    {
        return myWhoList.Who[Random.Range(0, _epithetaCount)].whoPhrase;
    }


    public string OusiastikoGenerator()
    {
        //_ranO = Random.Range(0, _ousiastikaCount);
        return myEventsList.EventClass[_ranO].eventPhrase;
    }

    public void GenerateSentence()
    {
        eventCount = myEventsList.EventClass.Length;
        whoCount = myWhoList.Who.Length;
        verbCount = myVerbList.Verb.Length;
        objCount = myObjList.Obj.Length;

        int ranE = Random.Range(0, eventCount);
        int ranW = Random.Range(0, whoCount);
        int ranV = Random.Range(0, verbCount);
        int ranO = Random.Range(0, objCount);

        string finalSentence = myEventsList.EventClass[ranE].eventPhrase + "" + myWhoList.Who[ranW].whoPhrase + "" +
            myVerbList.Verb[ranV].verbPhrase + "" + myObjList.Obj[ranO].objPhrase + "" ;


        StartCoroutine(WriteSentence(finalSentence));



    }

    IEnumerator WriteSentence(string finalSentence)
    {
        

        for (int i = 0; i < finalSentence.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            char x = finalSentence[i];
            UI_FinalSentence.text = UI_FinalSentence.text + x;
        }

        if (onGenerated != null)
            onGenerated();
    }


}