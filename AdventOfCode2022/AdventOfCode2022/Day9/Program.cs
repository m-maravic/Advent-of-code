using Day9;

var head = new Knot(5, 1);
var tail = new Knot(5, 1);

var positions = new List<Tuple<int, int>>() { new Tuple<int, int>(5, 1) };

foreach (string motion in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "/input.txt"))
{
    var direction = motion.Split(' ')[0];
    var steps = Int32.Parse(motion.Split(' ')[1]);

    switch (direction)
    {
        case "U":
            for (int i = 0; i < steps; i++)
            {
                head.Move(head.X - 1, head.Y);
                if (!tail.IsTouching(head.X, head.Y))
                {
                    tail.Move(head.X + 1, head.Y);
                    positions.Add(new Tuple<int, int>(tail.X, tail.Y));
                }
            }
            break;
        case "D":
            for (int i = 0; i < steps; i++)
            {
                head.Move(head.X + 1, head.Y);
                if (!tail.IsTouching(head.X, head.Y))
                {
                    tail.Move(head.X - 1, head.Y);
                    positions.Add(new Tuple<int, int>(tail.X, tail.Y));
                }
            }
            break;
        case "L":
            for (int i = 0; i < steps; i++)
            {
                head.Move(head.X, head.Y - 1);
                if (!tail.IsTouching(head.X, head.Y))
                {
                    tail.Move(head.X, head.Y +1);
                    positions.Add(new Tuple<int, int>(tail.X, tail.Y));
                }
            }
            break;
        case "R":
            for (int i = 0; i < steps; i++)
            {
                head.Move(head.X, head.Y + 1);
                if (!tail.IsTouching(head.X, head.Y))
                {
                    tail.Move(head.X, head.Y - 1);
                    positions.Add(new Tuple<int, int>(tail.X, tail.Y));
                }
            }
            break;
        default:
            break;
    }
}

var partOne = positions.Distinct().Count();

Console.WriteLine("Part one: " + partOne);
