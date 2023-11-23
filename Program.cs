using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Operation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PersonCRUD personCRUD = new PersonCRUD();
            List<Person> person = null;
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("          CRUD OPERATION            ");
                Console.WriteLine("====================================");
                Console.WriteLine("  1.  CREATE                        ");
                Console.WriteLine("  2.  READ                          ");
                Console.WriteLine("  3.  UPDATE                        ");
                Console.WriteLine("  4.  DELETE                        ");
                Console.WriteLine("====================================\n");
                Console.Write("ENTER YOUR OPTION   ~  ");
                int Option = int.Parse(Console.ReadLine());
                

                switch (Option)
                {
                    case 1:
                        person = personCRUD.PersonInput();
                        break;

                    case 2:
                        personCRUD.Read(person);
                        break;

                    case 3:
                        personCRUD.Update();
                        break;

                    case 4:
                        personCRUD.Delete();
                        break;
                }

                if(Option > 4)
                {
                    Console.WriteLine("Invalid Option !");
                    break;
                }

                Console.ReadKey();
            }      
        }
    }
}
