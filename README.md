# cs-algorithms
Package cs-algorithms provides C# implementation of algorithms for data structures and manipulation, as well as graph and string processing

[![Build Status](https://travis-ci.org/cschen1205/cs-algorithms.svg?branch=master)](https://travis-ci.org/cschen1205/cs-algorithms)

# Install

Install-Package cs-algorithms

# Features

* Data Structure

  - Stack

    + Linked List
    + Array

  - Queue

    + Linked List
    + Array

  - HashSet
  - HashMap

    + Separate Chaining
    + Linear Probing

  - Binary Search Tree
  - Red Black Tree
  - Priority Queue

    + MinPQ
    + MaxPQ
    + IndexMinPQ

  - Graph

    + Simple graph
    + Edge weighted graph
    + Directed graph (digraph)
    + Directed edge weight graph

  - Search Tries (Symbol table with string-based keys)

    + R-way search tries
    + Ternary search tries

* Algorithms

  - Sorting

    + Selection Sort
    + Insertion Sort
    + Shell Sort
    + Merge Sort
    + Quick Sort
    + 3-Ways Quick Sort
    + Heap Sort

  - Selection

    + Binary Search

  - Shuffling

    + Knuth

  - Union Find

    + Quick Find
    + Weighted Quick Union with path compression

* Graph Algorithms

  - Search

    + Depth First Search
    + Breadth First Search

  - Connectivity

    + Connected Components
    + Strongly Connected Components

  - Topological Sorting

    + Depth First Reverse Post Order

  - Directed Cycle Detection

  - Minimum Spanning Tree

    + Kruskal
    + Prim (Lazy)
    + Prim (Eager)

  - Shortest Path

    + Dijkstra
    + Topological Sort (for directed acyclic graph, namely dag)
    + Bellman-Ford (for graph with negative weight as well)

  - MaxFlow MinCut

    + Ford-Fulkerson

* Strings

  - Longest Repeated Substring
  - String Sorting

    + LSD (Least Significant Digit first radix sorting)
    + MSD (Most Significant Digit first radix sorting)
    + 3-Ways String Quick Sort

  - String Search

    + Brute force
    + Rabin Karp
    + Boyer Moore
    + Knuth Morris Pratt
