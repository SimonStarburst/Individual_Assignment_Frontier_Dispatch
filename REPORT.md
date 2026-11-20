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

*Describe important changes/retained choices, operations affected, and time/memory trade-offs.*

*(Example, what was affected when changing to a dictionary? What were the trade-offs? Why did I retain choices?)*







## 3\. Algorithms and adaptation

*Explain your route finder at a useful high level and how the travel-budget query adapts the same ideas.*





## 4\. Complexity

|Operation|Your representation/algorithm|Complexity|Short explanation|
|-|-|-|-|
|Find location by ID|Dictionary.|It's a tad bit more complex from the get go, but it's an investment to be able to search more efficiently in the future.|I add all the locations to a dictionary, where the ID is the Key \& "Location" is the value.|
|Get outgoing connections|Adjecancy list.|Adjecancy lists are not complex at all, since we are able to search for specific keys and get the specific data we want from them.|By using an adjecancy list I am able to save multiple amounts of values for each key. Each loop around the first foreach-loop, a key and list of values is added to the Dictionary. The second foreach-loop adds the to-connections.|
|Priority queue enqueue|List.|Enqueuing new entries does not take much at all in the beginning, but the more we add, the more relative sorting needs to be done. The more items are in the list, the more complex  it gets.|The list is not made of a singular variable, but rather of a struct called Entry, which in turn contains T for item and int for priority.|
|Priority queue dequeue-min||||
|Route finding||||

## 

## 5\. Correctness and testing

*Important tests/edge cases and what they demonstrate.*

*(Example, what existing and self-made tests bring. List of meaningful tests and observed results)*



A failed approach from my end would probably be the lack of Tests I added myself. With more tests, I would have been able to localize more edge cases and potential issues that would have helped me figure out if the script worked as intended. The Tests I did add however have been of great help, both to teach me more about how to implement them and to figure out things about the code I wouldn't have otherwise.

Using a new kind of Test that a classmate taught me, TestCases, I was able to more efficiently create Tests with different data sets right after each other. This came in extra handy when I wanted to test how the Enqueuing and Dequeuing worked with different arrays of 1-9: one sorted, one reversed and where the numbers were in random order. Thanks to this, I was able to see that the script for Enqueuing and Dequeuing, AND the scripts for sifting both up and down, worked as I wanted them to.



## 6\. Performance investigation

Record reproducible before/after measurements for loading/preparation, repeated runtime work, and relevant allocation behavior. Explain what changed and why.



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

*Describe one bug, wrong assumption, failed approach, or surprising result and how you investigated it.*







## 8\. Tools and AI assistance

No AI assistance were used, I did however analyze previous labs and slides to get inspiration on how to write some of the scripts.



## 9\. VG extension



Not working towards VG

