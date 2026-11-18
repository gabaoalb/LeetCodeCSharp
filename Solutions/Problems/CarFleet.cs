namespace Solutions.Problems;

public class CarFleetSolution
{
    /// <summary>
    /// Stack-based solution to calculate the number of car fleets reaching the target.
    /// </summary>
    /// <param name="target">The target position that cars are trying to reach.</param>
    /// <param name="position">An array representing the starting positions of the cars.</param>
    /// <param name="speed">An array representing the speeds of the cars.</param>
    /// <returns>The number of car fleets that will arrive at the target.</returns>
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var stack = new Stack<double>();

        (int position, double time)[] carInfoArray =
        [
            .. position
                .Zip(
                    speed,
                    (position, speed) => (position, time: (double)(target - position) / speed)
                )
                .OrderByDescending(x => x.position),
        ];

        foreach (var car in carInfoArray)
            if (stack.Count == 0 || car.time > stack.Peek())
                stack.Push(car.time);

        return stack.Count;
    }

    /// <summary>
    /// Greedy-based solution to calculate the number of car fleets reaching the target.
    /// </summary>
    /// <param name="target">The target position that cars are trying to reach.</param>
    /// <param name="position">An array representing the starting positions of the cars.</param>
    /// <param name="speed">An array representing the speeds of the cars.</param>
    /// <returns>The number of car fleets that will arrive at the target.</returns>
    public int CarFleetGreedy(int target, int[] position, int[] speed)
    {
        (int position, double time)[] carInfoArray =
        [
            .. position
                .Zip(
                    speed,
                    (position, speed) => (position, time: (double)(target - position) / speed)
                )
                .OrderByDescending(x => x.position),
        ];

        int fleets = 0;
        double previousFleetTime = double.NegativeInfinity;

        foreach (var car in carInfoArray)
            if (car.time > previousFleetTime)
            {
                fleets++;
                previousFleetTime = car.time;
            }

        return fleets;
    }
}
