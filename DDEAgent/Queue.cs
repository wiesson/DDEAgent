using System;
using System.Collections;

namespace DDEAgent {
    public class MyQueue {
        public static Queue storage = new Queue();

        public static void QueueStatus() {
            // Creates and initializes a new Queue.
            // Displays the properties and values of the Queue.
            // Console.WriteLine("storage");
            Console.WriteLine("\tCount:    {0}", storage.Count);
            // Console.Write( "\tValues:" );

            /* Displays the Queue.
            Console.Write("Queue values:");
            PrintValues(storage);

            // Removes an element from the Queue.
            // Console.WriteLine("(Dequeue)\t{0}", storage.Dequeue());

            // Displays the Queue.
            Console.Write("Queue values:");
            PrintValues(storage);

            // Removes another element from the Queue.
            // Console.WriteLine("(Dequeue)\t{0}", storage.Dequeue());

            // Displays the Queue.
            Console.Write("Queue values:");
            PrintValues(storage);

            // Views the first element in the Queue but does not remove it.
            Console.WriteLine("(Peek)   \t{0}", storage.Peek()); */
        }

        public static void EnqueueItem(string newEvent) {
            storage.Enqueue(newEvent);
        }
        public static void DequeueItem() {
            PrintValues(storage);
            Console.WriteLine("\tCount:    {0}", storage.Count);
            storage.Dequeue();
        }

        public static void QueueSend() { 
        
        }

        public static void PrintValues(IEnumerable myCollection) {
            foreach ( Object obj in myCollection )
                Console.Write( "    {0}", obj );
            Console.WriteLine();
        }
    }
}