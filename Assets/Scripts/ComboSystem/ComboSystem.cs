using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour {
    public ComboDictionary comboDictionary;
    public ComboNode comboPointer;

    private ComboNode comboRoot;

    void Start() {
        comboRoot = new ComboNode();
    }
    
    void Update() {

    }
}

// tree made up of ComboNode's, aren't you glad we took [Data Structures H]?
// to traverse down the tree, use root.branches[InputID]
public class ComboNode {
    public Dictionary<InputID, ComboNode> branches = new Dictionary<InputID, ComboNode>();
    // Animation
    // Sound
    // Particle

    public ComboNode() {
        for (int i = 0; i <= 10; i++) {
            branches[(InputID)i] = null;
        }
    }

}