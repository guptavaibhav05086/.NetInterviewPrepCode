using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PrepCode.IEnumeratorExample;

using PrepCode.BST;

namespace PrepCode
{
    

    class Program
    {
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.WriteLine(arr[i] + " ");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            #region anagram..
            var statusAnagram = Anagram("geeksforgeeks", "forgeeksgeeks");
            #endregion
            #region Merge Sort..
            int[] arr = { 12, 11, 13, 5, 6, 7,200,3,50,201,145,104 };
            //Array.Sort(arr); To sort the array
            //String.Join(" ", arr); To Join the array
            Console.WriteLine("Given Array");
            printArray(arr);
           
            MergeSort ob = new MergeSort();
            ob.sort(arr, 0, arr.Length - 1);

            Console.WriteLine("\nSorted array");
            printArray(arr);
            #endregion
            #region Binary Search Tree...
            BSTree tree = new BSTree();
            tree.Insert(50);
            tree.Insert(49);
            tree.Insert(60);
            tree.Insert(53);
            tree.Insert(30);
            tree.Insert(36);
            tree.Preorder(tree.root);
            #endregion
            string checkPalindrome = Console.ReadLine();
            var result = CheckPalindrome(checkPalindrome);
            //Value Tyep
            #region Enumurable Example...
            Person[] people = new Person[3]
            {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
            };
            People peopleList = new People(people);
            foreach (Person item in peopleList)
            {
                Console.Write(item.firstName);
            }
            #endregion
            #region Inheritance Implementation demo...
            Child c = new Child(10);
            Parent referenceTypeParent = c;
            //ShowBio is an Overridden method so the method of child class will be called
            referenceTypeParent.ShowBio();
            //NoOverideMethod is implemted with new keyword so it will call the Parent Method
            referenceTypeParent.NoOverideMethod();

            SubChild sc = new SubChild();
            referenceTypeParent = sc;
            sc.ShowBio();
            Console.WriteLine(Child.demoVal);
            #endregion
            #region Factory Pattern
            Creator newFactory = new Factory();
            IProduct prodA = newFactory.FactoryMethod("A");
            prodA.CreateProduct();
            IProduct prodB = newFactory.FactoryMethod("B");
            prodB.CreateProduct();
            #endregion
            #region Calling lcm

            Program.LCM();
            #endregion
            #region Calling recursion...
            Console.WriteLine("{0} ",FibonacciRecursion(4));
            Console.ReadLine();
            #endregion

            #region Multi Threading
            //Thread start class is a delegate class which accepts a method with no parameter as a call back method
            ThreadStart threadstart1 = new ThreadStart(StartChildThread1);
            ThreadStart threadstart2 = new ThreadStart(StartChildThread2);
            //Passing the delegate to the Thread class.Thread class accept the ThreadStart delegate object as parameter
            Thread thread1 = new Thread(threadstart1);
            Thread thread2 = new Thread(threadstart2);

            
            thread2.Start();
            thread1.Start();
            Console.WriteLine("Aborting Child thread1");
            thread1.Abort();
            Console.ReadLine();
            #endregion

            #region Reflections....
            //Loading assembly for the class library on run time using System.Reflection
            Assembly myasembly = Assembly.LoadFile(@"C:\Users\Praveen\Documents\visual studio 2015\Projects\PrepCode\PrepCode\bin\Debug\ReflectionsLibrary.dll");
            
            //Getting  class Type ReflectionsDemo
            Type type = myasembly.GetType("ReflectionsLibrary.ReflectionsDemo");
            

            //Creating Instance of the class using Activator method
            Object objInstance = Activator.CreateInstance(type);
            //Getting Method Info
            MethodInfo info = type.GetMethod("AddMethod");

            //Invoking Method of the Class
            object val = info.Invoke(objInstance, new Object[] {10,20 });

            #endregion

            

            #region dependency Injection implementation...

            // Want to send Email assign the object of Email class to Interface.
            INotificationSender sendEmail = new Email();

            //Inject this object into the Notification class constructor.
            //Now the control lies with the calling class in terms that which notifcation method to call on
            SendNotification notification = new SendNotification(sendEmail);
            notification.Notification("Hello Everyone.Email Sent");

            // Want to send SMS assign the object of SMS class to Interface.
            INotificationSender sendSMS = new SMS();

            //Inject this object into the Notification class constructor.
            //Now the control lies with the calling class in terms that which notifcation method to call on
            SendNotification notificationSMS = new SendNotification(sendSMS);
            notificationSMS.Notification("Hello Everyone.SMS sent");
            #endregion

            

            #region delegate implementation....
            //delegate Demo
            DelegateDemo dd = new DelegateDemo();
            DelegateDemo.Logger myLogger = new DelegateDemo.Logger(Program.logMethod);
            //In multicast Delegate we can assign multiple methods to a delegate whenever the deletage is called all these method will be called
            myLogger += Program.logMethod;
            myLogger += Program.logMethod;
            dd.ProcessLog(myLogger);
            #endregion

            
            Console.ReadLine();
        }

        public static void logMethod(string a)
        {
            
            Console.WriteLine("Log Saved Successfully with Exception" + a);
            Console.WriteLine("I am also used for multithreading");
        }

        public static void StartChildThread1()
        {
            Thread.Sleep(5000);

            Console.WriteLine("Child Thread1 message logged after Thread2 as it gone for sleep ");
            Console.ReadLine();
            
        }

        public static void StartChildThread2()
        {
            Console.WriteLine("Child Thread2 Started");
        }

        #region FibonacciRecursion....
        public static int FibonacciRecursion(int counter)
        {
            if (counter==0)
            {
                return 0;
            }
            if (counter==1)
            {
                return 1;
            }
            return FibonacciRecursion(counter - 2) + FibonacciRecursion(counter - 1);
        }
        #endregion

        #region string reversal....
        public static void StringReversal(string str)
        {
            string revString = "";
            Char[] strArray = str.ToCharArray();
            int len = str.Length - 1;
            while (len >= 0)
            {
                revString = revString + strArray[len];
                len--;
            }

            Console.WriteLine(revString);
        }
        #endregion

        #region panagram.....
        public static bool Panagram(string str)
        {
            return str.ToLower().Where(c => Char.IsLetter(c)).GroupBy(c => c).Count() == 26;
        }
        #endregion

        #region Awesome Sequence....
        public void AwesomeSequence()
        {
            const int MODULUS = 1000000007;
            var k = int.Parse(Console.ReadLine().Trim());
            var a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

            for (var q = int.Parse(Console.ReadLine().Trim()); q-- > 0;)
            {
                var m = long.Parse(Console.ReadLine().Trim());
                var r = 0L;

                for (var p = 1L << 49; m != 0; m -= p)
                {
                    r = (r + a[m % k]) % MODULUS;

                    while (p > m)
                        p >>= 1;
                }

                Console.WriteLine((r + 1) % MODULUS);
            }
        }
        #endregion

        #region LCM Code

        public static void LCM()
        {
            int t = int.Parse(Console.ReadLine());
            while (t>0)
            {
                string[] temp = Console.ReadLine().Split(' ');
                long a = int.Parse(temp[0]);
                long b = int.Parse(temp[1]);
                long sum= 0;
                for (long i = 1; i <= a; i++)
                {
                    for (long j = 1; j <= b; j++)
                    {
                        bool flag = true;
                        long min = i > j ? j : i;
                        for (long k = 2; k <= Math.Sqrt(min); k++)
                        {
                            if (i % (k * k) == 0 && j % (k * k) == 0)
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag)
                        {
                            sum += lcm(i, j);
                        }
                    }
                }
                Console.WriteLine((long)(sum % Math.Pow(2, 30)));
                t--;
            }

            
            //System.out.println((long)(sum % Math.pow(2, 30)));
            
        }

    

      public  static long lcm(long a, long b)
        {
            if (a > b)
            {
                return (a * b) / gcd(a, b);
            }
            else
            {
                return (a * b) / gcd(b, a);
            }
        }

        static long gcd(long a, long b)
        {
            if (a % b == 0)
            {
                return b;
            }
            return gcd(b, a % b);
        }

        #endregion

        #region plaindrome Check
        public static bool CheckPalindrome(string myString)
        {
            int length = myString.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (myString[i] != myString[length - i - 1])
                    return false;
            }
            return true;
        }
        #endregion

        #region anagram Check..

        public static bool Anagram(string str1,string str2)
        {
            bool result = true;

            var r = (from a in str1.ToLower().ToCharArray() group a by a into c orderby c.Key select new {
                key=c.Key,
                count= c.Count()

            } ).ToList();
            var s = (from a in str2.ToLower().ToCharArray() group a by a into c orderby c.Key
                     select new
                     {
                         key = c.Key,
                         count = c.Count()

                     }).ToList();
            
            if(r.Count == s.Count)
            {
                for (int i = 0; i < r.Count -1; i++)
                {
                   if( r[i].key !=s[i].key || r[i].count != s[i].count)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
        #endregion
    }
}
