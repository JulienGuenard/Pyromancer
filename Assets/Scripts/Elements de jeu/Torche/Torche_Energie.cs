using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torche_Energie : MonoBehaviour {

	SC_Ecran_Perdu EcranPerdu;

	GameObject SC_Ecran;
    GameObject TorcheBar;
    GameObject TorcheGif;

    public float EnergieDepart;
	public float Energie;
	public float EnergieProgressive;
	public float EnergieIncendie;
	public float EnergieBrasero;
	public float EnergieMax;

	public float EnergieBaisseProgressiveFrequence;

    Image TorcheBarImage;
    RenderTexture TorcheGifImage;


    Animator animator;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

		SC_Ecran = GameObject.Find ("SC_Ecran");
		EcranPerdu = SC_Ecran.GetComponent<SC_Ecran_Perdu> ();

		TorcheBar = GameObject.Find ("TorcheBar");
		TorcheBarImage = TorcheBar.GetComponent<UnityEngine.UI.Image> ();
		Energie = EnergieDepart;
		StartCoroutine ("EnergieProg");

        TorcheGif = GameObject.Find("TorcheGraph");
        TorcheGifImage = TorcheBar.GetComponent<RenderTexture>();

    }

    // Update is called once per frame 2*100/100 = 2   2
    void Update () {
        if (Energie > 100) {
			Energie = 100;
		}

        TorcheBarImage.fillAmount = Energie / EnergieMax;

        if (Energie <= 0) { // si on ne peut plus brûler
            if (GameObject.FindGameObjectWithTag("Maison_Incendie") != null) // s'il y a une chaîne de feu qui pourrait faire gagner le joueur, on attend qu'elles brûlent toutes
                return;
            if (GameObject.FindGameObjectWithTag("Maison") == null) // si le joueur a brûlé toutes les maisons disponibles, il ne peut pas perdre par manque de feu
                return;

            EcranPerdu.Perdu ();
			Energie = 0;

            Destroy(this);
		}

	    return;

		if (Energie > 49) {
			animator.SetTrigger ("idle");
		}
		if (Energie < 50 && Energie > 24) {
			animator.SetTrigger ("50trig");
		}
		if (Energie < 25) {
			animator.SetTrigger ("25trig");
		}
	}

	IEnumerator EnergieProg () {
		yield return new WaitForSeconds (EnergieBaisseProgressiveFrequence);
		Energie += EnergieProgressive;
		StartCoroutine ("EnergieProg");
	}

	public void Incendie () {
		Energie += EnergieIncendie;
	}

	public void Brasero () {
		Energie += EnergieBrasero;
	}

}
