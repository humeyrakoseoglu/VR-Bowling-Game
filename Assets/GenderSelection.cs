using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelection : MonoBehaviour
{
    public static bool selectWoman;

    public void Man()
    {
        selectWoman = false;
    }
    public void Woman()
    {
        selectWoman = true;
    }

}
