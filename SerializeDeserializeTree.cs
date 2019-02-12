using System;
using System.Text;

namespace InterviewPrep {
  public class MainClass {
    public static void Main(string[] args) {
      //Create Tree
      Tree<int> tree = new Tree<int> { Data = 20 };
      tree.Left = new Tree<int> { Data = 15 };
      tree.Right = new Tree<int> { Data = 25 };
      tree.Left.Left = new Tree<int> { Data = 13 };
      tree.Left.Right = new Tree<int> { Data = 16 };
      tree.Right.Right = new Tree<int> { Data = 45 };

      //Serialize
      StringBuilder builder = new StringBuilder();
      Serialize(tree, builder);

      //Print what we serialized
      Console.WriteLine("Serialized String: " + builder);

      //Deserialize 
      string[] splits = builder.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      int index = 0;
      Tree<int> deserializedTree = Deserialize(splits, ref index);
    }

    public static void Serialize(Tree<int> node, StringBuilder builder) {
      if (node == null) {
        builder.Append("n,");
      }
      else {
        builder.Append(node.Data + ",");
        Serialize(node.Left, builder);
        Serialize(node.Right, builder);
      }
    }
    
    private static Tree<int> Deserialize(string[] nodeStringStack, ref int index) {
      if (index >= nodeStringStack.Length) {
        return null;
      }

      string val = nodeStringStack[index];
      index++;

      if (val.Equals("n")) {
        return null;
      }

      Tree<int> root = new Tree<int> { Data = int.Parse(val) };
      root.Left = Deserialize(nodeStringStack, ref index);
      root.Right = Deserialize(nodeStringStack, ref index);

      return root;
    }

    public class Tree<T> {
      public T Data;
      public Tree<T> Left;
      public Tree<T> Right;
    }
  }
}
