using NUnit.Framework;
using UnityEngine;
using Grid = GridStructure.Grid;


public class GridStructureTests
{
    private Grid _grid;
    private int cellSize, row, column;


    [SetUp]
    public void Init()
    {
        cellSize = 1;
        row = 10;
        column = 10;
        _grid = new Grid(cellSize, row, column);
    }


    [Test]
    [TestCase(3, 2)]
    public void GetPositionPasses(int row, int column)
    {
        var position = _grid.GetPosition(row, column);
        var correctPos = new Vector2(row * cellSize + cellSize / 2f, column * cellSize + cellSize / 2f);
        Assert.AreEqual(correctPos, position);
    }

    [Test]
    [TestCase(2 + 0.5f, 1 + 0.5f)]
    public void GetIndicesByPositionPasses(float x, float y)
    {
        var position = new Vector2(x, y);
        var indices = _grid.GetIndicesByPosition(position);
        var correctIndices = new Vector2Int(
            (int)(position.x / cellSize - cellSize),
            (int)(position.y / cellSize - cellSize)
        );
        Assert.AreEqual(correctIndices, indices);
    }



}