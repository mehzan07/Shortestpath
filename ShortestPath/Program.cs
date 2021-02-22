using System;
using System.Linq;

/// <summary>
/// Problem descripton: given a string as following:
/// 4,A,B,C,D,A-B,B-D,B-C,C-D
/// the first is a number: number of nodes
/// the for followins strings are the nodes
/// the last four strings are linen betweens the node.
/// your challenge is to find shourtes path from the first node to the las node with regard of connection line betweens the nodes.
/// in  this cas it shall be A-B-D.
/// </summary>

class MainClass
{
    static void Main()
    {
        // if you want to test to give direct a path:
        // string[] strarr = { "4","A","B","C","D","A-B","B-D","B-C","C-D" };
        // an example of path: 4,A,B,C,D,A-B,B-D,B-C,C-D
        Console.WriteLine("Please give string of a path: as example:4, A, B, C, D, A-B, B-D, B-C, C-D ");
        string str = Console.ReadLine();
        Console.WriteLine("Input string for paht is:" +str);
        string[] strarr = str.Split(',').ToArray();

        Console.WriteLine("Shortest path shall be:");

        Console.WriteLine(ShortestPath(strarr));
    }

    public static string ShortestPath(string[] strArr)
    {
        // code goes here  
        string spath = string.Empty;
        // find number of nodes
        int NrOfNodes = Int32.Parse(strArr[0]);
        string firstNode = strArr[1];
        string lastNode = strArr[NrOfNodes];
        int len = strArr.Length;
        // get lines
        string[] conlines = new string[len - NrOfNodes-1];

        // get connection lines string
        for(int i=0; i<len; i++)
        {
            if (i > NrOfNodes)
                conlines[i - NrOfNodes-1] = strArr[i];
        }
        // find connetion from FirstNode to LastNode
       for (int j = 0; j < len - NrOfNodes-1; j++)
            {
            if (conlines[j].Contains(firstNode + "-" + lastNode))
            {
                spath += conlines[j]; // find the short path
                return spath;
            }
            else if(conlines[j].Contains(firstNode + "-"))
            {
                spath = conlines[j]; //first find of firstNode
                                     //find next node i the spath (find substring after "-"
                int index = spath.IndexOf("-");
                string nextNode = spath.Substring(index+1); // have find next node
                firstNode = nextNode;
                //remove nextNode from the spath
                spath = spath.Remove(spath.Length - 1);

            }
        }

            return spath;
    }
}
