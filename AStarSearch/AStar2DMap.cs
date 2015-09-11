using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace AStarSearch
{
    //=============================================================================================
    // AStar2DMapNode
    //=============================================================================================
    public class AStar2DMapNode
    {
        public enum MapNodeType
        {
            Water,      // 0 - Not walkable
            Flatlands,  // 1 = Cost for Flatlands
            Forest,     // 2 = Cost for Forest
            Mountain,   // 3 = Cost for Mountain
            Unspecified // 4 - Not walkable
        }

        //-----------------------------------------------------------------------------------------
        // Default Constructor
        public AStar2DMapNode()
        {
            this.NodeType    = MapNodeType.Unspecified;
            this.Cost        = 0;
            this.CostG       = 0;
            this.CostH       = 0;
            this.WasWalked   = false;
            this.Coordinates = new Point(-1, -1);
            this.Character   = ' ';
        }

        //-----------------------------------------------------------------------------------------
        // Constructor with co-ordinates and character given
        public AStar2DMapNode(int x, int y, char c)
        {
            this.NodeType    = MapNodeType.Unspecified;
            this.Cost        = 0;
            this.CostG       = 0;
            this.CostH       = 0;
            this.WasWalked   = false;
            this.Coordinates = new Point(x, y);
            this.Character   = c;
        }

        //-----------------------------------------------------------------------------------------
        // Copy Constructor
        public AStar2DMapNode(AStar2DMapNode other)
        {
            this.NodeType    = other.NodeType;   
            this.Cost        = other.Cost;       
            this.CostG       = other.CostG;      
            this.CostH       = other.CostH;      
            this.WasWalked   = other.WasWalked;
            this.Coordinates = other.Coordinates;
            this.Character   = other.Character;
        }

        //=========================================================================================
        #region Public Functions

        //-----------------------------------------------------------------------------------------
        // To find out if a node is equal to another it is enough to check the node type, coordinates and character.
        public bool Equals(AStar2DMapNode other)
        {
            bool isEqual = false;

            if (this.NodeType == other.NodeType &&
                this.Coordinates == other.Coordinates &&
                this.Character == other.Character)
            {
                isEqual = true;
            }

            return isEqual;
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Converts the given character to a node type
        /// </summary>
        /// <param name="c"></param>
        /// <returns>MapNodeType corresponding to the given character</returns>
        public static MapNodeType GetMapNodeTypeFromChar(char c)
        {
            MapNodeType mapNodeType = MapNodeType.Unspecified;

            switch (c)
            {
                case '~':
                    mapNodeType = MapNodeType.Water;
                    break;
                case '.':
                case '@':
                case 'X':
                    mapNodeType = MapNodeType.Flatlands;
                    break;
                case '*':
                    mapNodeType = MapNodeType.Forest;
                    break;
                case '^':
                    mapNodeType = MapNodeType.Mountain;
                    break;
                default:
                    mapNodeType = MapNodeType.Unspecified;
                    break;
            }

            return mapNodeType;
        }

        #endregion Public Functions

        //=========================================================================================
        #region Properties

        public MapNodeType NodeType { get; set; }

        /// <summary>
        /// The node's Cost as given by the task specification as:
        /// 1=Flatlands, 2=Forest, 3=Mountain
        /// </summary>
        public int Cost { get; set; }

        /// <summary>
        /// The Calculated cost G of this node, this shall be the sum of the Cost all its parents plus its
        /// own Cost.
        /// </summary>
        public int CostG { get; set; }

        /// <summary>
        /// The heuristic Cost of this node
        /// </summary>
        public int CostH { get; set; }

        /// <summary>
        /// Indicates whether node has been walked.
        /// </summary>
        public bool WasWalked { get; set; }

        /// <summary>
        /// The x, y co-ordinates of the node within the map. Use the System.Drawing Point structure for this.
        /// </summary>
        public Point Coordinates { get; set; }

        /// <summary>
        /// The character that represents this node on the map
        /// </summary>
        public char Character { get; set; }

        /// <summary>
        /// Is this node walkable? It is not walkable if it has already been walked and it is not walkable
        /// if it is not a Flatland, Forest or Mountain.
        /// </summary>
        public bool IsWalkable
        {
            get
            {
                return (!this.WasWalked &&
                         (this.NodeType > MapNodeType.Water && this.NodeType < MapNodeType.Unspecified));
            }
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Return the CostF = CostG + CostH
        /// </summary>
        public int CostF
        {
            get
            {
                return (this.CostG + this.CostH);
            }
        }

        #endregion Properties

    }

    //=============================================================================================
    // AStar2DMapNodeWater
    //=============================================================================================
    public class AStar2DMapNodeWater : AStar2DMapNode
    {
        //-----------------------------------------------------------------------------------------
        // Default Constructor
        public AStar2DMapNodeWater() 
            : base()
        {
            this.NodeType = MapNodeType.Water;
            this.Cost = Convert.ToInt32(MapNodeType.Water); // Node type doubles as cost value
        }

        //-----------------------------------------------------------------------------------------
        // Constructor with co-ordinates and character given
        public AStar2DMapNodeWater(int x, int y, char c)
            : base(x, y, c)
        {
            this.NodeType = MapNodeType.Water;
            this.Cost = Convert.ToInt32(MapNodeType.Water); // Node type doubles as cost value
        }

    }

    //=============================================================================================
    // AStar2DMapNodeFlatlands
    //=============================================================================================
    public class AStar2DMapNodeFlatlands : AStar2DMapNode
    {
        //-----------------------------------------------------------------------------------------
        // Default Constructor
        public AStar2DMapNodeFlatlands() 
            : base()
        {
            this.NodeType = MapNodeType.Flatlands;
            this.Cost = Convert.ToInt32(MapNodeType.Flatlands); // Node type doubles as cost value
        }

        //-----------------------------------------------------------------------------------------
        // Constructor with co-ordinates and character given
        public AStar2DMapNodeFlatlands(int x, int y, char c)
            : base(x, y, c)
        {
            this.NodeType = MapNodeType.Flatlands;
            this.Cost = Convert.ToInt32(MapNodeType.Flatlands); // Node type doubles as cost value
        }
    }

    //=============================================================================================
    // AStar2DMapNodeForest
    //=============================================================================================
    public class AStar2DMapNodeForest : AStar2DMapNode
    {
        //-----------------------------------------------------------------------------------------
        // Default Constructor
        public AStar2DMapNodeForest() 
            : base()
        {
            this.NodeType = MapNodeType.Forest;
            this.Cost = Convert.ToInt32(MapNodeType.Forest); // Node type doubles as cost value
        }

        //-----------------------------------------------------------------------------------------
        // Constructor with co-ordinates and character given
        public AStar2DMapNodeForest(int x, int y, char c)
            : base(x, y, c)
        {
            this.NodeType = MapNodeType.Forest;
            this.Cost = Convert.ToInt32(MapNodeType.Forest); // Node type doubles as cost value
        }
    }

    //=============================================================================================
    // AStar2DMapNodeMountain
    //=============================================================================================
    public class AStar2DMapNodeMountain : AStar2DMapNode
    {
        //-----------------------------------------------------------------------------------------
        // Default Constructor
        public AStar2DMapNodeMountain() 
            : base()
        {
            this.NodeType = MapNodeType.Mountain;
            this.Cost = Convert.ToInt32(MapNodeType.Mountain); // Node type doubles as cost value
        }

        //-----------------------------------------------------------------------------------------
        // Constructor with co-ordinates and character given
        public AStar2DMapNodeMountain(int x, int y, char c)
            : base(x, y, c)
        {
            this.NodeType = MapNodeType.Mountain;
            this.Cost = Convert.ToInt32(MapNodeType.Mountain); // Node type doubles as cost value
        }
    }

    //=============================================================================================
    // AStar2DMap
    // Load the given text file into a 2D Map representation.
    //=============================================================================================
    public class AStar2DMap
    {

        //=========================================================================================
        #region Public Functions

        /// <summary>
        /// Load the 2D Map from the given file. File name must include full path.
        /// </summary>
        /// <param name="fileName">THe full path and file name containing the map</param>
        /// <returns>Returns true if map was loaded successfully, else returns false.</returns>
        public bool LoadMap(string fileName)
        {
            bool allOK = true;

            // Read the lines of the file into memory. 
            // NOTE!!!
            // This is probably not the most efficient thing to do,
            // but we need the number of characters per line as well as the number of lines to determine the
            // dimensions of the map as it is unknown. There may be a memory constraint here with large map
            // files, but as this was not specified for this task I am not going to be too concerned at this
            // point and will read the file into memory.
            string[] lines = null;

            if (File.Exists(fileName))
            {
                try
                {
                    lines = File.ReadAllLines(fileName);
                }
                catch
                {
                    allOK = false;
                }
            }
            else
            {
                allOK = false;
            }

            if (allOK)
            {
                this._mapHeight = 0;
                this._mapWidth = 0;

                if (lines != null)
                {
                    this._mapHeight = lines.Count();

                    if (lines.Count() > 0)
                    {
                        // Check if last line is empty line
                        if (String.IsNullOrEmpty(lines[lines.Count() - 1]))
                        {
                            this._mapHeight = lines.Count() - 1;
                        }

                        this._mapWidth = lines[0].Length;

                        this._mapNodes = new AStar2DMapNode[this._mapWidth, this._mapHeight];
                        this._startNode = null;
                        this._goalNode = null;

                        for (int y = 0; y < this._mapHeight; y++)
                        {
                            for (int x = 0; x < this._mapWidth; x++)
                            {
                                // The first line was used to determine the map width, check if subsequent lines
                                // has less characters in which case the for loop for x value must be stopped.
                                if ( x < lines[y].Length)
                                {
                                    char c = lines[y][x];

                                    switch (AStar2DMapNode.GetMapNodeTypeFromChar(c))
                                    {
                                        case AStar2DMapNode.MapNodeType.Water:
                                            this._mapNodes[x, y] = new AStar2DMapNodeWater(x, y, c);
                                            break;
                                        case AStar2DMapNode.MapNodeType.Flatlands:
                                            this._mapNodes[x, y] = new AStar2DMapNodeFlatlands(x, y, c);
                                            if (c == '@') this._startNode = this._mapNodes[x, y];
                                            else if (c == 'X') this._goalNode = this._mapNodes[x, y];
                                            break;
                                        case AStar2DMapNode.MapNodeType.Forest:
                                            this._mapNodes[x, y] = new AStar2DMapNodeForest(x, y, c);
                                            break;
                                        case AStar2DMapNode.MapNodeType.Mountain:
                                            this._mapNodes[x, y] = new AStar2DMapNodeMountain(x, y, c);
                                            break;
                                        default:
                                            // Unspecified node type
                                            this._mapNodes[x, y] = new AStar2DMapNode(x, y, c);
                                            break;
                                    }
                                }
                                else
                                {
                                    // This line has less characters than the specified map width.
                                    // Fill the remainder with unspecified nodes
                                    for (int i = x; i < this._mapWidth; i++)
                                    {
                                        this._mapNodes[x, y] = new AStar2DMapNode(x, y, ' ');
                                    }
                                }
                            }
                        }

                        if (this._startNode == null || this._goalNode == null)
                        {
                            // Could not find Start and / or Goal node, something went wrong
                            allOK = false;
                        }
                    }
                    else
                    {
                        allOK = false;
                    }
                }
            }

            return allOK;
        }
        
        /// <summary>
        /// Write the map to the given file
        /// </summary>
        /// <param name="fileName">THe full path and name of the file to write the map to</param>
        /// <returns></returns>
        public bool WriteMap(string fileName)
        {
            bool allOK = true;
            StringBuilder lineBuilder = new StringBuilder();

            try
            {
                using (StreamWriter outfile = new StreamWriter(fileName))
                {
                    for (int y = 0; y < this._mapHeight; y++)
                    {
                        lineBuilder.Clear();
                        for (int x = 0; x < this._mapWidth; x++)
                        {
                            lineBuilder.Append(this._mapNodes[x, y].Character);
                        }
                        outfile.WriteLine(lineBuilder);
                    }
                }
            }
            catch
            {
                allOK = false;
            }

            return allOK;
        }

        /// <summary>
        /// Returns the node at the given co-ordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public AStar2DMapNode NodeAt(int x, int y)
        {
            return this._mapNodes[x, y];
        }

        #endregion Public Functions


        //=========================================================================================
        #region Properties

        public AStar2DMapNode StartNode
        {
            get { return this._startNode; }
        }

        public AStar2DMapNode GoalNode
        {
            get { return this._goalNode; }
        }

        public int Width
        {
            get { return this._mapWidth; }
        }

        public int Height
        {
            get { return this._mapHeight; }
        }

        #endregion Properties


        //=========================================================================================
        #region Private Members

        // 2D array of map nodes represents the map
        int _mapHeight = 0;
        int _mapWidth = 0;

        private AStar2DMapNode[,] _mapNodes = null;
        private AStar2DMapNode _startNode = null;
        private AStar2DMapNode _goalNode = null;

        #endregion Private Members
    }
}
