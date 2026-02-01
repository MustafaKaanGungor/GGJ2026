using System.Collections.Generic;
using UnityEngine;

public class MaskSpot : MonoBehaviour
{
    public GameObject defaultMask;
    public GameObject downArrowMask;
    public GameObject upArrowMask;
    public GameObject horizontalMask;
    public GameObject damageMask;
    public bool isNull = true;

    public void ChangeMaskModel(LaserType laserType)
    {
        defaultMask.SetActive(false);
        downArrowMask.SetActive(false);
        upArrowMask.SetActive(false);
        horizontalMask.SetActive(false);
        damageMask.SetActive(false);

        switch (laserType)
        {
            case LaserType.Default:
            defaultMask.SetActive(true);
            break;
            case LaserType.VLaser2:
            downArrowMask.SetActive(true);
            break;
            case LaserType.VLaser21:
            upArrowMask.SetActive(true);
            break;
            case LaserType.EyeHorizontal:
            horizontalMask.SetActive(true);
            break;
            case LaserType.Cylinder:
            damageMask.SetActive(true);
            break;
            default:
            break;
        }
    }

    public void EmptySlot()
    {
        isNull = true;
        defaultMask.SetActive(false);
        downArrowMask.SetActive(false);
        upArrowMask.SetActive(false);
        horizontalMask.SetActive(false);
        damageMask.SetActive(false);
    }


}
