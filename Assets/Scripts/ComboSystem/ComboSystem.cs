using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour {
    public ComboList comboList;
    
    // the compiled combo tree
    private ComboNode comboRoot;
    public ComboNode comboPointer;


    private void Awake() {
        comboRoot = new ComboNode();
        comboPointer = comboRoot;

        MoveState[] currentCombo;
        List<ComboNode> comboNodeList;

        // build the tree
        // Go through every combo in the dictionary
        for (int i = 0; i < comboList.list.Length; i++) {
            /** The process of converting a combo to a link of comboNodes (last edited by Natsumi, 1/29/2023 3:33)
             * I'm a strong believer in documentation
             * 
             * First we must consider the following
             * - A Combo is just a MoveState[]
             * - A ComboNode contains a MoveState, and children ComboNodes. It's designed this way so we can convert 
             *      Combo's to chains of ComboNodes, which we can later merge into one big tree.
             *      Merging will allow us to quickly traverse down any possible number of combos, which makes
             *      things awfully convenient for us later on when we want to figure out what animation/sounds
             *      we need to play, and if the combo fufills any objectives
             * - If you squint really hard and only consider one combo at a time, a ComboNode is really just a
             *      chain of MoveState's.
             *      
             * As we're building the combo tree, we're going to be adding the ComboNodes directly on, but just so 
             * we can understand how it would work, we can pretend we're just going to make one combo.
             * 
             * 
             * THE PROCESS!!!
             * 0. Initialize. [Combo combo] is picked out of ComboDictionary already,
             *                [ComboNode root] is going to be our starting ComboNode (and should never change), 
             *                [ComboNode currentCombo] is going to be an empty ComboNode, and
             *                [ComboNode pointer] is going to be set to currentCombo, but will point to whatever MoveState we're editing. 
             * 1. Loop 0-n
             *      1a. combo[i] gives us a MoveState (we're going to go over the combo move by move)
             *          now we're going to set the head's moveState
             *          pointer.moveState = combo[i]
             *      1b. Next we're going to create the next body. The fleshy chunky bits if you will.
             *          pointer.branches[combo[i]] = new ComboNode()
             *      1c. Point to our new friend!
             *          pointer = pointer.branches[combo[i]]
             *    This will keep going until it reaches the end of the combo! Right now it should look like this
             *    MoveState->MoveState->MoveState->MoveState
             *    Now we want to merge it into root! This becomes tricky as we have to later implement timing
             * 2. we're gonna add to the root now! We can safely ignore root.moveState
             *      2a. pointer2 = root, pointer1 = currentCombo
             *      2b. traverse that badboy until you find a place where no ComboNode has gone before
             *      2c. Add a new comboNode, pointer2.moveState = pointer1.moveState
             *      2d. that's kinda it
             * 
             * I have some thoughts on how long notes can be implemented, but I honestly have no idea how to implement polyrhythms in the game.
             * I'm just completely lost for that one. I'm not sure it's even possible.
             * For long notes, instead of List<MovementState>, each movement state would have a maxTime limit, the minLimit would be the previous max
             * This also means we can assign different combos depending on how long you hold the key, which can be helpful if we wanted to design for
             * charge attacks.
             * ({ MovementState ms, float max })[]
             **/

            // 0, initialize
            currentCombo = comboList.list[i].data;
            comboPointer = comboRoot;

            Debug.Log("natsumi");
            //Go Through each state of a combo
            for (int j = 0; j < currentCombo.Length; j++) {
                Debug.Log("cratsumi");
                comboNodeList = comboPointer.branches[currentCombo[j].key];
            }
        }

        //comboRoot.DebugTree("S");
    }
}

// tree made up of ComboNode's, aren't you glad we took [Data Structures H]? 
// to traverse down the tree, use root.branches[InputID]
public class ComboNode {
    public Dictionary<InputID, List<ComboNode>> branches = new Dictionary<InputID, List<ComboNode>>();
    public MoveState moveState;

    // Animation
    // Sound
    // Particle

    public ComboNode() {
        for (int i = 0; i <= 10; i++) {
            branches[(InputID)i] = new List<ComboNode>(0);
        }
    }
}