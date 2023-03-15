namespace GPM.CubeIntersector.Test;

[TestClass]
public class CurrentIntersectionLogicTest
{

    #region ExistsCubeIntersect tests

    /*[TestMethod]
    public void ExistsCubeIntersect_Test01()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(2, 2, 2, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test02()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(1, 1, 1, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test03()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(-1, -1, -1, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test04()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(1, 1, 1, 0.99f, 0.99f, 0.99f);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test05()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test06()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 0.5f, 0.5f, 0.5f);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test07()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 2, 2, 2);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test08()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 2, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test09()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(-2, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test10()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, -2, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test11()
    {
        Cube cube1 = new(2, 2, 2, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test12()
    {
        Cube cube1 = new(1, 1, 1, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test13()
    {
        Cube cube1 = new(-1, -1, -1, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test14()
    {
        Cube cube1 = new(1, 1, 1, 0.99f, 0.99f, 0.99f);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test15()
    {
        Cube cube1 = new(0, 0, 0, 0.5f, 0.5f, 0.5f);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test16()
    {
        Cube cube1 = new(0, 0, 0, 2, 2, 2);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test17()
    {
        Cube cube1 = new(0, 2, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test18()
    {
        Cube cube1 = new(-2, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ExistsCubeIntersect_Test19()
    {
        Cube cube1 = new(0, 0, -2, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        bool result = CubeIntersectionLogic.ExistsCubeIntersect(cube1, cube2);

        Assert.IsFalse(result);
    }*/

    #endregion

    #region GetCubeIntersect tests

    /*[TestMethod]
    public void GetCubeIntersect_Test01()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(2, 2, 2, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test02()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(1, 1, 1, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(0.5f, 0.5f, 0.5f, 0, 0, 0);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test03()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(-1, -1, -1, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(-0.5f, -0.5f, -0.5f, 0, 0, 0);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test04()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(1, 1, 1, 0.99f, 0.99f, 0.99f);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test05()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(0, 0, 0, 1, 1, 1);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test06()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 0.5f, 0.5f, 0.5f);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(0, 0, 0, 0.5f, 0.5f, 0.5f);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test07()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 2, 2, 2);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(0, 0, 0, 1, 1, 1);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test08()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 2, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test09()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(-2, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test10()
    {
        Cube cube1 = new(0, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, -2, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test11()
    {
        Cube cube1 = new(2, 2, 2, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test12()
    {
        Cube cube1 = new(1, 1, 1, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(0.5f, 0.5f, 0.5f, 0, 0, 0);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test13()
    {
        Cube cube1 = new(-1, -1, -1, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(-0.5f, -0.5f, -0.5f, 0, 0, 0);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test14()
    {
        Cube cube1 = new(1, 1, 1, 0.99f, 0.99f, 0.99f);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test15()
    {
        Cube cube1 = new(0, 0, 0, 0.5f, 0.5f, 0.5f);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(0, 0, 0, 0.5f, 0.5f, 0.5f);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test16()
    {
        Cube cube1 = new(0, 0, 0, 2, 2, 2);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = new(0, 0, 0, 1, 1, 1);

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test17()
    {
        Cube cube1 = new(0, 2, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test18()
    {
        Cube cube1 = new(-2, 0, 0, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }

    [TestMethod]
    public void GetCubeIntersect_Test19()
    {
        Cube cube1 = new(0, 0, -2, 1, 1, 1);
        Cube cube2 = new(0, 0, 0, 1, 1, 1);

        Cube? result = CubeIntersectionLogic.GetCubeIntersect(cube1, cube2);
        Cube? resultCompare = null;

        Assert.AreEqual(result, resultCompare);
    }*/

    #endregion

}
