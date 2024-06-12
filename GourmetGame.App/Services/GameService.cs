using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using ReactiveUI;

namespace GourmetGame.App.Services;

public class Node
{
    public string Food { get; set; }
    public Node? Positive { get;set; }
    public Node? Negative {get;set;}

    public Node(string food, Node? positive, Node? negative)
    {
        Food = food;
        Positive = positive;
        Negative = negative;
    }
}

public class GameService
{
    public List<Node> NodeList { get; set; }
    public Node CurrentNode { get; set; } 

    public GameService()
    {
        NodeList = [
            new Node("Massa", new Node("Lasanha", null, null), new Node("Bolo de Chocolate", null, null))
        ];
        CurrentNode = NodeList[0];
    }

    public Node? Guess(bool Answer)
    {
        Node? NextNode = Answer ? CurrentNode.Positive : CurrentNode.Negative;
        if(NextNode != null) CurrentNode = NextNode;
        return NextNode;
    }

    public void AddFood(string foodName, string negativePremise)
    {
        Node PositivePremise = new(foodName, null, null);
        Node NegativePremise = new(negativePremise, PositivePremise, null);

        CurrentNode.Negative = NegativePremise;
    }

    public void Restart()
    {
        CurrentNode = NodeList[0];
    }
}