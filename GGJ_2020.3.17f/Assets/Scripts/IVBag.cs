using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IVBag : MonoBehaviour
{
    public bool level1;
    public bool level2;
    public bool level3;

    private string level1Color;
    private string level2Color;
    private string level3Color;

    public Sprite thirdFull;
    public Sprite twoThirdsFull;
    public Sprite fullFull;

    public SpriteRenderer IVFill;
    public IVGame ivGameRef;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeImage()
    {
        if (level1)
        {
            IVFill.sprite = thirdFull;
        }

        if (level2)
        {
            IVFill.sprite = twoThirdsFull;
        }

        if (level3)
        {
            IVFill.sprite = fullFull;
        }

        if (!level1 && !level2 && !level3)
        {
            IVFill.sprite = null;
        }
    }

    public void syringeClicked()
    {
        if (!level1 && !level2 && !level3)
        {
            level1 = true;
            changeImage();
        }
        else if (level1)
        {
            level1 = false;
            level2 = true;
            changeImage();
        }
        else if (level2)
        {
            level2 = false;
            level3 = true;
            changeImage();
        }
        else if (level3)
        {
            Debug.Log("IV Full");
        }
    }

    public void emptyIV()
    {
        level1 = false;
        level2 = false;
        level3 = false;
        changeImage();
        ivGameRef.resetColors();
    }
}
