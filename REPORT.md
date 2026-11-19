# REPORT.md - Individual Assignment

Keep this concise and specific to your implementation.





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



(Example, what was affected when changing to a dictionary? What were the trade-offs? Why did I retain choices?)



## 3\. Algorithms and adaptation

Explain your route finder at a useful high level and how the travel-budget query adapts the same ideas.



(Example 



## 4\. Complexity

|Operation|Your representation/algorithm|Complexity|Short explanation|
|-|-|-|-|
|Find location by ID|Dictionary|It's a tad bit more complex from the get go, but it's an investment to be able to search more efficiently in the future.|I add all the locations to a dictionary, where the ID is the Key \& "Location" is the value.|
|Get outgoing connections|Adjecancy|||
|Priority queue enqueue||||
|Priority queue dequeue-min||||
|Route finding||||

## 

## 5\. Correctness and testing

Important tests/edge cases and what they demonstrate.



(Example, what existing and self-made tests bring. List of meaningful tests and observed results)



## 6\. Performance investigation

Record reproducible before/after measurements for loading/preparation, repeated runtime work, and relevant allocation behavior. Explain what changed and why.



###### Before implementing any changes:

###### Data from Baseline:

**Locations**: 2500

**Connections**: 9800

**Iterations**: 5000

**Elapsed**: 549 ms

**Checksum**: 6267100

###### 

###### Test summary:

Total 6; failed 0; succeeded 3; skipped 3; duration 0,8s;



||**Before implementing any changes:**|**After implementing any changes:**|
|-|-|-|
|**Locations**|2500|2500|
|**Connections**|9800|9800|
|**Iterations**|5000|5000|
|**Elapsed (World)**|-|3,000 ms|
|**Elapsed (Query)**|549 ms|0 ms|
|**Allocation (World)**|-|1744368|
|**Allocation (Query)**|-|160000|
|**Checksum**|6267100|6267100|







## 7\. Development reflection

Describe one bug, wrong assumption, failed approach, or surprising result and how you investigated it.



## 8\. Tools and AI assistance

Briefly describe relevant assistance, if any.



## 9\. VG extension



Not working towards VG

