# REPORT.md - Individual Assignment

Keep this concise and specific to your implementation.

###### 

###### Data from Baseline:

**Locations**: 2500

**Connections**: 9800

**Iterations**: 5000

**Elapsed**: 549 ms

**Checksum**: 6267100

###### 

###### Test summary:

Total 6; failed 0; succeeded 3; skipped 3; duration 0,8s;





## 1\. Initial analysis



* **How are locations and connections represented in the baseline?**

In the Baseline code, the Locations and Connections are represented by the way we search through them when we run RunBaseLine().

We call upon the methods FindLocationByID() and FindOutgoinfConnections() from WorldQueries, which in turn goes through

lists for locations and Connections found in WorldData.



* **Which operations appear frequent?**

There's a lot of for-loops and linear searching.



* **Which operation(s) do you predict may scale poorly?**

The linear searches, i.e the one in FindLocationByID, can possibly scale poorly depending on the size of ID's availabe.



* **What will you investigate first?**

I will begin to investigate what sorting and searching algorithms there are and if any can become more efficient.





## 2\. Data representation

Describe important changes/retained choices, operations affected, and time/memory trade-offs.



## 3\. Algorithms and adaptation

Explain your route finder at a useful high level and how the travel-budget query adapts the same ideas.



## 4\. Complexity

|Operation|Your representation/algorithm|Complexity|Short explanation|
|-|-|-|-|
|Find location by ID||||
|Get outgoing connections||||
|Priority queue enqueue||||
|Priority queue dequeue-min||||
|Route finding||||

## 5\. Correctness and testing

Important tests/edge cases and what they demonstrate.



## 6\. Performance investigation

Record reproducible before/after measurements for loading/preparation, repeated runtime work, and relevant allocation behavior. Explain what changed and why.



## 7\. Development reflection

Describe one bug, wrong assumption, failed approach, or surprising result and how you investigated it.



## 8\. Tools and AI assistance

Briefly describe relevant assistance, if any.



## 9\. VG extension

Only if attempting VG: heuristic, traversal constraints, correctness, and Dijkstra/A\* comparison.

