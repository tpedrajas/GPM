namespace GPM.CubeIntersector.Test;

[TestClass]
public class NumberCulturedFormatedAttributeTest
{

    #region IsValid tests

    [TestMethod]
    public void IsValid_Test01()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "1,23";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValid_Test02()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "1.23";

        bool result = attribute.IsValid(checkedValue);

        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("es-ES");

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValid_Test03()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "01,23";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test04()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "0";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValid_Test05()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "-2,333333";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValid_Test06()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "-2,";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test07()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "-12,0000";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValid_Test08()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = ",1";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test09()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "-";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test10()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "--1";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test11()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "+2";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test12()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "aaa";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test13()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "a1,1";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test14()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "1,,1";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValid_Test15()
    {
        NumberCulturedFormatedAttribute attribute = new();
        string checkedValue = "1,01a";

        bool result = attribute.IsValid(checkedValue);

        Assert.IsFalse(result);
    }

    #endregion

}
