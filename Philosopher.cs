using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DiningPhilosophers_v_2_0
{
    class Philosopher
    {

        public static bool[] forks = new bool[5];
        public static object _lock = new object();
        public static Random random = new Random();
        private string name;
        private byte leftHand;
        private byte rightHand;
        private int hunger;



        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public byte LeftHand
        {
            get { return leftHand; }
            set { leftHand = value; }
        }


        public byte RightHand
        {
            get { return rightHand; }
            set { rightHand = value; }
        }

        public int Hunger
        {
            get { return hunger; }
            set { hunger = value; }
        }

        //constructers
        public Philosopher()
        {

        }

        public Philosopher(string name, byte leftHand, byte rightHand, int hunger)
        {
            this.name = name;
            this.leftHand = leftHand;
            this.rightHand = rightHand;
            this.hunger = hunger;
        }


        internal void Eat()
        {
            //  Philosopher philosopher = (Philosopher)phil;
            while (true)
            {
                if (hunger<5)//Setting sleep to thread if hunger is only a bit
                {
                    Thread.Sleep(100);
                }
                if (hunger<3)//Setting sleep to thread if almost no hunger
                {
                    Thread.Sleep(200);
                }

                if (forks[LeftHand] != false || forks[RightHand] != false)//Check if forks is in use
                {

                    if (hunger >= 3)//If hunger is above 3 it will tell me that this thread will now have no delay
                    {
                        hunger +=2;
                        Console.WriteLine($"philosopher {Name} is now very hungry********************************************************-------------------{hunger}");
                        Console.WriteLine($"philosopher {Name} is now set to above normal priority**********************************************************{hunger}");
                    }
                    else //else it will just wait
                    {
                        hunger+=2;
                        Console.WriteLine($"philosopher {Name} is waiting -------------------------------------------------------------------{hunger}");
                    } 
                }

                Monitor.Enter(_lock);//entering the lock

                if (forks[LeftHand] == false && forks[RightHand] == false)//if forks on both sides is not in use, then the philosopher will begin eat
                {
                    try
                    {
                        forks[LeftHand] = true;//Grapping the forks
                        forks[RightHand] = true;
                        Console.WriteLine($"philosopher {Name} is now eating");
                        int rand = random.Next(50, 100);
                        Thread.Sleep(rand);
                        forks[LeftHand] = false;//Put down the forks
                        forks[RightHand] = false;
                        Console.WriteLine($"philosopher {Name} has put down the forks");
                        if (hunger>0)//Counting up hunger +1 if hunger is above 0
                        {
                        hunger --;

                        }
                    }
                    finally
                    {
                        Monitor.Exit(_lock);//Release the lock
                        int rand2 = random.Next(100, 200);
                        Console.WriteLine($"Philosopher {Name} is now thinking");//philosopher is now thinking
                        Thread.Sleep(rand2);
                    }
                }



            }

        }

    }
}
