using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI_Manager : MonoBehaviour
{
    

    [Header("Main UIs")]
    public GameObject IntroStoryUI;
    public GameObject CharacterSelectionUI;
    public GameObject SentenceGeneratorUI;
    public GameObject DungeonUI;
    public GameObject GameOverUI;

    [Header("Components")]
    public TextMeshProUGUI IntroStoryText;
    public GameObject AntonisTextWindow;
    public TextMeshProUGUI AntonisText;
    public GameObject ButtonStart;

    [SerializeField]
    [Header("Gun Components")]
    public Image SpriteHolder_Gun;
    public TextMeshProUGUI Text_GunName;
    public TextMeshProUGUI Text_bulletspeed;
    public TextMeshProUGUI Text_bulletdmg;
    public TextMeshProUGUI Text_bulletrange;
    public TextMeshProUGUI Text_rateOfFire;

    [SerializeField]
    [Header("Character Components")]
    public Image SpriteHolder_Character;
    public Sprite SpriteHolder_Georgios;
    public Sprite SpriteHolder_Julian;
    public TextMeshProUGUI Text_charName;
    public TextMeshProUGUI Text_char_movementSpeed;
    public List<GameObject> Character_Lifes = new List<GameObject>();

    [Header("Scripts")]
    public SentenceGenerator sentenceGenerator;

    private bool _cr_Running = false;
    private int _mainCharacter;
    private bool _introstory;

    public void OnEnable()
    {
        SentenceGenerator.onGenerated += EnableStartButton;
    }

    public void Start()
    {
        _introstory = true;
        StartCoroutine(WriteSentence("Two acclaimed AI researchers, Georgios and Julian, are chased by the same AI concepts and bugs they long created. Play as Georgios or Julian and try to save the other one as many times as you can in an completely PCG AI environment!", IntroStoryText));
    }

    //Buttons

    public void Button_Character(int selection)
    {
        if (selection==0) //Georgios selection
        {
            CharacterSelectionUI.SetActive(false);
            SentenceGeneratorUI.SetActive(true);

            sentenceGenerator.GenerateSentence();

            _mainCharacter = 0;

            // add +20% speed movement
            // load Dungeon with active player Georgios
        }
        else if (selection == 1) // Julian selection
        {
            CharacterSelectionUI.SetActive(false);
            SentenceGeneratorUI.SetActive(true);

            sentenceGenerator.GenerateSentence();

            _mainCharacter = 1;

            // add +20% health
            // load Dungeon with active player Julian
        }

    }

    public void Button_Antonis()
    {
        AntonisTextWindow.SetActive(!AntonisTextWindow.activeSelf);

        if (AntonisTextWindow.activeSelf && !_cr_Running)
        {
            StartCoroutine(WriteSentence("Today the schedule is very light in terms of content but rich in pain and anguish. Yay!", AntonisText));
        }
    }

    public void Button_StartDungeon()
    {
        // load Dungeon Scene with active player either Georgios or Julian
        SceneManager.LoadScene("Dungeon", LoadSceneMode.Additive);
        SentenceGeneratorUI.SetActive(false);
        DungeonUI.SetActive(true);
    }

    public void Button_Restart()
    {
        GameOverUI.SetActive(false);

        CharacterSelectionUI.SetActive(true);

        //unload the Dungeon Scene
    }

    void EnableStartButton()
    {
        ButtonStart.SetActive(true);
    }
    
    //IEnums

    IEnumerator WriteSentence(string finalSentence, TextMeshProUGUI TMPText)
    {
        _cr_Running = true;

        TMPText.text = "";

        for (int i = 0; i < finalSentence.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            char x = finalSentence[i];
            TMPText.text = TMPText.text + x;
        }

        _cr_Running = false;

        if(_introstory)
        {
            yield return new WaitForSeconds(3f);
            IntroStoryUI.SetActive(false);
            CharacterSelectionUI.SetActive(true);
            _introstory = false;
        }

    }


    //externals

    public void UI_LoadGameOver()
    {
        GameOverUI.SetActive(true);
    }

    public int GetMainCharacter()
    {
        return _mainCharacter;
    }



    public void setCharUI(float CharMovement, float CharHealth)
    {
        

        if (_mainCharacter == 0)
        {
            Text_charName.text = "Georgios";
            SpriteHolder_Character.sprite = SpriteHolder_Georgios;
        }
        else if (_mainCharacter == 1)
        {
            SpriteHolder_Character.sprite = SpriteHolder_Julian;
            Text_charName.text = "Julian";
        }

        //Text_charName.text = CharName;
        Text_char_movementSpeed.text = CharMovement.ToString();


        SetHealth(CharHealth);

    }

    public void setGunUI(Sprite spriteImage, string GunName, float bulletSpeed, float bulletDMG, float rateOfFire)
    {
        SpriteHolder_Gun.sprite = spriteImage;

        Text_GunName.text = GunName;
        Text_bulletspeed.text = bulletSpeed.ToString();
        Text_bulletdmg.text = bulletDMG.ToString();
        Text_bulletrange.text = rateOfFire.ToString();
    }




    // "I am tired" code - sorry for anyone who sees it

    public void SetHealth(float CharHealth)
    {
        if (CharHealth <= 110)
        {
            Character_Lifes[11].SetActive(false);
        }

        if (CharHealth <= 100)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
        }

        if (CharHealth <= 90)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
        }

        if (CharHealth <= 80)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
        }

        if (CharHealth <= 70)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
            Character_Lifes[7].SetActive(false);
        }

        if (CharHealth <= 60)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
            Character_Lifes[7].SetActive(false);
            Character_Lifes[6].SetActive(false);
        }

        if (CharHealth <= 50)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
            Character_Lifes[7].SetActive(false);
            Character_Lifes[6].SetActive(false);
            Character_Lifes[5].SetActive(false);
        }

        if (CharHealth <= 40)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
            Character_Lifes[7].SetActive(false);
            Character_Lifes[6].SetActive(false);
            Character_Lifes[5].SetActive(false);
            Character_Lifes[4].SetActive(false);
        }

        if (CharHealth <= 30)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
            Character_Lifes[7].SetActive(false);
            Character_Lifes[6].SetActive(false);
            Character_Lifes[5].SetActive(false);
            Character_Lifes[4].SetActive(false);
            Character_Lifes[3].SetActive(false);
        }

        if (CharHealth <= 20)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
            Character_Lifes[7].SetActive(false);
            Character_Lifes[6].SetActive(false);
            Character_Lifes[5].SetActive(false);
            Character_Lifes[4].SetActive(false);
            Character_Lifes[3].SetActive(false);
            Character_Lifes[2].SetActive(false);
        }


        if (CharHealth <= 10)
        {
            Character_Lifes[11].SetActive(false);
            Character_Lifes[10].SetActive(false);
            Character_Lifes[9].SetActive(false);
            Character_Lifes[8].SetActive(false);
            Character_Lifes[7].SetActive(false);
            Character_Lifes[6].SetActive(false);
            Character_Lifes[5].SetActive(false);
            Character_Lifes[4].SetActive(false);
            Character_Lifes[3].SetActive(false);
            Character_Lifes[2].SetActive(false);
            Character_Lifes[1].SetActive(false);
        }
    }

}
