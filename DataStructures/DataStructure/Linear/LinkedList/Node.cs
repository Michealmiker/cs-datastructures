﻿namespace DataStructure.Linear.LinkedList;

/// <summary>
/// 链表节点
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{
    /// <summary>
    /// 数据域
    /// </summary>
    public T Element { get; set; }

    /// <summary>
    /// 创建节点
    /// </summary>
    /// <param name="elem"></param>
    /// <returns></returns>
    public static Node<T> CreateNode(T elem) => new() { Element = elem };

    /// <summary>
    /// 指针域
    /// </summary>
    public Node<T>? Next { get; set; }

    public override string ToString() => $"{Element}";
}