using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour {
    public Combo[] comboDictionary;
    
    // the compiled combo tree
    private ComboNode comboRoot;
    public ComboNode comboPointer;


    private void Awake() {
        comboRoot = new ComboNode();
        comboPointer = comboRoot;

        MoveState[] state;
        bool flag;
        List<ComboNode> comboNodeList;

        // build the tree
        // Go through every combo in the dictionary
        for (int i = 0; i < comboDictionary.Length; i++) {
            state = comboDictionary[i].data;

            comboPointer = comboRoot;

            //Go Through each state of a combo
            for (int j = 0; j < state.Length; j++) {

                flag = false;
                comboNodeList = comboPointer.branches[state[j].key];

                //Check inside branch to see if any are similar
                for (int c = 0; c < comboPointer.branches.Count; c++) {
                    if (comboNodeList[c].state.Equals(state[i])) {
                        comboPointer = comboNodeList[c];
                        flag = true;
                        break;
                    }
                }
                if (flag) {
                    continue;
                }

                ComboNode newNode = new ComboNode { state = state[i] };
                comboNodeList.Add(newNode);

                //Make pointer at other extra key if needed
                if (state[i].type != MoveStateType.Single) {

                    comboNodeList = comboPointer.branches[state[j].extraKey];

                    for (int c = 0; c < comboPointer.branches.Count; c++) {
                        if (comboNodeList[c].state.Equals(state[i])) {
                            comboPointer = comboNodeList[c];
                            flag = true;
                            break;
                        }
                    }
                    if (!flag) {
                        comboNodeList.Add(newNode);
                    }
                }
                comboPointer = newNode;

            }
        }
    }


}

// tree made up of ComboNode's, aren't you glad we took [Data Structures H]? 
// to traverse down the tree, use root.branches[InputID]
public class ComboNode {
    public Dictionary<InputID, List<ComboNode>> branches = new Dictionary<InputID, List<ComboNode>>();
    public MoveState state;

    // Animation
    // Sound
    // Particle

    public ComboNode() {
        for (int i = 0; i <= 10; i++) {
            branches[(InputID)i] = new List<ComboNode>();
        }
    }

#if UNITY_EDITOR
    public void DebugTree(string pre) {
        string store = pre + " [";
        for (int i = 0; i < branches.Count; i++) {
            if (branches[(InputID)i].Count != 0) {
                for (int j = 0; j < branches.Count; j++) {
                    store += (InputID)i + branches[(InputID)i][j].state.type.ToString();
                    DebugTree(pre + (InputID)i + branches[(InputID)i][j].state.type.ToString());
                }
            }
            
        }
    }
#endif

}