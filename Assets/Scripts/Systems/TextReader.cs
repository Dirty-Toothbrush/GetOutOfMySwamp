using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextReader : MonoBehaviour
{
    GameObject textManager;
    public string key;
    public GameObject textContainer;
    private string _text;
    private GameObject levelManager;

    private void Awake()
    {
        //textManager = GameObject.Find("GameManager");
        if (SceneManager.GetActiveScene().name.Equals("Game"))
        {
            levelManager = GameObject.Find("LevelManager");
        }
    }
    private void Start()
    {
        if (GameManager.instance == null)
            return;

        textManager = GameManager.instance.gameObject;

        Subscribe();
        if (!key.Equals(""))
        {
            Read();
        }

        if (gameObject.name.Equals("LanguageButton"))
        {
            Button b;
            if (gameObject.TryGetComponent<Button>(out b))
            {
                b.onClick.AddListener(ChangeLenguage);
            }

        }
        if (gameObject.name.Equals("ExitButton") || gameObject.name.Equals("RestartButton") || gameObject.name.Equals("Select"))
        {
            Button b;
            if (gameObject.TryGetComponent<Button>(out b))
            {
                b.onClick.AddListener(EmptyLists);
            }
        }
    }

    public void Subscribe()
    {
        if (textManager != null)
            textManager.GetComponent<TextManager>().Subscribe(gameObject, SceneManager.GetActiveScene().name);
    }

    public void Read()
    {
        if (textManager == null)
            _text = "ERROR";
        else
            _text = textManager.GetComponent<TextManager>().currentDictionary[key];


        if (gameObject.name.Equals("hpText"))//Replace with keys when and if possible
        {
            textContainer.GetComponent<Text>().text = levelManager.GetComponent<LevelStats>().GetCurrentBaseHealth().ToString();
        }
        else if (gameObject.name.Equals("moneyText"))
        {
            textContainer.GetComponent<Text>().text = levelManager.GetComponent<LevelStats>().GetCurrentMoney().ToString();
        }
        else
        {
            textContainer.GetComponent<Text>().text = _text;
        }
    }

    public void ChangeLenguage()
    {
        textManager.GetComponent<TextManager>().ChangeLenguage();
    }

    public void EmptyLists()
    {
        if (gameObject.name.Equals("RestartButton"))
        {
            textManager.GetComponent<TextManager>().emptyGameobjectsList(true);
        }
        else
        {
            textManager.GetComponent<TextManager>().emptyGameobjectsList(false);
        }

    }

    public string GetText()
    {
        return _text;
    }

    public void SetKey(string newKey)
    {
        key = newKey;
        Read();
    }
}
