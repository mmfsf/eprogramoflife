using epl.core.Domain;
using epl.core.ValuesObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace epl.core.test
{
  [TestClass]
  public class CommitmentTest
  {
    [TestMethod]
    public void Commitment_IsWorking()
    {
      var c = new MonthlyCommitment("newcommitment");
      Assert.AreEqual(c.Name, "newcommitment");
      Assert.AreEqual(c.Frequency, Frequency.Monthly);
    }

    [TestMethod]
    public void Commitment_AddPerformed()
    {
      var c = new MonthlyCommitment("newcommitment");
      DateTime key = DateTime.Now;
      c.Point(key, Level.Done);
      Assert.AreEqual(c.GetPoint(key), Level.Done);
    }

    [TestMethod]
    public void Commitment_UpdatePerformed()
    {
      var c = new MonthlyCommitment("newcommitment");
      var key = DateTime.Now;
      c.Point(key, Level.Done);
      Assert.AreEqual(c.GetPoint(key), Level.Done);

      c.Point(key, Level.NotDone);
      Assert.AreEqual(c.GetPoint(key), Level.NotDone);
    }

  }
}
