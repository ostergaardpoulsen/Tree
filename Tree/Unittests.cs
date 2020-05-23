using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
  class Unittests
  {
    [Test]
    public void Test()
    {
      // Test tree:
      //
      // 1
      // +-2
      // +-3
      // +-4
      // +-5
      // +-6
      // +-7
      //
      var root = new Node(
      1,
        new Node(2,
            new Node(3),
            new Node(4)),
        new Node(5,
          new Node(6),
          new Node(7)));

      // Expected output:
      //
      // 1
      // 2
      // 3
      // 4
      // 5
      // 6
      // 7
      //
      var n = root;
      while (n != null)
      {
        Console.WriteLine(n.Data);
        n = n.Next();
      }

      // Test
      //
      n = root;
      Assert.AreEqual(1, n.Data);
      n = n.Next();
      Assert.AreEqual(2, n.Data);
      n = n.Next();
      Assert.AreEqual(3, n.Data);
      n = n.Next();
      Assert.AreEqual(4, n.Data);
      n = n.Next();
      Assert.AreEqual(5, n.Data);
      n = n.Next();
      Assert.AreEqual(6, n.Data);
      n = n.Next();
      Assert.AreEqual(7, n.Data);
      n = n.Next();
      Assert.IsNull(n);
    }

    [Test(Description = "Tester, at der itereres over noder med samme værdi")]
    public void Test2()
    {
      // Test tree:
      //
      // 1
      // +-2
      // +-2
      // +-2
      // +-5
      // +-6
      // +-7
      //
      var root = new Node(
      1,
        new Node(2,
            new Node(2),
            new Node(2)),
        new Node(5,
          new Node(6),
          new Node(7)));

      // Expected output:
      //
      // 1
      // 2
      // 2
      // 2
      // 5
      // 6
      // 7
      //

      // Test
      //
      var n = root;
      Assert.AreEqual(1, n.Data);
      n = n.Next();
      Assert.AreEqual(2, n.Data);
      n = n.Next();
      Assert.AreEqual(2, n.Data);
      n = n.Next();
      Assert.AreEqual(2, n.Data);
      n = n.Next();
      Assert.AreEqual(5, n.Data);
      n = n.Next();
      Assert.AreEqual(6, n.Data);
      n = n.Next();
      Assert.AreEqual(7, n.Data);
      n = n.Next();
      Assert.IsNull(n);
    }

    [Test(Description = "Tester et dybere hierarki")]
    public void Test3()
    {
      // Test tree:
      //
      // 1
      // +-2
      // ++-3
      // ++-4
      // ++-5
      // +++-6
      // +++-7
      //
      var root = new Node(
      1,
        new Node(2,
            new Node(3),
            new Node(4),
        new Node(5,
          new Node(6),
          new Node(7))));

      // Test
      //
      var n = root;
      Assert.AreEqual(1, n.Data);
      n = n.Next();
      Assert.AreEqual(2, n.Data);
      n = n.Next();
      Assert.AreEqual(3, n.Data);
      n = n.Next();
      Assert.AreEqual(4, n.Data);
      n = n.Next();
      Assert.AreEqual(5, n.Data);
      n = n.Next();
      Assert.AreEqual(6, n.Data);
      n = n.Next();
      Assert.AreEqual(7, n.Data);
      n = n.Next();
      Assert.IsNull(n);
    }

    [Test(Description = "Tænkt eksempel... Noden er null... Er det produktionskode?")]
    public void Test4()
    {
      Assert.Throws<InvalidEnumArgumentException>(() => ((Node)null).Next(), "Den havde jeg ikke lige set komme...");
    }
  }


}
