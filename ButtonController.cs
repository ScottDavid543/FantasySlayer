using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject LevelSelectButton;
    public GameObject Level1Button;
    public GameObject Level2Button;
    public GameObject Level3Button;
    public GameObject LevelSelectText;
    public GameObject MenuButton;
    public MenuController menuController;
    public GameObject playerM;
    public GameObject playerF;
    public GameObject FemaleNinjaImage;
    public GameObject MaleNinjaImage;
    public GameObject KnightImage;

 

    void Start () {
        PlayButton.SetActive(true);
        LevelSelectButton.SetActive(true);
        Level1Button.SetActive(true);
        Level2Button.SetActive(true);
        Level3Button.SetActive(true);
        LevelSelectText.SetActive(true);
        MenuButton.SetActive(true);
        FemaleNinjaImage.SetActive(true);
        MaleNinjaImage.SetActive(true);
        KnightImage.SetActive(true);
        

        //M.SetActive(true);
        //F.SetActive(true);
        //playerM.SetActive(true);
        //playerF.SetActive(true);
        menuController = new MenuController();
        menuController.Start();

        PlayButton.SetActive(false);
        LevelSelectButton.SetActive(false);
        Level1Button.SetActive(false);
        Level2Button.SetActive(false);
        Level3Button.SetActive(false);
        LevelSelectText.SetActive(false);
        MenuButton.SetActive(false);
        FemaleNinjaImage.SetActive(false);
        MaleNinjaImage.SetActive(false);
        KnightImage.SetActive(false);
        // M.SetActive(false);
        //F.SetActive(false);
        //playerM.SetActive(false);
        //playerF.SetActive(false);
        
    }
	
    void OnLevelWasLoaded()
    {
        menuController = new MenuController();
        menuController.Start();
    }
	
	void Update () {
	
	}
    public void LoadMenu(string Menu)
    {
        menuController.LoadMenu(Menu);
    }
    public void LoadLevel1(string L1)
    {
        menuController.LoadLevel1(L1);
    }
    public void LoadLVL2(string L2)
    {
        menuController.LoadLevel2(L2);
    }
    public void LoadLVL3(string L3)
    {
        menuController.LoadLevel3(L3);
    }
    public void levelSelect()
    {
        menuController.LevelSelect();
    }  
    public void SelectCharF()
    {
        menuController.SelectCharF();
    }
    public void SelectCharM()
    {
        menuController.SelectCharM();
    }
    public void SelectCharK()
    {
        menuController.SelectCharK();
    }

   
}
