// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ButtonConstraints : MonoBehaviour { // add this in the button
    private Button button;

    public List<string> constraintsLevel; // string list set on editor

    public void Start() {
        button = GetComponent<Button>();
        if (constraintsLevel.Count == 0)
            Destroy(this);
    }

    public void Update() {
        if (ButtonActivating.activatedLevels.Count == 0) {
            return;
        }

        foreach (string s in constraintsLevel) {
            if (!ButtonActivating.activatedLevels.Contains(s)) {
                return;
            }
        }

            button.interactable = true;
            this.enabled = false;
    }
}

