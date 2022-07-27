using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Joueur_PrendreVase : MonoBehaviour {
    GameObject Cible;
    GameObject VasePris;
    GameObject GRP_Vase;
    GameObject HoldObject;

    Color VaseColor;

    Joueur_Deplacement JoueurDeplacement;

    float Vertical;

    // Use this for initialization
    void Start() {
        GRP_Vase = GameObject.Find("GRP_Vase");
        HoldObject = GameObject.Find("Hold");
        VaseColor = new Color(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Action") == true && Cible != null && VasePris == null)
        {
            PrendVase();
            return;
        }

        if (VasePris != null)
        {
            GameObject.Find("Actions_Vase_txt").GetComponent<Text>().color = new Color(255f, 255f, 255f, 255f);

        }
        else
        {
            GameObject.Find("Actions_Vase_txt").GetComponent<Text>().color = new Color(255f, 255f, 255f, 0);
            return;
        }

        if (Input.GetButtonDown("Action_A") == true)
        {  // TOUCHE A
            LanceVase();
            return;
        }

        else if (Input.GetButtonDown("Action") == true)
        {
            LacheVase();
            return;
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Vase") {
            if(VasePris != null)
                return;
            if (Cible != null) {
                Cible.GetComponentInChildren<MeshRenderer>().material.color = VaseColor;
            }
            Cible = col.gameObject;
            SelectionneVase(Cible, Color.yellow);

            if (GameObject.Find("Actions_Vase_txt").GetComponent<Text>().color.a == 0)
                GameObject.Find("Prendre_Vase_txt").GetComponent<Text>().color = new Color(255f, 255f, 255f, 255f);
            else {
                GameObject.Find("Prendre_Vase_txt").GetComponent<Text>().color = new Color(255f, 255f, 255f, 0f);
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject == Cible && Cible != null) {
            if (VasePris == null)
                Cible = DeselectionneVase(Cible);
            GameObject.Find("Prendre_Vase_txt").GetComponent<Text>().color = new Color(255f, 255f, 255f, 0f);
        }
    }

    void PrendVase() {
        VasePris = Cible;
        VasePris.tag = "VasePris";
        VasePris.transform.position = HoldObject.transform.position;
        VasePris.transform.rotation = HoldObject.transform.rotation;
        VasePris.transform.parent = HoldObject.transform;
        SelectionneVase(VasePris, Color.white);
    }

    void LacheVase() {
        VasePris.transform.position = transform.position;
        VasePris.transform.Translate(VasePris.transform.forward);
        VasePris.transform.parent = GRP_Vase.transform;
        VasePris.tag = "Vase";
        VasePris = DeselectionneVase(VasePris);
    }

    void LanceVase() {
        VasePris.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        VasePris.transform.parent = GRP_Vase.transform;
        VasePris.GetComponent<Rigidbody>().AddForce(transform.forward * 1000f);
        VasePris.GetComponent<Rigidbody>().AddForce(transform.up * 1f);
        VasePris.GetComponent<BoxCollider>().size *= 3;
        VasePris = DeselectionneVase(VasePris);
    }

    void SelectionneVase(GameObject cible, Color setColor) {
        cible.GetComponentInChildren<MeshRenderer>().material.EnableKeyword("_EMISSION");
        cible.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
    }
    GameObject DeselectionneVase(GameObject cible) {
        cible.GetComponentInChildren<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
        cible.GetComponentInChildren<MeshRenderer>().material.EnableKeyword("_EMISSION");
        cible = null;
        return cible;
    }
}