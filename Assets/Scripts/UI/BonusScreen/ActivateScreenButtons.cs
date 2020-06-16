using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateScreenButtons : MonoBehaviour
{
    public GameObject ActivateScreen;
    GameObject _button;
    bool _active;
    public Text activeText;
    public Image myImage;
    GameObject TreeMarkButton;

    private void Start()
    {
        TreeMarkButton = GameObject.Find("TreeMark");
    }

    public void Back()
    {
        TreeMarkButton.SetActive(true);
        ActivateScreen.SetActive(false);
    }



    public void ActivateBonus()
    {

        if (_active)
        {
            GameEngine.Engine.coins -= GameMechanics.Mechanics.BonusCost;
            TreeMarkButton.SetActive(true);
            _button.SendMessage("Activete");
        }
    }

    public void SelectTreeButton(GameObject button)
    {

        _button = button;
        _active = true;

        myImage.color = new Color(1, 1, 1, 1);
        activeText.color = new Color(1, 1, 1);
        TreeMarkButton.SetActive(false);
    }

    public void UnActiveButton()
    {
        TreeMarkButton.SetActive(false);
        _active = false;

        myImage.color = new Color(1, 1, 1, 0.5f);
        activeText.color = new Color(0.5f, 0.5f, 0.5f);
    }
}
