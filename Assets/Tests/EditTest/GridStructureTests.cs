using NUnit.Framework;
using UnityEngine;
using Grid = GridStructure.Grid;


public class GridStructureTests
{
    private Grid _grid;
    private int cellSize,width,height;


    [SetUp]
    public void Init()
    {
        cellSize = 1;
        _grid = new Grid(cellSize, 10, 10);
    }


    [Test]
    [TestCase(13, 15)]
    [TestCase(10, 12)]
    public void GetPositionPasses(int row, int column)
    {
        var position = _grid.GetPosition(row, column);
        var correctPos = new Vector2(row * cellSize + cellSize/2f, column  * cellSize + cellSize/2f) ;
        Assert.AreEqual(correctPos, position);
    }


    // // A Test behaves as an ordinary method
    // [Test]
    // public void NewTestScriptSimplePasses()
    // {
    //     // Use the Assert class to test conditions
    // }
    //
    // // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // // `yield return null;` to skip a frame.
    // [UnityTest]
    // public IEnumerator NewTestScriptWithEnumeratorPasses()
    // {
    //     // Use the Assert class to test conditions.
    //     // Use yield to skip a frame.
    //     yield return null;
    // }
}