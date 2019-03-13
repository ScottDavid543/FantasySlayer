using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public ButtonController buttonController;
    public Instantiater instantiate;
    public GameObject playerM;
    public GameObject playerF;
    public GameObject Title;
    public GameObject PlayButton;
    public GameObject CharSelectButton;
    public GameObject LevelSelectButton;
    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;
    public GameObject LevelSelectText;
    public GameObject MenuButton;
    public GameObject M;
    public GameObject F;
    public GameObject playerK;
    public GameObject FemaleNinjaImage;
    public GameObject MaleNinjaImage;
    public GameObject KnightImage;
    public GameObject Camera;
    public GameObject Background;

    
    public static float count = 0 ;
    public int NewCount = 0;

    public void Start()
    {
        Debug.Log("Start");
        //GameObject player = (GameObject)Instantiate(Resources.Load("Player"));
        Title = GameObject.FindGameObjectWithTag("Title");
        PlayButton = GameObject.FindGameObjectWithTag("PlayButton");
        CharSelectButton = GameObject.FindGameObjectWithTag("CharSelectButton");
        LevelSelectButton = GameObject.FindGameObjectWithTag("LevelSelectButton");
        Level1Button = GameObject.FindGameObjectWithTag("Level1Button");
        Level2Button = GameObject.FindGameObjectWithTag("Level2Button");
        Level3Button = GameObject.FindGameObjectWithTag("Level3Button");
        LevelSelectText = GameObject.FindGameObjectWithTag("LevelSelectText");
        MenuButton = GameObject.FindGameObjectWithTag("MenuButton");
        playerM = (GameObject)Resources.Load("Player");
        playerF = (GameObject)Resources.Load("PlayerF");
        playerK = (GameObject)Resources.Load("PlayerK");
        FemaleNinjaImage = GameObject.FindGameObjectWithTag("FemaleNinjaImage");
        MaleNinjaImage = GameObject.FindGameObjectWithTag("MaleNinjaImage");
        KnightImage = GameObject.FindGameObjectWithTag("KnightImage");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Background = GameObject.FindGameObjectWithTag("Background");
        
        instantiate = new Instantiater();

        if (SceneManager.GetActiveScene().name != "Menu" && count ==1)
        {
            GameObject player = (GameObject)instantiate.InstantiatePlayer(playerF);
            Camera.transform.parent = player.transform;
            Background.transform.parent = player.transform;
            
           

        }
        if (SceneManager.GetActiveScene().name != "Menu" && count == 2)
        {
            GameObject player = (GameObject)instantiate.InstantiatePlayer(playerM);
            Camera.transform.parent = player.transform;
            Background.transform.parent = player.transform;
            
        }
        if (SceneManager.GetActiveScene().name != "Menu" && count == 3)
        {
            GameObject player = (GameObject)instantiate.InstantiatePlayer(playerK);
            Camera.transform.parent = player.transform;
            Background.transform.parent = player.transform;
           
        }
    }
    void update()
    {
        Debug.Log(count);
    }

    void OnLevelWasLoaded()
    {
        
        //GameObject player = (GameObject)Instantiate(Resources.Load("Player"));
        Title = GameObject.FindGameObjectWithTag("Title");
        PlayButton = GameObject.FindGameObjectWithTag("PlayButton");
        CharSelectButton = GameObject.FindGameObjectWithTag("CharSelectButton");
        LevelSelectButton = GameObject.FindGameObjectWithTag("LevelSelectButton");
        Level1Button = GameObject.FindGameObjectWithTag("Level1Button");
        LevelSelectText = GameObject.FindGameObjectWithTag("LevelSelectText");
        MenuButton = GameObject.FindGameObjectWithTag("MenuButton");
        playerM = (GameObject)Resources.Load("Player");
        playerF = (GameObject)Resources.Load("PlayerF");
        playerK = (GameObject)Resources.Load("PlayerK");
        M = GameObject.FindGameObjectWithTag("M");
        F = GameObject.FindGameObjectWithTag("F");
        instantiate = new Instantiater();
        FemaleNinjaImage = GameObject.FindGameObjectWithTag("FemaleNinjaImage");
        MaleNinjaImage = GameObject.FindGameObjectWithTag("MaleNinjaImage");
        KnightImage = GameObject.FindGameObjectWithTag("KnightImage");

      
    }


    public void LoadLevel1(string L1)
    {
        SceneManager.LoadScene(L1);
    }
    public void LoadLevel2(string L2)
    {
        SceneManager.LoadScene(L2);
    }
    public void LoadLevel3(string L3)
    {
        SceneManager.LoadScene(L3);
    }
    public void LevelSelect()
    {        
        Title.SetActive(false);
        PlayButton.SetActive(false);
        CharSelectButton.SetActive(false);
        LevelSelectButton.SetActive(false);
        Level1Button.SetActive(true);
        Level2Button.SetActive(true);
        Level3Button.SetActive(true);
        LevelSelectText.SetActive(true);
        MenuButton.SetActive(true);
        FemaleNinjaImage.SetActive(false);
        MaleNinjaImage.SetActive(false);
        KnightImage.SetActive(false);
        FemaleNinjaImage.SetActive(false);
        MaleNinjaImage.SetActive(false);
        KnightImage.SetActive(false);
    }
    public void LoadMenu(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
    public void SelectCharF()
    {
        count = 1;
        NewCount = 1;
        //playerM.SetActive(false);
        //playerF.SetActive(true);
        
        PlayButton.SetActive(true);
        LevelSelectButton.SetActive(true);
        FemaleNinjaImage.SetActive(true);
        MaleNinjaImage.SetActive(false);
        KnightImage.SetActive(false);
    }
    public void SelectCharM()
    {
        count = 2;
        NewCount = 1;
        //playerM.SetActive(true);
        //playerF.SetActive(false);

        
        PlayButton.SetActive(true);
        LevelSelectButton.SetActive(true);
        MaleNinjaImage.SetActive(true);
        FemaleNinjaImage.SetActive(false);
        KnightImage.SetActive(false);
    }
    public void SelectCharK()
    {
        count = 3;
        NewCount = 3;

        PlayButton.SetActive(true);
        LevelSelectButton.SetActive(true);
        KnightImage.SetActive(true);
        FemaleNinjaImage.SetActive(false);
        MaleNinjaImage.SetActive(false);
    }
   
}
