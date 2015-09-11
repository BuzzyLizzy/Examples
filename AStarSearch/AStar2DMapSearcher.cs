using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace AStarSearch
{

    //=============================================================================================
    // AStarQueueNode
    //=============================================================================================
    public class AStarPriorityQueueNode : IComparable<AStarPriorityQueueNode>, IEquatable<AStarPriorityQueueNode>
    {
        public AStar2DMapNode MapNode { get; set; }
        public AStarPriorityQueueNode ParentQueueNode { get; set; }

        //-----------------------------------------------------------------------------------------
        public int CompareTo(AStarPriorityQueueNode other)
        {
            int val = 0;

            if (other == null)
            {
                // If other is nothing then this one precedes it.
                val = -1;
            }
            else
            {
                if (this.MapNode.CostF < other.MapNode.CostF)
                {
                    val = -1;
                }
                else if (this.MapNode.CostF > other.MapNode.CostF)
                {
                    val = 1;
                }
                else if (this.MapNode.CostF == other.MapNode.CostF)
                {
                    val = 0;
                }
            }

            return val;
        }

        //-----------------------------------------------------------------------------------------
        public bool Equals(AStarPriorityQueueNode other)
        {
            bool isEqual = false;

            if (this.MapNode.Equals(other.MapNode))
            {
                isEqual = true;
            }

            return isEqual;
        }

        //-----------------------------------------------------------------------------------------
        public override string ToString()
        {
            string s =
                "[" + MapNode.Character +
                " (" + MapNode.Coordinates.X.ToString() + "," + MapNode.Coordinates.Y.ToString() +
                " C=" + MapNode.Cost + "; G=" + MapNode.CostG + "; H=" + MapNode.CostH + "; F=" + MapNode.CostF.ToString();

            s += "; Parent[";

            if (ParentQueueNode != null)
            {
                s +=
                    ParentQueueNode.MapNode.Character +
                    " (" + ParentQueueNode.MapNode.Coordinates.X.ToString() +
                    "," + ParentQueueNode.MapNode.Coordinates.Y.ToString() + ")]";
            }
            else
            {
                s += "null]";
            }

            s += "]";

            return s;
        }
    }

    //=============================================================================================
    // AStar2DMapSearcher
    //=============================================================================================
    public class AStar2DMapSearcher
    {
        private List<AStarPriorityQueueNode> _priorityQueue = null;
        private bool _generateDebugOutputFile = false;
        private bool _allowDiagonalMovement = false;
        // If not using EUclidian distance as heuristic then use Manhattan distance.
        private bool _useChebyshevDistanceHeuristic = false;

        //-----------------------------------------------------------------------------------------
        // Constructor
        public AStar2DMapSearcher(bool allowDiagonalMovement = false, 
                                  bool useChebyshevDistanceHeuristic = false, 
                                  bool generateDebugOutputFile = false)
        {
            this._priorityQueue = new List<AStarPriorityQueueNode>();
            this._generateDebugOutputFile = generateDebugOutputFile;
            this._allowDiagonalMovement = allowDiagonalMovement;
            this._useChebyshevDistanceHeuristic = useChebyshevDistanceHeuristic;
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Searches the given 2D Map for the optimal path using A# algorithm:
        /// The A* algorithm finds the least-cost path from a given node to a given goal node by building a tree of 
        /// partial paths of which the leaves each receive a cost using a cost function F(n) = G(n) + H(n), where:
        ///     H(n) - A heuristic estimate of the cost to reach the goal. 
        ///            This can be chosen to be the Manhattan distance: |x1 – x2| + |y1-y2| 
        ///            Or Chebyshev distance if diagonal movement is allowed. 
        ///     G(n) - The cost to get to the node. In this case it is specified that this shall be the weight of the type of node as given: 1=Flatlands, 2=Forest, 3=Mountain
        /// </summary>
        /// <param name="mapSourceFile">The full path and file name of the source file for the 2D map</param>
        /// <param name="mapPathDestinationFile">The full path and file name of the file that will contain the resulting path found</param>
        /// <returns>Returns true is the path could be determined successfully, else returns false</returns>
        public bool SearchPath(string mapSourceFile, string mapPathDestinationFile, out AStarPriorityQueueNode goalNode)
        {
            bool allOK = true;
            bool writeDebugOutput = false;
            StreamWriter outfile = null;
            goalNode = null;

            // If flag set to generate Debug Output File, then open the file now.
            if (this._generateDebugOutputFile)
            {
                try
                {
                    outfile = new StreamWriter("debug_output.txt");
                    writeDebugOutput = true;
                }
                catch
                {
                    writeDebugOutput = false;
                }
            }

            AStar2DMap map = new AStar2DMap();

            if (map.LoadMap(mapSourceFile))
            {
                // Find Start Node
                // Set Start Node Cost to 0
                // Set Start Node Parent to null
                AStarPriorityQueueNode startNode = new AStarPriorityQueueNode();
                startNode.MapNode = map.StartNode;
                startNode.MapNode.CostG = 0;
                startNode.MapNode.CostH = 0;
                startNode.ParentQueueNode = null;

                // Place Start Node on Priority Queue
                this._priorityQueue.Add(startNode);

                // While there are nodes on the Priority Queue And Path Not Found Do
                bool pathFound = false;

                while (this._priorityQueue.Count() > 0 && !pathFound)
                {
                    if (writeDebugOutput && outfile != null)
                    {
                        // Write the Priority Queue to the Debug Output file.
                        int i = 1;
                        outfile.WriteLine(i.ToString() + " ---------------------------------------------------------------------------------");
                        string s = "";
                        for (int p = 0; p < this._priorityQueue.Count; p++)
                        {
                            string line = string.Format("{0}\n", this._priorityQueue[p].ToString());
                            s += line;
                        }
                        s += "count = " + this._priorityQueue.Count;
                        outfile.WriteLine(s);
                        i++;
                    }

                    // With Front Node on Priority Queue Do
                    // Remove it from front of queue
                    AStarPriorityQueueNode frontNode = this._priorityQueue[0];
                    this._priorityQueue.RemoveAt(0);

                    // Mark Front Node as WasWalked
                    frontNode.MapNode.WasWalked = true;

                    if (writeDebugOutput && outfile != null)
                    {
                        outfile.WriteLine("");
                        outfile.WriteLine("Front Node: " + frontNode.ToString());
                    }

                    // If this node is the Goal Node we have found path, stop.
                    if (frontNode.MapNode.Equals(map.GoalNode))
                    {
                        pathFound = true;
                        goalNode = frontNode;
                    }
                    else
                    {
                        // Build a list of neighbour nodes
                        List<AStarPriorityQueueNode> neighbourNodes = GetNeighbourNodesList(map, frontNode);

                        // Find all walkable Neighbour Nodes of Node and with each Do
                        // Walkable neighbours are those that are indicated as walkable and those not yet walked.
                        foreach (AStarPriorityQueueNode neighbourNode in neighbourNodes)
                        {
                            if (neighbourNode.MapNode.IsWalkable)
                            {
                                // Calculate G, H, F costs (F = G + H)
                                int costG = frontNode.MapNode.CostG + neighbourNode.MapNode.Cost;
                                int costH = 0;

                                if (this._useChebyshevDistanceHeuristic)
                                {
                                    costH = ChebyshevDistance(neighbourNode.MapNode.Coordinates, map.GoalNode.Coordinates);
                                }
                                else
                                {
                                    costH = ManhattanDistance(neighbourNode.MapNode.Coordinates, map.GoalNode.Coordinates);
                                }

                                if (writeDebugOutput && outfile != null)
                                {
                                    outfile.WriteLine("");
                                    outfile.WriteLine("Walkable Neighbour:");
                                    outfile.WriteLine(neighbourNode.ToString());
                                }

                                // If Neighbour Node already on Priority Queue
                                AStarPriorityQueueNode nodeOnQueue = this._priorityQueue.Find(x => x.Equals(neighbourNode));
                                if (nodeOnQueue != null)
                                {
                                    if (writeDebugOutput && outfile != null)
                                    {
                                        outfile.WriteLine("Neighbour already on Queue");
                                    }

                                    // Neighbour node is already on queue
                                    // If cost G of the Neighbour Node on the Queue via this node is less than its current cost G
                                    // then make this node its parent and update its cost G.
                                    // (as if it was to go via this node)
                                    if (costG < nodeOnQueue.MapNode.CostG)
                                    {
                                        if (writeDebugOutput && outfile != null)
                                        {
                                            outfile.WriteLine("Set Neighbour parent to this node");
                                        }

                                        // Set Neighbour Node parent to this Node
                                        nodeOnQueue.ParentQueueNode = frontNode;
                                        nodeOnQueue.MapNode.CostG = frontNode.MapNode.CostG + nodeOnQueue.MapNode.Cost;
                                    }
                                }
                                else
                                {
                                    // Set this node as its Parent Node
                                    neighbourNode.ParentQueueNode = frontNode;

                                    neighbourNode.MapNode.CostG = costG;
                                    neighbourNode.MapNode.CostH = costH;

                                    if (writeDebugOutput && outfile != null)
                                    {
                                        outfile.WriteLine("Enqueue Neighbour Node");
                                    }

                                    // Add Neighbour node to Priority Queue
                                    this._priorityQueue.Add(neighbourNode);
                                    // Sort Priority Queue
                                    QuickSort(this._priorityQueue, 0, this._priorityQueue.Count() - 1);

                                }
                            }
                        }
                    }
                }

                if (pathFound)
                {
                    // Path was found
                    // Generate the result map

                    // Set the characters of the path nodes in the map to '#'
                    AStarPriorityQueueNode currentNode = goalNode;
                    while (currentNode != null)
                    {
                        if (currentNode.MapNode.WasWalked == true)
                        {
                            currentNode.MapNode.Character = '#';
                            currentNode = currentNode.ParentQueueNode;
                        }
                        map.WriteMap(mapPathDestinationFile);
                    }
                }
                else
                {
                    // No path found
                    allOK = false;
                }
            }
            else
            {
                // Could not read map
                allOK = false;
            }

            if (writeDebugOutput && outfile != null)
            {
                // Close the file
                outfile.Close();
            }

            return allOK;
        }

        //-----------------------------------------------------------------------------------------
        private List<AStarPriorityQueueNode> GetNeighbourNodesList(AStar2DMap map, AStarPriorityQueueNode node)
        {
            List<AStarPriorityQueueNode> neighbourNodes = new List<AStarPriorityQueueNode>();
            int neighbourY = 0;
            int neighbourX = 0;

            // If we can move diagonal then there are 8 possible neighbours, else only 4.
            if (this._allowDiagonalMovement)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        if (y == 0 && x == 0)
                        {
                            // This is the current node, skip
                        }
                        else
                        {
                            neighbourY = node.MapNode.Coordinates.Y + y;
                            if (neighbourY >= 0 && neighbourY < map.Height)
                            {
                                neighbourX = node.MapNode.Coordinates.X + x;
                                if (neighbourX >= 0 && neighbourX < map.Width)
                                {
                                    AStarPriorityQueueNode neighbourNode = new AStarPriorityQueueNode();
                                    neighbourNode.MapNode = map.NodeAt(neighbourX, neighbourY);
                                    neighbourNodes.Add(neighbourNode);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // There are only 4 nodes: (x, y-1), (x, y+1), (x-1, y), (x+1, y)
                if (node.MapNode.Coordinates.Y > 0)
                {
                    AStarPriorityQueueNode neighbourNode1 = new AStarPriorityQueueNode();
                    neighbourNode1.MapNode = map.NodeAt(node.MapNode.Coordinates.X, node.MapNode.Coordinates.Y - 1);
                    neighbourNodes.Add(neighbourNode1);
                }
                if (node.MapNode.Coordinates.Y < map.Height-1)
                {
                    AStarPriorityQueueNode neighbourNode2 = new AStarPriorityQueueNode();
                    neighbourNode2.MapNode = map.NodeAt(node.MapNode.Coordinates.X, node.MapNode.Coordinates.Y + 1);
                    neighbourNodes.Add(neighbourNode2);
                }
                if (node.MapNode.Coordinates.X < map.Width - 1)
                {
                    AStarPriorityQueueNode neighbourNode3 = new AStarPriorityQueueNode();
                    neighbourNode3.MapNode = map.NodeAt(node.MapNode.Coordinates.X + 1, node.MapNode.Coordinates.Y);
                    neighbourNodes.Add(neighbourNode3);
                }
                if (node.MapNode.Coordinates.X > 0)
                {
                    AStarPriorityQueueNode neighbourNode4 = new AStarPriorityQueueNode();
                    neighbourNode4.MapNode = map.NodeAt(node.MapNode.Coordinates.X - 1, node.MapNode.Coordinates.Y);
                    neighbourNodes.Add(neighbourNode4);
                }
            }

            return neighbourNodes;
        }

        //-----------------------------------------------------------------------------------------
        // Simple Quick sort recursive implementation.
        private void QuickSort(List<AStarPriorityQueueNode> A, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = Partition(A, lo, hi);
                QuickSort(A, lo, p - 1);
                QuickSort(A, p + 1, hi);
            }
        }

        //-----------------------------------------------------------------------------------------
        private int Partition(List<AStarPriorityQueueNode> A, int lo, int hi)
        {
            AStarPriorityQueueNode pivot = A[hi];
            AStarPriorityQueueNode tempA = null;
            int i = lo;
            for (int j = lo; j < hi; j++)
            {
                if (A[j].CompareTo(pivot) < 0)
                {
                    tempA = A[i];
                    A[i] = A[j];
                    A[j] = tempA;
                    i++;
                }
            }
            tempA = A[i];
            A[i] = A[hi];
            A[hi] = tempA;

            return i;
        }

        //-----------------------------------------------------------------------------------------
        private int ManhattanDistance(Point point1, Point point2)
        {
            return (Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y));
        }

        //-----------------------------------------------------------------------------------------
        private int ChebyshevDistance(Point point1, Point point2)
        {
            return Convert.ToInt32(Math.Max(Math.Abs(point2.X - point1.X), Math.Abs(point2.Y - point1.Y)));
        }
    }
}
