using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//class DictionaryColors
//{
//    static public void Main()
//    {
//        Dictionary<string, string> IVColors = new Dictionary<string, string>();

//        IVColors.Add("Red", "FF0000");
//        IVColors.Add("Blue", "0000FF");
//        IVColors.Add("Yellow", "FFFF00");
//        IVColors.Add("Orange", "FFA500");
//        IVColors.Add("Purple", "7A1FA0");
//        IVColors.Add("Green", "24B550");
//        IVColors.Add("Vermillion", "F95300");
//        IVColors.Add("Amber", "FCCC00");
//        IVColors.Add("Chartreuse", "DFFF00");
//        IVColors.Add("Teal", "1A8E7D");
//        IVColors.Add("Violet", "7543FF");
//        IVColors.Add("Magenta", "AA31AA");

//        var Colours = new Dictionary<string, string>();
//        Colours["Red"] = "FF0000";
//        Colours["Blue"] = "0000FF";
//        Colours["Yellow"] = "FFFF00";
//        Colours["Orange"] = "FFA500";
//        Colours["Purple"] = "7A1FA0";
//        Colours["Green"] = "24B550";
//        Colours["Vermillion"] = "F95300";
//        Colours["Amber"] = "FCCC00";
//        Colours["Chartreuse"] = "DFFF00";
//        Colours["Teal"] = "1A8E7D";
//        Colours["Violet"] = "7543FF";
//        Colours["Magenta"] = "AA31AA";


//    }

//    //List<Button> buttons = new List<Button>();
//    //public SpriteRenderer IVbag;

//    //public void changeColor(Text colorIndex)
//    //{
//    //    //IVbag.color = Colour
//    //}

//    //public void findColor(string colorName)
//    //{
//    //    if (!Colours.Contains(colorName)
//    //}
//}

public class IVGame : MonoBehaviour
{
    //General Info o7
    public SpriteRenderer IVbag;
    public IVBag ivbagRef;
    private string currentColor;

    //Level differentiation
    bool level1Difficulty = true;
    bool level2Difficulty;

    //Color sequencing
    int red = 0;
    int blue = 0;
    int yellow = 0;

    //Order
    public List<SpriteRenderer> orders;
    public List<String> orderColors;
    public string currentOrderColor;
    public List<String> TempColors;
    string[] colours = { "Red", "Blue", "Yellow", "Orange", "Purple", "Green", "Vermillion", "Amber", "Chartreuse", "Teal", "Violet", "Magenta" };


    //Check win conditions
    int CompletedColors = 0;
    int AmountToFinish;

    void Start()
    {
        resetOrders();
    }

    public Color GetColor(string colorName)
    {
        switch (colorName)
        {
            case "Red":
                return new Color(255, 0, 0);
                Debug.Log("Red");
                break;
            case "Blue":
                return new Color(0, 0, 255);
                Debug.Log("Blue");
                break;
            case "Yellow":
                return new Color(255, 255, 0);
                Debug.Log("Yellow");
                break;
            case "Orange":
                return new Color(1, .647f, 0);
                Debug.Log("Orange");
                break;
            case "Purple":
                return new Color(.478f, .1215f, .6274f, 1);
                Debug.Log("Purple");
                break;
            case "Green":
                return new Color(.1411f, .7908f, .3137f);
                Debug.Log("Green");
                break;
            case "Vermillion":
                return new Color(.9764f, .3254f, 0);
                Debug.Log("Vermillion");
                break;
            case "Amber":
                return new Color(.9882f, .8f, 0);
                Debug.Log("Amber");
                break;
            case "Chartreuse":
                return new Color(.8745f, 1, 0);
                Debug.Log("Chartreuse");
                break;
            case "Teal":
                return new Color(.1019f, .5568f, .4901f);
                Debug.Log("Teal");
                break;
            case "Violet":
                return new Color(.4588f, .2627f, 1);
                Debug.Log("Violet");
                break;
            case "Magenta":
                return new Color(.666f, .1921f, .666f);
                Debug.Log("Magenta");
                break;

        }
        return new Color(0, 0, 0);
    }

    public void changeColor(TextMeshProUGUI Color)
    {
        IVbag.color = GetColor(Color.name);
        currentColor = Color.name;
        //Debug.Log(GetColor(Color.name));
    }

    public void changeColor(string colorName)
    {
        IVbag.color = GetColor(colorName);
        currentColor = colorName;
    }

    public void addSyringe(GameObject Color)
    {
        if (!ivbagRef.level3)
        {
            if (Color.name == "Red")
            {
                red++;
            }
            else if (Color.name == "Blue")
            {
                blue++;
            }
            else
            {
                yellow++;
            }

            ivbagRef.syringeClicked();
            Debug.Log(Color.name);
            changeColor(colorUnsequencer());
        }
        else
        {
            checkOrders();
        }
    }

    public void resetOrders()
    {
        CompletedColors = 0;
        orderColors.Clear();
        foreach (SpriteRenderer o in orders)
        {
            o.enabled = false;
        }

        if (level1Difficulty)
        {

            AmountToFinish = 4;
            TempColors.Clear();
            for( int i = 0; i < colours.Length; i++)
            {
                TempColors.Add(colours[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                orders[i].enabled = true;
                string tempColor;
                int tempI = UnityEngine.Random.Range(0, TempColors.Count);
                tempColor = TempColors[tempI];

                TempColors.RemoveAt(tempI);
                currentOrderColor = tempColor;

                orders[i].color = GetColor(tempColor);
                currentOrderColor = tempColor;
                Debug.Log(currentOrderColor);
                orderColors.Add(currentOrderColor);

            }
        }
        else
        {
            TempColors.Clear();
            for (int i = 0; i < colours.Length; i++)
            {
                TempColors.Add(colours[i]);
            }

            for (int i = 0; i < 6; i++)
            {
                orders[i].enabled = true;
                string tempColor;
                int tempI = UnityEngine.Random.Range(0, TempColors.Count);
                tempColor = TempColors[tempI];
                TempColors.RemoveAt(tempI);

                orders[i].color = GetColor(tempColor);
                currentOrderColor = tempColor;
                orderColors.Add(currentOrderColor);
                Debug.Log(orderColors[i]);
            }
        }
    }

    public string getRandomColor(string [] UniqueColorList)
    {
        string newColor;
        newColor = UniqueColorList[UnityEngine.Random.Range(0, UniqueColorList.Length)];
        currentOrderColor = newColor;
        return newColor;
    }

    public string colorUnsequencer()
    {
        #region Pleas no open
        if (red == 0 && blue == 0 && yellow == 0)
        {
            return "null";
        }
        else if ((red == 1 && blue == 0 && yellow == 0) || (red == 2 && blue == 0 && yellow == 0) || (red == 3 && blue == 0 && yellow == 0))
        {
            return "Red";
        }
        else if ((red == 0 && blue == 1 && yellow == 0) || (red == 0 && blue == 2 && yellow == 0) || (red == 0 && blue == 3 && yellow == 0))
        {
            return "Blue";
        }
        else if ((red == 0 && blue == 0 && yellow == 1) || (red == 0 && blue == 0 && yellow == 2) || (red == 0 && blue == 0 && yellow == 3))
        {
            return "Yellow";
        }
        else if (red == 1 && blue == 0 && yellow == 1)
        {
            return "Orange";
        }
        else if (red == 1 && blue == 1 && yellow == 0)
        {
            return "Purple";
        }
        else if (red == 0 && blue == 1 && yellow == 1)
        {
            return "Green";
        }
        else if (red == 2 && blue == 0 && yellow == 1)
        {
            return "Vermillion";
        }
        else if (red == 1 && blue == 0 && yellow == 2)
        {
            return "Amber";
        }
        else if (red == 0 && blue == 1 && yellow == 2)
        {
            return "Chartreuse";
        }
        else if (red == 0 && blue == 2 && yellow == 1)
        {
            return "Teal";
        }
        else if (red == 1 && blue == 2 && yellow == 0)
        {
            return "Violet";
        }
        else if (red == 2 && blue == 1 && yellow == 0)
        {
            return "Magenta";
        }
        #endregion
        return "null";
    }

    public void resetColors()
    {
        red = 0;
        blue = 0;
        yellow = 0;
    }

    public void checkOrders()
    {       
        int i = 0;
        foreach (String o in orderColors)
        {
            //Debug.Log(i);
            if (currentColor == o)
            {
                Debug.Log("Removing color");
                orders[i].enabled = false;
                orderColors[i] = "________";
                ivbagRef.emptyIV();
                CompletedColors++;
                break;
            }
            i++;
        }

        if (CompletedColors == AmountToFinish)
            Win();

    }
    public void print()
    {
        for (int i = 0; i < orderColors.Count; i++)
        {
            Debug.Log(orderColors[i]);
        }
    }

    public void Win()
    {
        Debug.Log("You Finished!");
    }
}


