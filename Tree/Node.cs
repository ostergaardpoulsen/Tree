using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
public class Node
  {
    private List<Node> _children;

    public Node(int data, params Node[] nodes)
    {
      Data = data;
      AddRange(nodes);
    }

    public Node Parent { get; set; }

    public IEnumerable<Node> Children
    {
      get
      {
        return _children != null
        ? _children
        : Enumerable.Empty<Node>();
      }
    }

    public int Data { get; private set; }

    public void Add(Node node)
    {
      //Tænker den skal omskrives i "produktionskode"
      //if (node.Parent != null)
      //  throw new Exception("Oops");
      Debug.Assert(node.Parent == null);

      if (_children == null)
      {
        _children = new List<Node>();
      }

      _children.Add(node);
      node.Parent = this;
    }

    public void AddRange(IEnumerable<Node> nodes)
    {
      foreach (var node in nodes)
      {
        Add(node);
      }
    }

    public override string ToString()
    {
      return Data.ToString();
    }
  }
}
