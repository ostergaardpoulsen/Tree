using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Tree
{
  public static class NodeExtensions
  {
    public static Node Next(this Node node)
    {
      if (node == null)
        throw new InvalidEnumArgumentException("Den havde jeg ikke lige set komme...");

      // Hvis noden har børn, returner det første
      if (node.Children.Any())
        return node.Children.First();

      // Ellers hvis der er flere elementer i samme collection som noden, returner den næste (hvis den findes)
      var nextSibling = GetNextSibling(node);
      if (nextSibling != null)
        return nextSibling;

      // Ellers find forældrenodens næste element i samme collection som forældren... Og bliv ved med det op til toppen af træet
      var currentNode = node;
      Node parentNode;
      while (true)
      {
        parentNode = currentNode.Parent;
        if (parentNode == null)
          return null;

        var parentSibling = GetNextSibling(parentNode);
        if (parentSibling != null)
          return parentSibling;
        currentNode = parentNode;
      }
    }

    private static Node GetNextSibling(Node node)
    {
      if (node.Parent == null)
        return null;

      var siblings = node.Parent.Children.GetEnumerator();
      while (siblings.MoveNext())
      {
        if (siblings.Current.Equals(node))
          break;
      }
      if (siblings.MoveNext())
        return siblings.Current;

      return null;
    }


  }

}
