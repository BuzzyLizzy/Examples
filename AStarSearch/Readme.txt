Explanation of Implementation for the A* Algorithm Task
=======================================================

--------------------------------------------------
Definition of A* algorithm for this specified case
--------------------------------------------------
The A* algorithm finds the least-cost path from a given node to a given goal node by building a tree of partial paths of which the leaves each receive a cost using a cost function F(n) = G(n) + H(n), where:
H(n) - A heuristic estimate of the cost to reach the goal. In this case it is specified that this shall be the Manhattan distance: |x1 – x2| + |y1-y2|. 
G(n) - The cost to get to the node. In this case it is specified that this shall be the weight of the type of node as given: 1=Flatlands, 2=Forest, 3=Mountain 

Outline of the implementation
1. Add the Starting Node to the Priority Queue (this is list ordered per cost F with lowest cost at top/front). The Starting Node’s Cost shall be 0.
2. Repeat the following:
      a. Get the first node in the Priority Queue
      b. Mark this node as already walked by setting its “Walked” status (Note: In some implementations this can be moved to a Closed Queue at this point, but I do not see the need in this simple implementation, the Map Node class shall have an additional field to indicate that it has been “walked”. The caveat here is that before another path search can be done on the same map, the Walked status of all the nodes of the map must be re-set to “Not Walked”. By not using a Closed Queue that has to be searched each time to find if a node was added to it, but directly accessing a node’s “Walked” status, which shall be a field in the node class, will make the execution faster.)
      c. For each of the 8 Neighbour Nodes of this node:
            * If it is not walkable; i.e. it is a Water node or it is flagged as Walked, then ignore it, else do one of the following:
                  i. If it is not yet on the Priority Queue: Add it to the Priority Queue and calculate its F, G, H costs.
                  ii. If it is on the Priority Queue: Check if the cost G to this Neighbour Node via this node is better than the Neighbour Node’s current G cost, if it is then change the Parent Node of the Neighbour Node to this node and re-calculate the costs, else do nothing. (The Priority Queue may need to be re-sorted)
3. Stop when:
      a. Marked the Goal Node as Walked, in which case a path was found.
      b. The Priority Queue is empty and the Goal Node was not found, in which case no path to the Goal Node was found.
4. Build the path from Goal Node backwards using each node’s Parent Node.


----------------------------------------------------
Decisions regarding ambiguouty in the task statement
----------------------------------------------------
I was somewhat confused by the task statement and the example map and path provided.
I will try to explain.
By using the Manhattan distance as the heuristic it implies movement shall only be done horizontally and vertically and not diagonally, and yet the example provided shows diagonal movement being used.

If diagonal movement is allowed then the shortest possible path will be diagonal straight to the goal, which is the Euclidian distance but in a 2D vector the Chebyshev distance can better represent this heuristic, and it is a rather shorter distance than the Manhattan distance, therefore the heuristic of the Manhattan distance for diagonal movement shall over-estimate the path and the algorithm may not behave as expected. For example if we use a map of 50x50 and use the indices starting from 0 to calculate distances, then the Manhattan distance from the top left position (0, 0) to the bottom right (49, 49) will be |x1-x2| + |y1-y2| = |0-49| + |0-49| = 98;
where the Chebyshev distance (diagonal straight line) shall be max(|x2-x1|,|y2-y1|) = 49. To find the shortest path for diagonal movement it will be recommended to use the Chebyshev distance.

Imagine that the points are the squares on a chess board and you can move diagonally, vertically and horizontally. Then, you could take any path from one square to the other. The shortest route to any other point will be a combination of vertical, diagonal and horizontal moves such that the line to the goal is as straight as possible; It is also known as chessboard distance, since in the game of chess the minimum number of moves needed by a king to go from one square on a chessboard to another equals the Chebyshev distance between the centers of the squares, if the squares have side length one, as represented in 2-D spatial coordinates with axes aligned to the edges of the board.

Now imagine that you are in a city, and each point is a building. You can't walk over a building, so the only options are to go either up/down or left/right. Then, the shortest distance is given by the sum of the components of the difference vector; which is the mathematical way of saying that "go down 2 blocks and then one block to the left" means walking 3 blocks' distance: dist = abs(x2-x1) + abs(y2-y1). This is known as the Manhattan distance between the points.

Because of this I added options on the form where one can select whether diagonal movement is allowed or not.
If the diagonal movement option is selected, then a further option can be selected to use the Manhattan or Chebyshev distances.

------------------------------------------
Pseudo code of implementation to find path
------------------------------------------

Find Start Node
Set Start Node cost to 0 (zero)
Set Start Node Parent Node to Null
Place Start Node on Priority Queue

While there are nodes on the Priority Queue And Path Not Found
{
  With First Node on Priority Queue Do
  {
  	If this node is the Goal Node
  	{
        // We have found our path
        Set Path Found to True
  	}
  	Else
  	{
      Mark this node as WasWalked
      Remove this node from Priority Queue
  
      For each walkable Neighbour Nodes of Node Do
      // Walkable neighbours are those that are indicated as walkable and those not yet walked.
      {
        Calculate G, H, F costs (F = G + H)
        If Neighbour Node already on Priority Queue
        {
          If Neighbour Node on Queue’s cost G via this node is less than its current cost G 
          // if we were to take path through the parent node or not
          {
            Set Neighbour Node on Queue’s parent to this Node
            Re-calculate the Neighbour Node on Queue’s cost
          }
          Else
          {
            Set this node as its Parent Node
            Add Neighbour node to Priority Queue
          }
  	    }
      }
    }
  }
}

If Path was Found
{
	Build the path from the Goal Node back to the Start Node using the Parent Node of each Node. 
       // The Start Node’s Parent Node shall be Null.
}
Else
{
	Set Path to empty
}

Return Path

-------------------------------------
Notes on the actual C# implementation
-------------------------------------
Since no constraints regarding memory were specified I simply read the 2D map into a 2D array. In order to do this I used the map file’s number of lines as the height and the number of characters in the first line as the width.

Further the Priority Queue is implemented as a C# List<> and I added a QuickSort to sort it with lowest cost at the top.

A Debug Output trace can be generated by ticking the box on the Form if you want to get details on what the Priority Queue looks like after each iteration. Note that it will be slightly slower if this option is activated.


----------------------
To run the application
----------------------
Simply compile and run.
Specify the directory and file where the map is located on the form as indicated and give the map output file name (no need for the path as it will extract the path from the original file and save it to the same directory).

