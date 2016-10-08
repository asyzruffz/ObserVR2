using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SelectionManager : Singleton<SelectionManager>
{
    //public bool hideLineForSameObjs = false;
    public bool showLines = false;
    public GameObject lineType;
    public List<GameObject> nodes = new List<GameObject>();

    private List<GameObject> lines = new List<GameObject>();

    // Use this for initialization
    protected override void SingletonAwake ()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (nodes.Any() && !nodes.Last().GetComponent<Selectable>().selected)
        {
            ClearSelection();
        }
    }

    public void AddToSelection (GameObject obj)
    {
        obj.GetComponent<Selectable>().connected = true;
        nodes.Add(obj);

        /*if (hideLineForSameObjs && nodes.Count > 1)
        {
            if(nodes[nodes.Count - 2].name != nodes[nodes.Count - 1].name)
                CreateConnectionLine();
        }
        else
        {
            CreateConnectionLine();
        }*/

        if (showLines)
        {
            CreateConnectionLine();
        }
    }

    public void ClearSelection ()
    {
        foreach(GameObject sel in nodes)
        {
            if(sel != null)
                sel.GetComponent<Selectable>().Clear();
        }
        nodes.Clear();

        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
        lines.Clear();
    }
    
    public bool ValidateSelection(string pattern)
    {
        return Regex.IsMatch(ParseSelection(), pattern);
    }

    private void CreateConnectionLine ()
    {
        if (nodes.Count > 1)
        {
            GameObject startNode = nodes[nodes.Count - 2];
            GameObject endNode = nodes[nodes.Count - 1];
            
            GameObject connectionLine = Instantiate(lineType);
            connectionLine.name = "Line (" + startNode.name + ") to (" + endNode.name + ")";
            connectionLine.transform.parent = gameObject.transform;
            connectionLine.transform.position = startNode.transform.position;

            connectionLine.GetComponent<ConnectionLine>().start = startNode;
            connectionLine.GetComponent<ConnectionLine>().end = endNode;
            lines.Add(connectionLine);
        }
    }

    private string ParseSelection()
    {
        string parsedSelection = "";
        foreach (GameObject node in nodes)
        {
            parsedSelection += node.name + "-";
        }
        return parsedSelection;
    }
}
