using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class StringCalculatorTests
{
    [TestMethod]
    public void Add_EmptyString_ReturnsZero()
    {
        var calculator = new StringCalculator();
        var result = calculator.Add("");
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Add_SingleNumber_ReturnsNumber()
    {
        var calculator = new StringCalculator();
        var result = calculator.Add("1");
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        var calculator = new StringCalculator();
        var result = calculator.Add("1,5");
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Add_MultipleNumbers_ReturnsSum()
    {
        var calculator = new StringCalculator();
        var result = calculator.Add("1,2,3");
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Add_NewLineDelimiter_ReturnsSum()
    {
        var calculator = new StringCalculator();
        var result = calculator.Add("1\n2,3");
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void Add_DifferentDelimiter_ReturnsSum()
    {
        var calculator = new StringCalculator();
        var result = calculator.Add("//;\n1;2");
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Add_NegativeNumbers_ThrowsException()
    {
        var calculator = new StringCalculator();
        try
        {
            calculator.Add("1,-2,3,-4");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("negative numbers not allowed: -2, -4", ex.Message);
            throw;
        }
    }
}
