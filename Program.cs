using System;
using System.Collections;
using System.Collections.Generic;
 
namespace Practical_Assignment_OOP_4_Random
{
  //Create a new class with the main method in it.
  class Program
  {
    //a. Create randomly seven Officers as the objects, two Districts as the objects and three Lawyers as the objects.
    static Random random = new Random(); 
    /*I didn't really cover the static Random random = new Random() being set up on the Program class level.
     You could move it into the Main(String[]) method, removing the static keyword from the variable declaration.
     The reason why I used static on the class-level variable is that it is not linked to a specific object/instance of Program class, and should be usable in static methods (such as the Main we have) inside that class.*/
    static void Main(string[] args)
      {
       string[] names = { "Jane", "John", "Steven", "Stella", "Peter", "Anna", "Rudolph", "Bruno", "Erica" };
       string[] surnames = { "Doe", "Johnson", "Ericson" };
            
       Officer[] officers = new Officer[7];
         for (int i = 0; i < officers.Length; i++)
          {
            string name = names[random.Next(names.Length)];
            string surname = surnames[random.Next(surnames.Length)];
            int id = 1000 + random.Next(1000);
            int crimesSolved = random.Next(50);
            officers[i] = new Officer(name, surname, id, crimesSolved);
           }
            District district1 = new District();
            District district2 = new District("West", "Riga", 1002, new Officer[0]);
            Lawyer[] lawyers = new Lawyer[3];
            for (int i = 0; i < lawyers.Length; i++)
            {
              string name = names[random.Next(names.Length)];
              string surname = surnames[random.Next(surnames.Length)];
              int id = 1000 + random.Next(1000);
              int crimesHelpedSolve = random.Next(50);
              lawyers[i] = new Lawyer(name, surname, id, crimesHelpedSolve);
            }
      
       //b. Add four Officers and two Lawyers in the first District 
       //and others Officers and Lawyers in the second District.
       for (int i = 0; i < officers.Length; i++)
            {
                District district;
                if (i < 4) { district = district1; }
                else { district = district2; }
                district.AddNewPerson(officers[i]);
            }
            for (int i = 0; i < lawyers.Length; i++)
            {
                District district;
                if (i < 2) { district = district1; }
                else { district = district2; }
                district.AddNewPerson(lawyers[i]);
            }
       
       //c. Print out all information about each District. 
       Console.WriteLine(district1);
       Console.WriteLine(district2);
      
       //d-e Edit the method calculateAvgLevelInDistrict() that only all Officers’ levels 
       //are summarized and divided by the amount of the Officers (not Lawyers) in this District.
       // Code in District.cs
       float avg1 = district1.CalculateAvgLevelInDistrict();
       float avg2 = district2.CalculateAvgLevelInDistrict();
       Console.WriteLine($"District 1 average: {avg1.ToString("0.###")} | District 2 average: {avg2.ToString("0.###")}");

       //f. Create an arraylist for the Districts storage. Put both Districts in the Arraylist. 
         ArrayList districts = new ArrayList();
         districts.Add(district1);
         districts.Add(district2);

        //g. Find out which District is with the highest number of Persons.
        int largestCount = 0;
        List<District> largest = new List<District>();
        foreach (District current in districts)
        {
            int currentCount = current.GetPersonsInTheDistrict().Length;
            if (currentCount > largestCount)
            {
              largest.Clear();
              largestCount = currentCount;
              largest.Add(current);
            }
            else if (currentCount == largestCount)
            {
              largest.Add(current);
            }
        }
            foreach (District district in largest)
            {
              Console.WriteLine($"The highest number of Persons in District are: {largestCount}.");
            }
        }
      }
  }
