using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRUD_Operation
{
    public class PersonCRUD 
    {
        List<Person> persons = new List<Person>();

        Person person = null,StorePerson = null;

        public List<Person> PersonInput()
        {
            try
            {
                Console.Write("Enter Number Of Person Detail to Add  ~  ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    Console.Clear();
                    person = new Person();

                    Console.Write("Enter Person ID           :  ");
                    person.Id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Person Name         :  ");
                    person.Name = Console.ReadLine();

                    Console.Write("Enter Person DOB          :  ");
                    string[] split = Console.ReadLine().Split('/');
                    person.Dob = new DateTime(int.Parse(split[2]), int.Parse(split[1]), int.Parse(split[0]));

                    Console.Write("Enter Person Age          :  ");
                    person.Age = int.Parse(Console.ReadLine());

                    Console.Write("Enter Person Blood Group  :  ");
                    person.BloodGroup = Console.ReadLine();

                    Console.Write("Enter Person PhoneNumber  :  ");
                    person.PhoneNumber = long.Parse(Console.ReadLine());

                    Console.Write("Enter Person DoorNo       :  ");
                    person.DoorNo = Console.ReadLine();

                    Console.Write("Enter Person Street       :  ");
                    person.Street = Console.ReadLine();

                    Console.Write("Enter Person City         :  ");
                    person.City = Console.ReadLine();

                    Create(person);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return persons;

        }

        public void Create(Person person)
        {
            try
            {
                persons.Add(person);
                Console.WriteLine("Person Record Created Successfully !");
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);

            }
        }

        public void Read(List<Person> person)
        {
            try
            {
                if(Check())
                {
                    Console.Clear();
                    int x = 1;
                    Console.WriteLine("======================================================================================================================");
                    Console.WriteLine($" {"SNO",2} {"ID",3} {"NAME",15}{"DOB",12} {"AGE",8} {"BGROUP",10} {"PHONENUMBER",15} {"DOORNO",10} {"STREET",15} {"CITY",15}   ");
                    Console.WriteLine("======================================================================================================================");
                    foreach (var value in person)
                    {
                        Console.WriteLine($"{x++,2}{value.Id,5} {value.Name,18} {value.Dob.ToString("dd-MM-yyyy"),13} {value.Age,4} {value.BloodGroup,10} {value.PhoneNumber,15} {value.DoorNo,10} {value.Street,15} {value.City,18}");
                    }
                }
                else
                { 
                    Console.WriteLine("List Is Empty !");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public int Change()
        {
            try
            {
                Console.WriteLine("==========================");
                Console.WriteLine("        UPDATE            ");
                Console.WriteLine("==========================");
                Console.WriteLine(" 1.  NAME                 ");
                Console.WriteLine(" 2.  DATE OF BIRTH        ");
                Console.WriteLine(" 3.  AGE                  ");
                Console.WriteLine(" 4.  BLOOD GROUP          ");
                Console.WriteLine(" 5.  PHONE NUMBER         ");
                Console.WriteLine(" 6.  DOOR NUMBER          ");
                Console.WriteLine(" 7.  STREET               ");
                Console.WriteLine(" 8.  CITY                 ");
                Console.WriteLine("==========================\n");
                Console.Write("Enter Your Option  ~  ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return int.Parse(Console.ReadLine());

        }
        public void Update()
        {
            Console.Clear();
            try
            {
                if(Check())
                {
                    Console.Write("Enter Person ID To Update  :  ");
                    int Id = int.Parse(Console.ReadLine());
                    if(Find(Id))
                    {
                        int No = Change();
                        switch (No)
                        {
                            case 1:
                                Console.Write("Enter New Name To Update  -  ");
                                StorePerson.Name = Console.ReadLine();
                                break;

                            case 2:
                                Console.Write("Enter New Date Of Birth To Update  -  ");
                                string[] split = Console.ReadLine().Split('/');
                                StorePerson.Dob = new DateTime(int.Parse(split[2]), int.Parse(split[1]), int.Parse(split[0]));
                                break;

                            case 3:
                                Console.Write("Enter New AGE To Update  -  ");
                                StorePerson.Age = int.Parse(Console.ReadLine());
                                break;

                            case 4:
                                Console.Write("Enter New Blood Group To Update  -  ");
                                StorePerson.BloodGroup = Console.ReadLine();
                                break;

                            case 5:
                                Console.Write("Enter New Phone Number To Update  -  ");
                                StorePerson.PhoneNumber = long.Parse(Console.ReadLine());
                                break;

                            case 6:
                                Console.Write("Enter New Door Number To Update  -  ");
                                StorePerson.DoorNo = Console.ReadLine();
                                break;

                            case 7:
                                Console.Write("Enter New Street Name To Update  -  ");
                                StorePerson.Street = Console.ReadLine();
                                break;

                            case 8:
                                Console.Write("Enter New City Name To Update  -  ");
                                StorePerson.City = Console.ReadLine();
                                break;

                            default:
                                Console.WriteLine("Invalid Option");
                                break;
                        }
                        ReadOnlyOne();
                    }
                    else
                    {
                        Console.WriteLine("No ID Found !");
                    }      
                        
                }
                else
                {
                    Console.WriteLine("List Is Empty !");
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        public void Delete()
        {
            if(Check())
            {
                Console.Write("Enter ID To Delete  The Record  -  ");
                int Id = int.Parse(Console.ReadLine());
                if (Find(Id))
                {
                    persons.Remove(StorePerson);
                    Console.WriteLine("Record Deleted Successfully !");
                }
                else
                {
                    Console.WriteLine("No ID Found !");
                }
            }
            else
            {
                Console.WriteLine("List Is Empty !");
            }

        }

        public void ReadOnlyOne()
        {
            Console.WriteLine("======================================================================================================================");
            Console.WriteLine($" {"ID",3} {"NAME",15}{"DOB",12} {"AGE",8} {"BGROUP",10} {"PHONENUMBER",15} {"DOORNO",10} {"STREET",15} {"CITY",15}   ");
            Console.WriteLine("======================================================================================================================");
            Console.WriteLine($"{StorePerson.Id,5} {StorePerson.Name,18} {StorePerson.Dob.ToString("dd-MM-yyyy"),13} {StorePerson.Age,4} {StorePerson.BloodGroup,10} {StorePerson.PhoneNumber,15} {StorePerson.DoorNo,10} {StorePerson.Street,15} {StorePerson.City,18}");

        }

        public bool Check()
        {
            if(persons!=null && persons.Count!=0)
            {
                return true;
            }
            return false;
        }

        public bool Find(int Id)
        {
            foreach (var value in persons)
            {
                if (value.Id == Id)
                {
                    StorePerson = value;
                    return true;
                }
            }
            return false;
        }
    }
}