using TMPro;
using UnityEngine;

public class MicroShop : MonoBehaviour
{
    [SerializeField]
    GameObject MenuUI;

    [SerializeField]
    GameObject MicroShopUI;

    private int gems;
    private int shopSelect;
    private bool itemBeingBought = false;
    private bool MenuOpen = false;
    private bool MicroShopOpen = false;

    public TextMeshProUGUI currentMoney;

/*
    int test01 = 0;
    int test02 = 0;
    int test03 = 0;
    int test04 = 0;
    int test05 = 0;
*/

    public int Gems
    {
        get
        {
            return gems;
        }
        set
        {
            // Insert safety checks etc.
            gems = value;
            currentMoney.text = Gems.ToString();
        }
    }

    void Update()
    {
        if (itemBeingBought)
        {
            switch (shopSelect)
            {
                case 1:
                    Gems += 100;
                    break;
                case 2:
                    Gems += 300;
                    break;
                case 3:
                    Gems += 750;
                    break;
                case 4:
                    Gems += 1200;
                    break;
                case 5:
                    Gems += 2000;
                    break;

                default:
                    break;
            }

            itemBeingBought = false;
        }
    }

    public void ToggleMenu()
    {
        if (!MenuOpen)
        {
            // Debug.Log("Controls disabled.");
            PlayerController.isEnabled = false;
            MenuUI.SetActive(true);
            MenuOpen = true;
        }
        else if (MenuOpen)
        {
            // Debug.Log("Controls enabled.");
            PlayerController.isEnabled = true;
            MenuUI.SetActive(false);
            MenuOpen = false;
        }
    }

    public void ToggleMicroStore()
    {
        if (!MicroShopOpen)
        {
            MicroShopUI.SetActive(true);
            MicroShopOpen = true;
        }
        else if (MicroShopOpen)
        {
            MicroShopUI.SetActive(false);
            MicroShopOpen = false;
        }
    }

    public void Gem100()
    {
        shopSelect = 1;
        itemBeingBought = true;
        // Debug.Log("Gem100: " + ++test01);
    }

    public void Gem300()
    {
        shopSelect = 2;
        itemBeingBought = true;
        // Debug.Log("Gem300: " + ++test02);
    }

    public void Gem750()
    {
        shopSelect = 3;
        itemBeingBought = true;
        // Debug.Log("Gem750: " + ++test03);
    }

    public void Gem1200()
    {
        shopSelect = 4;
        itemBeingBought = true;
        // Debug.Log("Gem1200: " + ++test04);
    }

    public void Gem2000()
    {
        shopSelect = 5;
        itemBeingBought = true;
        // Debug.Log("Gem2000: " + ++test05);
    }
}
