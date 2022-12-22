using System;

public class Queue
{
	private int first, last, size;
	private int[] queue;

	public Queue(int c)
	{
		first = last = 0;
		size = c;
		queue = new int[size];
	}

	public void Enqueue(int data)
	{
		lock (this)
		{
			if (size == last)
			{
				Console.Write("Очередь заполнена.");
				return;
			}

			else
			{
				queue[last] = data;
				last++;
			}
			return;
		}	
	}

	public void Dequeue()
	{
        lock (this)
        {

            if (first == last)
			{
			Console.Write("Очередь пуста.");
			return;
			}

			else
			{
			for (int i = 0; i < last - 1; i++)
			{
				queue[i] = queue[i + 1];
			}

			if (last < size)
				queue[last] = 0;

			last--;
			}
            return;
        }
	}

	public void queueDisplay()
	{
		int i;
		if (first == last)
		{
			Console.Write("Очередь пуста.");
			return;
		}

		for (i = first; i < last; i++)
		{
			Console.Write($"{queue[i]}, ");
		}
		return;
	}
	public string queueFirst()
	{
		if (first == last)
		{
			return "Очередь пуста.";
		}
		return Convert.ToString(queue[first]);
	}
}