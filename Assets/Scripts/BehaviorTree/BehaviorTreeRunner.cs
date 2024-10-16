using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeRunner : MonoBehaviour
{
    [SerializeField] public BlackBoard Data;
    public Node rootNode;
    private bool hasRootNode = false;
    public Node.State treeState = Node.State.Running;
    private void Start()
    {
        Node root = null;
        foreach (Transform child in transform) 
        {
            root = child.GetComponent<Node>();
            break;
        }
        rootNode = root;
    }

    private void Update()
    {
        if (!hasRootNode)
        {
            hasRootNode = rootNode != null;

            if (!hasRootNode)
            {
                Debug.LogWarning($"{name} needs a root node in order to properly run. Please add one.", this);
            }
        }
        
        if (hasRootNode)
        {
            if (treeState == Node.State.Running) 
            {
                treeState = rootNode.UpdateNode();
            }
        }
        else
        {
            treeState = Node.State.Failure;
        }
    }
}
