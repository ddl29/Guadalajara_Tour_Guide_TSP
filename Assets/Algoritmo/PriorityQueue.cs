using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using System.Collections.Generic;

public class Nodo
{
    public double costo;
	public int[] indices;
		
		public Nodo(int[] indices, double costo) {
			this.indices = indices;
			this.costo = costo;
		}
}

// From http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
public class PriorityQueue {
	private List<Nodo> data;
	public PriorityQueue() {
		this.data = new List<Nodo>();
	}

	public void Enqueue(Nodo item) {
		data.Add(item);
		int ci = data.Count - 1; // child index; start at end
		while (ci > 0) {
			int pi = (ci - 1) / 2; // parent index
			if (data[ci].costo.CompareTo(data[pi].costo) >= 0)
				break; // child item is larger than (or equal) parent so we're done
			Nodo tmp = data[ci];
			data[ci] = data[pi];
			data[pi] = tmp;
			ci = pi;
		}
	}

	public Nodo Dequeue() {
		// assumes pq is not empty; up to calling code
		int li = data.Count - 1; // last index (before removal)
		Nodo frontItem = data[0];   // fetch the front
		data[0] = data[li];
		data.RemoveAt(li);

		--li; // last index (after removal)
		int pi = 0; // parent index. start at front of pq
		while (true) {
			int ci = pi * 2 + 1; // left child index of parent
			if (ci > li)
				break;  // no children so done
			int rc = ci + 1;     // right child
			if (rc <= li && data[rc].costo.CompareTo(data[ci].costo) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
      ci = rc;
			if (data[pi].costo.CompareTo(data[ci].costo) <= 0)
				break; // parent is smaller than (or equal to) smallest child so done
			Nodo tmp = data[pi];
			data[pi] = data[ci];
			data[ci] = tmp; // swap parent and child
			pi = ci;
		}
		return frontItem;
	}

	public int Count() {
		return data.Count;
	}

	public bool isEmpty(){
		if(Count() == 0){
			return true;
		}
		return false;
	}
}
 // PriorityQueue
