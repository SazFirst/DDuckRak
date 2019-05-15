using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue
{
    int[] queue;
    int rear;
    int front;
    int size;

    public Queue(int size)
    {
        rear = 0;
        this.size = size;
        queue = new int[size];
    }

    public void Put(int val)
    {
        queue[rear] = val;
        rear = ++rear % size;
    }

    public int Get()
    {
        int val = queue[front];
        front = ++front % size;
        return val;
    }

    public int Front()
    {
        return queue[front];
    }
}
