using System.Collections.Generic;

namespace GourmetGame.App.Services;

public class Node(string food, Node? positive = null, Node? negative = null)
{
    public string Food { get; set; } = food;
    public Node? Positive { get; set; } = positive;
    public Node? Negative { get; set; } = negative;
}

public class GameService
{
    public List<Node> NodeList { get; set; }
    public Node CurrentNode { get; set; } 

    public GameService()
    {
        NodeList = InitializeNodeList();
        CurrentNode = NodeList[0];
    }

    public static List<Node> InitializeNodeList()
    {
        return [
            new Node("Massa", new Node("Lasanha"), new Node("Bolo de Chocolate"))
        ];
    }

    public Node? Guess(bool Answer)
    {
        Node? NextNode = Answer ? CurrentNode.Positive : CurrentNode.Negative;
        if(NextNode != null) CurrentNode = NextNode;
        return NextNode;
    }

    public void AddFood(string foodName, string negativePremise)
    {
        Node newFoodNode = new(foodName);
        Node negativeNode = new(negativePremise, newFoodNode, null);
        CurrentNode.Negative = negativeNode;
    }

    public void Restart()
    {
        CurrentNode = NodeList[0];
    }
}