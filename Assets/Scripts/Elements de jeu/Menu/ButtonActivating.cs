using System.Collections.Generic;
using UnityEngine;

public class ButtonActivating : MonoBehaviour{
    public static List<string> activatedLevels = new List<string>();

    public static void Victory(string wonLevel) {
        activatedLevels.Add(wonLevel);
    }
}

