using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers_v_2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                //initializing the Philosopher by creating new instances of the class
                Philosopher one = new Philosopher("Søren Ryge", 0, 1, 0);
                Philosopher two = new Philosopher("Bubber", 1, 2, 0);
                Philosopher three = new Philosopher("Chilli Claus", 2, 3, 0);
                Philosopher four = new Philosopher("Bjarne Lisby", 3, 4, 0);
                Philosopher five = new Philosopher("Miss Piggy", 4, 0, 0);

                //Just to check if with more plain names to get equal output
                //Philosopher one = new Philosopher("1", 0, 1, 0);
                //Philosopher two = new Philosopher("2", 1, 2, 0);
                //Philosopher three = new Philosopher("3", 2, 3, 0);
                //Philosopher four = new Philosopher("4", 3, 4, 0);
                //Philosopher five = new Philosopher("5", 4, 0, 0);


                //Creating the Threads for each Philosopher adding the philosopher to execute the method Eat
                Thread philosopherEat1 = new Thread(one.Eat);
                Thread philosopherEat2 = new Thread(two.Eat);
                Thread philosopherEat3 = new Thread(three.Eat);
                Thread philosopherEat4 = new Thread(four.Eat);
                Thread philosopherEat5 = new Thread(five.Eat);


                //Starting the threads
                philosopherEat1.Start();
                philosopherEat2.Start();
                philosopherEat3.Start();
                philosopherEat4.Start();
                philosopherEat5.Start();


            }
        }
    }
}
