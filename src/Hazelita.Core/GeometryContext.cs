using AngouriMath;
using System.Collections.Generic;
using static AngouriMath.Entity;

namespace Hazelita.Core;

public class GeometryContext
{
    public List<Entity> Lines { get; } = new();
    public List<Entity> Conics { get; } = new();

    public void AddLine(Entity lineExpr)
    {
        Lines.Add(lineExpr);
    }

    public void AddConic(Entity conicExpr)
    {
        Conics.Add(conicExpr);
    }

    public (List<(double x, double y)> points, double distance) SolveIntersection(int lineIndex, int conicIndex)
    {
        if (lineIndex < 0 || lineIndex >= Lines.Count)
            throw new ArgumentOutOfRangeException(nameof(lineIndex));
        if (conicIndex < 0 || conicIndex >= Conics.Count)
            throw new ArgumentOutOfRangeException(nameof(conicIndex));

        var line = Lines[lineIndex];
        var conic = Conics[conicIndex];

        var x = MathS.Var("x");
        var y = MathS.Var("y");

        var solution = MathS.Equations(line, conic).Solve(x, y);

        var results = new List<(double x, double y)>();
        double dist = 0;

        if (solution is Matrix solMatrix && solMatrix.RowCount >= 2)
        {
            double x1 = (double)solMatrix[0, 0].EvalNumerical();
            double y1 = (double)solMatrix[0, 1].EvalNumerical();
            double x2 = (double)solMatrix[1, 0].EvalNumerical();
            double y2 = (double)solMatrix[1, 1].EvalNumerical();

            results.Add((x1, y1));
            results.Add((x2, y2));

            dist = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        return (results, dist);
    }

}