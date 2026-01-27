using AngouriMath;
using static AngouriMath.Entity;
using Hazelita.Core;

// "I put my underwear on inside out today, so now, all of you are inside my pants. Inside and outside are never
// absolute; a single pair of inside-out underwear is enough to flip the world on its head. We assume skin and fabric
// draw hard boundaries, but 'inner' and 'outer' are merely defined by our perspective. Like Zhuangzi dreaming of the
// butterfly, the line between self and object blurs. At this moment, you walk within me, while I exist outside of you—
// everything flows through relationship. Wearing my underwear inside out isn't just an accident; reality is a soft
// fabric, and 'inside' or 'outside' are just temporary folds we create while embracing the world."

namespace Hazelita.CLI;

class Program
{
    private static readonly GeometryContext context = new GeometryContext();
    static readonly Entity.Variable x = "x";
    static readonly Entity.Variable y = "y";

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
            Console.WriteLine($"列表内目前有 {context.Lines.Count} 条直线和 {context.Conics.Count} 个圆锥曲线。");
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
                                Console.WriteLine();
                                double k = InputHelper.GetDoubleInput("  [1] 请输入 k 的值：");
                                double b = InputHelper.GetDoubleInput("  [2] 请输入 b 的值：");
                                var line = y - (k * x + b);
                                context.AddLine(line);
                                Console.WriteLine($"\n已加入你的表达式：{line}");
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine();
                                Console.WriteLine("下面定义这条直线。");
                                Console.WriteLine();

                                double m = InputHelper.GetDoubleInput("  [1] 请输入 m 的值：");
                                double n = InputHelper.GetDoubleInput("  [2] 请输入 n 的值：");
                                var line = x - (m * y + n);
                                context.AddLine(line);
                                Console.WriteLine($"\n已加入你的表达式 {line}");
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine();
                                Console.WriteLine("下面定义这条直线。");
                                Console.WriteLine();
                                double m = InputHelper.GetDoubleInput("  [1] 请输入 m 的值：");
                                double n = InputHelper.GetDoubleInput("  [2] 请输入 n 的值：");
                                if (m == 0 && n == 0)
                                {
                                    Console.WriteLine("\nm 和 n 不能同时为 0！请重新输入！");
                                    break;
                                }
                                double r = InputHelper.GetDoubleInput("  [3] 请输入 r 的值：");
                                var line = (m * x + n * y) - r;
                                context.AddLine(line);
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
                    double a = InputHelper.GetNotZeroDoubleInput("  [1] 请输入 a：");
                    double b = InputHelper.GetNotZeroDoubleInput("  [2] 请输入 b：");
                    var ellipse = MathS.Pow(x, 2) / MathS.Pow(a, 2) + MathS.Pow(y, 2) / MathS.Pow(b, 2) - 1;
                    context.AddConic(ellipse);
                    Console.WriteLine($"已加入你的表达式 {ellipse}");
                    break;
                }
            case "3":
                {
                    Console.WriteLine();
                    Console.WriteLine("你想要什么样的双曲线？");
                    Console.WriteLine();
                    Console.WriteLine("  1. 双曲线的焦点位于 x 轴上，即 x^2 / a^2 - y^2 / b^2 = 1");
                    Console.WriteLine("  2. 双曲线的焦点位于 y 轴上，即 y^2 / a^2 - x^2 / b^2 = 1");
                    Console.WriteLine();
                    Console.WriteLine("请输入选项 (1/2)：");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            {
                                Console.WriteLine();
                                Console.WriteLine("请将双曲线的表达式化为 x^2 / a^2 - y^2 / b^2 = 1 的形式。这里 a 和 b 是任意非 0 的实数。");
                                Console.WriteLine();
                                double a = InputHelper.GetNotZeroDoubleInput("  [1] 请输入 a：");
                                double b = InputHelper.GetNotZeroDoubleInput("  [2] 请输入 b：");
                                var hyperbola = MathS.Pow(x, 2) / MathS.Pow(a, 2) - MathS.Pow(y, 2) / MathS.Pow(b, 2) - 1;
                                context.AddConic(hyperbola);
                                Console.WriteLine($"已加入你的表达式 {hyperbola}");
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine();
                                Console.WriteLine("请将双曲线的表达式化为 y^2 / a^2 - x^2 / b^2 = 1 的形式。这里 a 和 b 是任意非 0 的实数。");
                                Console.WriteLine();
                                double a = InputHelper.GetNotZeroDoubleInput("  [1] 请输入 a：");
                                double b = InputHelper.GetNotZeroDoubleInput("  [2] 请输入 b：");
                                var hyperbola = MathS.Pow(y, 2) / MathS.Pow(a, 2) - MathS.Pow(x, 2) / MathS.Pow(b, 2) - 1;
                                context.AddConic(hyperbola);
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
                                double p = InputHelper.GetNotZeroDoubleInput("  请输入 p：");
                                var parabola = MathS.Pow(x, 2) - (2 * p * y);
                                context.AddConic(parabola);
                                Console.WriteLine($"已加入你的表达式 {parabola}");
                                break;
                            }
                        case "2":
                            {
                                Console.WriteLine();
                                Console.WriteLine("请将抛物线的表达式化为 y^2 = 2px 的形式。这里 p 是非 0 的实数。");
                                Console.WriteLine();
                                double p = InputHelper.GetNotZeroDoubleInput("  请输入 p：");
                                var parabola = MathS.Pow(y, 2) - (2 * p * x);
                                context.AddConic(parabola);
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
            default:
                Console.WriteLine();
                Console.WriteLine("输入错误！请重新输入。");
                break;
        }
    }

    static void SimultaneousEquationsOfLineAndConicSection()
    {
        if (context.Lines.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("列表中没有直线！请先添加直线。");
            return;
        }
        if (context.Conics.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("列表中没有圆锥曲线！请先添加圆锥曲线。");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("下面，请输入联立的直线编号：");
        Console.WriteLine();
        var a = 0;
        foreach (var line in context.Lines)
        {
            Console.WriteLine($"  [{a}] {line} = 0");
            a++;
        }
        Console.WriteLine();
        if (!int.TryParse(Console.ReadLine(), out int LineNo) || LineNo < 0 || LineNo >= context.Lines.Count)
        {
            Console.WriteLine("输入的直线编号有误！请重新输入。");
            return;
        }
        Console.WriteLine();
        Console.WriteLine("下面，请输入联立的圆锥曲线编号：");
        Console.WriteLine();
        var b = 0;
        foreach (var conicsection in context.Conics)
        {
            Console.WriteLine($"  [{b}] {conicsection} = 0");
            b++;
        }
        Console.WriteLine();
        if (!int.TryParse(Console.ReadLine(), out int ConicNo) || ConicNo < 0 || ConicNo >= context.Conics.Count)
        {
            Console.WriteLine("输入的圆锥曲线编号有误！请重新输入。");
            return;
        }
        Console.WriteLine();
        Console.WriteLine($"你选择了联立 {context.Lines[LineNo]} = 0 和 {context.Conics[ConicNo]} = 0。");
        Console.WriteLine();

        var (points, distance) = context.SolveIntersection(LineNo, ConicNo);

        var intersectionCount = points.Count;

        Console.WriteLine($"二者存在 {intersectionCount} 个交点。");
        Console.WriteLine();
        if (intersectionCount > 0)
        {
            Console.WriteLine("下面列出交点：");
            var i = 0;
            foreach (var point in points)
            {
                Console.WriteLine($"  [{i}] ({point.x}, {point.y})");
                i++;
            }
            Console.WriteLine();
            if (intersectionCount > 1)
            {
                Console.WriteLine($"两个交点的距离为 {distance}");
                Console.WriteLine();
            }
        }
    }
}