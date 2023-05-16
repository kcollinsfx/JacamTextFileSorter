using System;
using System.IO;
using System.Text;
using System.Linq;

class Program {
  public static void Main (string[] args) {
    // Step-1: Create an empty array to hold the lines
    string[] lines0 = default; 

    // Step-2: Open the .txt file and place the values inside the lines array in step 1
    if (File.Exists("file.txt")){
      lines0 = File.ReadAllLines(@"file.txt", Encoding.UTF8);
    }

    // Step_3: Create a new lines array to sort the lines array by 
    // first by the last digit (ie number)
    // then by the first two letters
    // We are using Linq methods here the OrderBy and SortBy
    string[] lines1 = lines0.OrderBy(x => x[3]).ThenBy(x=>x).ToArray();

    // Step_4: Print the array and see how it looks
    // Step_5: Create a new file and dump the data in lines1 array
    using (StreamWriter writer = new StreamWriter("sortedfile.txt")) {
      for (int i = 0; i < lines1.Length; i++){
      writer.WriteLine(lines1[i]);
      }

    }

    // Step_6: Open the sortedfile.txt file
    if (File.Exists("sortedfile.txt")){
      StreamReader fs = new StreamReader("sortedfile.txt");
      while (fs.ReadLine() != null){
        Console.WriteLine(fs.ReadLine());
      }
    }
  }
}