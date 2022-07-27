using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Etourdissable : MonoBehaviour {
    protected float EtourdissementSpeed = 0;

    IEnumerator Etourdissement() {
        EtourdissementSpeed = 5f;
        yield return new WaitForSeconds(3f);
        EtourdissementSpeed = 0f;
    }
}
