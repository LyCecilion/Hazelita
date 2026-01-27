using AngouriMath;
using static AngouriMath.Entity;

// "I put my underwear on inside out today, so now, all of you are inside my pants. Inside and outside are never
// absolute; a single pair of inside-out underwear is enough to flip the world on its head. We assume skin and fabric
// draw hard boundaries, but 'inner' and 'outer' are merely defined by our perspective. Like Zhuangzi dreaming of the
// butterfly, the line between self and object blurs. At this moment, you walk within me, while I exist outside of you—
// everything flows through relationship. Wearing my underwear inside out isn't just an accident; reality is a soft
// fabric, and 'inside' or 'outside' are just temporary folds we create while embracing the world."

namespace Hazelita.CLI;

class Program
{
    private static List<Entity> ConicSectionEntities = [];
    private static List<Entity> Lines = [];
    static Entity.Variable x = "x";
    static Entity.Variable y = "y";

    static void Main(string[] args)
    {
        Console.WriteLine("====== Hazelita v0.1.0 by LyCecilion ======");
        Console.WriteLine();
        Console.WriteLine("由 Project Hazelita 开发的适用于高中数学的计算套件和演示工具");
        Console.WriteLine();
        Console.WriteLine("====== Hazelita v0.1.0 by LyCecilion ======");
        Console.WriteLine();
        Console.WriteLine("该版本目前仅能进行简单的操作。后续版本中会增加更多功能，敬请期待。");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"列表内目前有 {Lines.Count} 条直线和 {ConicSectionEntities.Count} 个圆锥曲线。");
            Console.WriteLine();
            Console.WriteLine("=== 从下方选择一个选项：===");
            Console.WriteLine();
            Console.WriteLine("  1. 添加新的直线或圆锥曲线");
            Console.WriteLine("  2. 联立直线和圆锥曲线");
            Console.WriteLine("  3. 退出");
            Console.WriteLine();
            Console.Write("请输入选项 (1/2/3)：");
            switch (Console.ReadLine())
            {
                case "1":
                    AddNewLineOrConicSectionToList();
                    break;
                case "2":
                    SimultaneousEquationsOfLineAndConicSection();
                    break;
                case "3":
                    Console.WriteLine();
                    Console.WriteLine("感谢使用 Hazelita。祝你拥有美好的一天！");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("无法识别的选项！请重新输入。");
                    break;
            }
        }
    }

    static void AddNewLineOrConicSectionToList()
    {
        Console.WriteLine();
        Console.WriteLine("=== 你想要添加什么？===");
        Console.WriteLine();
        Console.WriteLine("  1. 添加一条直线");
        Console.WriteLine("  2. 添加一个椭圆");
        Console.WriteLine("  3. 添加一对双曲线");
        Console.WriteLine("  4. 添加一条抛物线");
        Console.WriteLine();
        Console.Write("请输入选项 (1/2/3/4)：");
        switch (Console.ReadLine())
        {
            case "1":
                {
                    Console.WriteLine();
                    Console.WriteLine("你想要什么样的直线？");
                    Console.WriteLine("  1. y = kx + b 型。该直线不与 x 轴垂直，k 和 b 是任意实数。");
                    Console.WriteLine("  2. x = my + n 型。该直线不与 y 轴垂直，m 和 n 是任意实数。");
                    Console.WriteLine("  3. mx + ny = r 型。该直线可处于任意状态，m 和 n 不同时为 0。");
                    Console.WriteLine();
                    Console.Write("请输入选项 (1/2/3)：");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                Console.WriteLine();
                                Console.WriteLine("下面定义这条直线。");
                                Console.Write("  [1] 请输入 k 的值：");
                                if (!double.TryParse(Console.ReadLine(), out double k))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                Console.Write("  [2] 请输入 b 的值：");
                                if (!double.TryParse(Console.ReadLine(), out double b))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                var line = y - (k * x + b);
                                Lines.Add(line);
                                Console.WriteLine($"\n已加入你的表达式：{line}");
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine();
                                Console.WriteLine("下面定义这条直线。");
                                Console.Write("  [1] 请输入 m 的值：");
                                if (!double.TryParse(Console.ReadLine(), out double m))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                Console.Write("  [2] 请输入 n 的值：");
                                if (!double.TryParse(Console.ReadLine(), out double n))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                var line = x - (m * y + n);
                                Lines.Add(line);
                                Console.WriteLine($"\n已加入你的表达式 {line}");
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine();
                                Console.WriteLine("下面定义这条直线。");
                                Console.Write("  [1] 请输入 m 的值：");
                                if (!double.TryParse(Console.ReadLine(), out double m))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                Console.Write("  [2] 请输入 n 的值：");
                                if (!double.TryParse(Console.ReadLine(), out double n))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                if (m == 0 && n == 0)
                                {
                                    Console.WriteLine("\nm 和 n 不能同时为 0！请重新输入！");
                                    break;
                                }
                                Console.Write("  [3] 请输入 r 的值：");
                                if (!double.TryParse(Console.ReadLine(), out double r))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                var line = (m * x + n * y) - r;
                                Lines.Add(line);
                                Console.WriteLine($"\n已加入你的表达式 {line}");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine();
                                Console.WriteLine("输入有误，请重新输入。");
                                break;
                            }
                    }
                    break;
                }
            case "2":
                {
                    Console.WriteLine();
                    Console.WriteLine("请将椭圆的表达式化为 x^2 / a^2 + y^2 / b^2 = 1 的形式。这里 a 和 b 是任意非 0 的实数。");
                    Console.WriteLine();
                    Console.Write("  [1] 请输入 a：");
                    if (!double.TryParse(Console.ReadLine(), out double a))
                    {
                        Console.WriteLine("\n无法解析为实数！请重新输入。");
                        break;
                    }
                    else if (a == 0)
                    {
                        Console.WriteLine("a 不能为 0，请重新输入！");
                        break;
                    }
                    Console.Write("  [2] 请输入 b：");
                    if (!double.TryParse(Console.ReadLine(), out double b))
                    {
                        Console.WriteLine("\n无法解析为实数！请重新输入。");
                        break;
                    }
                    else if (b == 0)
                    {
                        Console.WriteLine("b 不能为 0，请重新输入！");
                        break;
                    }
                    var ellipse = MathS.Pow(x, 2) / MathS.Pow(a, 2) + MathS.Pow(y, 2) / MathS.Pow(b, 2) - 1;
                    ConicSectionEntities.Add(ellipse);
                    Console.WriteLine($"已加入你的表达式 {ellipse}");
                    break;
                }
            case "3":
                {
                    Console.WriteLine();
                    Console.WriteLine("你想要什么样的双曲线？");
                    Console.WriteLine();
                    Console.WriteLine("  1. 双曲线的焦点位于 x 轴上，即 x^2 / a^2 - y^2 - b^2 = 1");
                    Console.WriteLine("  2. 双曲线的焦点位于 y 轴上，即 y^2 / a^2 - x^2 - b^2 = 1");
                    Console.WriteLine();
                    Console.WriteLine("请输入选项 (1/2)：");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                Console.WriteLine();
                                Console.WriteLine("请将双曲线的表达式化为 x^2 / a^2 - y^2 / b^2 = 1 的形式。这里 a 和 b 是任意非 0 的实数。");
                                Console.WriteLine();
                                Console.Write("  [1] 请输入 a：");
                                if (!double.TryParse(Console.ReadLine(), out double a))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                else if (a == 0)
                                {
                                    Console.WriteLine("a 不能为 0，请重新输入！");
                                    break;
                                }
                                Console.Write("  [2] 请输入 b：");
                                if (!double.TryParse(Console.ReadLine(), out double b))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                else if (b == 0)
                                {
                                    Console.WriteLine("b 不能为 0，请重新输入！");
                                    break;
                                }
                                var ellipse = MathS.Pow(x, 2) / MathS.Pow(a, 2) - MathS.Pow(y, 2) / MathS.Pow(b, 2) - 1;
                                ConicSectionEntities.Add(ellipse);
                                Console.WriteLine($"已加入你的表达式 {ellipse}");
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine();
                                Console.WriteLine("请将双曲线的表达式化为 y^2 / a^2 - x^2 / b^2 = 1 的形式。这里 a 和 b 是任意非 0 的实数。");
                                Console.WriteLine();
                                Console.Write("  [1] 请输入 a：");
                                if (!double.TryParse(Console.ReadLine(), out double a))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                else if (a == 0)
                                {
                                    Console.WriteLine("a 不能为 0，请重新输入！");
                                    break;
                                }
                                Console.Write("  [2] 请输入 b：");
                                if (!double.TryParse(Console.ReadLine(), out double b))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                else if (b == 0)
                                {
                                    Console.WriteLine("b 不能为 0，请重新输入！");
                                    break;
                                }
                                var hyperbola = MathS.Pow(y, 2) / MathS.Pow(a, 2) - MathS.Pow(x, 2) / MathS.Pow(b, 2) - 1;
                                ConicSectionEntities.Add(hyperbola);
                                Console.WriteLine($"已加入你的表达式 {hyperbola}");
                                break;
                            }
                        default:
                            Console.WriteLine();
                            Console.WriteLine("输入错误！请重新输入。");
                            break;
                    }
                    break;
                }
            case "4":
                {
                    Console.WriteLine();
                    Console.WriteLine("你想要什么样的抛物线？");
                    Console.WriteLine();
                    Console.WriteLine("  1. 形如 x^2 = 2py");
                    Console.WriteLine("  2. 形如 y^2 = 2px");
                    Console.WriteLine();
                    Console.WriteLine("请输入选项 (1/2)：");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                Console.WriteLine();
                                Console.WriteLine("请将抛物线的表达式化为 x^2 = 2py 的形式。这里 p 是非 0 的实数。");
                                Console.WriteLine();
                                Console.Write("  [1] 请输入 p：");
                                if (!double.TryParse(Console.ReadLine(), out double p))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                else if (p == 0)
                                {
                                    Console.WriteLine("p 不能为 0，请重新输入！");
                                    break;
                                }
                                var parabola = MathS.Pow(x, 2) - (2 * p * y);
                                ConicSectionEntities.Add(parabola);
                                Console.WriteLine($"已加入你的表达式 {parabola}");
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine();
                                Console.WriteLine("请将抛物线的表达式化为 y^2 = 2px 的形式。这里 p 是非 0 的实数。");
                                Console.WriteLine();
                                Console.Write("  [1] 请输入 p：");
                                if (!double.TryParse(Console.ReadLine(), out double p))
                                {
                                    Console.WriteLine("\n无法解析为实数！请重新输入。");
                                    break;
                                }
                                else if (p == 0)
                                {
                                    Console.WriteLine("p 不能为 0，请重新输入！");
                                    break;
                                }
                                var parabola = MathS.Pow(y, 2) - (2 * p * x);
                                ConicSectionEntities.Add(parabola);
                                Console.WriteLine($"已加入你的表达式 {parabola}");
                                break;
                            }
                        default:
                            Console.WriteLine();
                            Console.WriteLine("输入错误！请重新输入。");
                            break;
                    }
                    break;
                }
        }
    }

    static void SimultaneousEquationsOfLineAndConicSection()
    {
        Console.WriteLine();
        Console.WriteLine("下面，请输入联立的直线编号：");
        Console.WriteLine();
        var a = 0;
        foreach (var line in Lines)
        {
            Console.WriteLine($"  [{a}] {line}");
            a++;
        }
        Console.WriteLine();
        if (!int.TryParse(Console.ReadLine(), out int LineNo) || LineNo < 0 || LineNo >= Lines.Count)
        {
            Console.WriteLine("输入的直线编号有误！请重新输入。");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("下面，请输入联立的圆锥曲线编号：");
        Console.WriteLine();
        var b = 0;
        foreach (var conicsection in ConicSectionEntities)
        {
            Console.WriteLine($"  [{b}] {conicsection}");
            b++;
        }
        Console.WriteLine();
        if (!int.TryParse(Console.ReadLine(), out int ConicSectionNo) || ConicSectionNo < 0 || ConicSectionNo >= Lines.Count)
        {
            Console.WriteLine("输入的圆锥曲线编号有误！请重新输入。");
            return;
        }
        Console.WriteLine();
        SimultaneousEquations(Lines[LineNo], ConicSectionEntities[ConicSectionNo]);
    }

    static void SimultaneousEquations(Entity a, Entity b)
    {
        var solution = MathS.Equations(a, b).Solve(x, y);

        if (solution is Matrix solMatrix && solMatrix.RowCount >= 2)
        {
            double x1 = (double)solMatrix[0, 0].EvalNumerical();
            double y1 = (double)solMatrix[0, 1].EvalNumerical();
            double x2 = (double)solMatrix[1, 0].EvalNumerical();
            double y2 = (double)solMatrix[1, 1].EvalNumerical();

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine($"\n交点 A: ({x1:F4}, {y1:F4})");
            Console.WriteLine($"交点 B: ({x2:F4}, {y2:F4})");
            Console.WriteLine($"弦长 |AB|: {distance:F4}");
        }
        else
        {
            Console.WriteLine("有 1 或 0 个交点。");
        }
    }
}