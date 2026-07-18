using Solutions.Problems;

namespace Solutions.Tests.Problems;

public class ImplementStackUsingQueuesTest
{
    [Fact]
    public void TestPushPopTopEmpty()
    {
        var stack = new MyStack();
        Assert.True(stack.Empty());
        stack.Push(1);
        Assert.False(stack.Empty());
        Assert.Equal(1, stack.Top());
        stack.Push(2);
        Assert.Equal(2, stack.Top());
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Top());
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.Empty());
    }

    [Fact]
    public void TestMultiplePushPop()
    {
        var stack = new MyStack();
        for (int i = 0; i < 10; i++)
        {
            stack.Push(i);
        }
        for (int i = 9; i >= 0; i--)
        {
            Assert.Equal(i, stack.Pop());
        }
        Assert.True(stack.Empty());
    }

    [Fact]
    public void TestTopWithoutPop()
    {
        var stack = new MyStack();
        stack.Push(5);
        Assert.Equal(5, stack.Top());
        Assert.Equal(5, stack.Top());
        Assert.False(stack.Empty());
    }

    [Fact]
    public void TestEmptyOnNewStack()
    {
        var stack = new MyStack();
        Assert.True(stack.Empty());
    }
}
