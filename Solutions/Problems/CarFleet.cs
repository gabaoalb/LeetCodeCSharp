namespace Solutions.Problems;

public class CarFleetSolution
{
    /*
        Os carros se movimentam como uma reta no plano cartesiano, a posição Y é a altura de largada a 
        velocidade X é o quanto Y sobe a cada unidade de tempo. O ponto final destas retas é o target
        porém quando elas se interceptam antes ou no target formam uma frota. Nós começamos verificando
        o carro mais próximo da chegada e adicionamos ele na stack, depois verificamos o próximo carro
        se o próximo carro chegaria mais rápido que o primeiro ele simplesmente é descartado pois passa
        a respeitar a velocidade do primeiro. E assim na pilha ficam só os primeiros carros de cada frota
    */
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var stack = new Stack<double>();

        var carInfoArray = position
            .Zip(speed, (position, speed) => (
                position,
                speed,
                time: (double)(target - position) / speed
            ))
            .OrderByDescending(x => x.position)
            .ToArray();

        foreach (var car in carInfoArray)
        {
            stack.Push(car.time);
            // se o novo carro que se juntou a frota faria um tempo menor que o
            // carro que está na frente ele é descartado, junta-se a frota
            if (stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1))
                stack.Pop();
        }

        return stack.Count;
    }

    /* 
        A ideia é muito semelhante a anterior, só o que muda é não usar uma stack.
        Porém a lógica de que o mais lento se torna o puxador de fila é muito mais intuitiva
    */
    public int CarFleetIterator(int target, int[] position, int[] speed)
    {
        var carInfoArray = position
            .Zip(speed, (position, speed) => (
                position,
                speed,
                time: (double)(target - position) / speed
            ))
            .OrderByDescending(x => x.position)
            .ToArray();

        int fleets = 1;
        double prevTime = carInfoArray[0].time;

        for (int i = 1; i < carInfoArray.Length; i++)
        {
            // se o tempo que o carro atual leva para chegar no destino é maior do que quem está a sua frente
            // ele acaba se tornando um puxador de fila, que só pode ser superado por alguém
            // atrás dele que seja ainda mais lento
            if (carInfoArray[i].time > prevTime)
            {
                fleets++;
                prevTime = carInfoArray[i].time;
            }
        }

        return fleets;
    }
}
