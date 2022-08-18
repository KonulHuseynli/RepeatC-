using System;
using System.Collections.Generic;
using ConsoleApp1.Helpers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course("CodeAcademy");


            while (true)
            {

                Helper.Print("1.Add Group 2.View the groups 3.Add student to the group  4. View the students  5.Searching for groups 6.Remove the students from the group 7.Edit the student", ConsoleColor.Yellow);
                string number = Console.ReadLine();
                bool isInt = int.TryParse(number, out int menu);
                switch (menu)
                {
                    case 1:
                        #region Group
                        grname:
                        Helper.Print("Please enter the new group name which you are created:", ConsoleColor.Blue);
                        string groupname = Console.ReadLine();

                        foreach (var item in course.groups)
                        {
                            if (item.Name == groupname)
                            {
                                Helper.Print("This group is available please neter the neü name!!!", ConsoleColor.Red);
                                goto grname;
                            }
                        }
                        Group group = new Group(groupname);
                        course.groups.Add(group);
                        Helper.Print($"{groupname} Group be created ", ConsoleColor.Green);
                        break;
                    #endregion
                    case 2:
                        #region Viewthegroup
                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Created group is not available,Please created nw group", ConsoleColor.Red);
                        }
                        foreach (var item in course.groups)
                        {
                            Helper.Print($"{item.Name}", ConsoleColor.Yellow);
                        }
                        break;
                    #endregion
                    case 3:
                        #region Addthestudent
                        if (course.groups.Count == 0)
                        {
                            Helper.Print("This group does not exist,Please created new group", ConsoleColor.Red);
                            goto case 1;
                        }
                        Helper.Print("Group list", ConsoleColor.Magenta);
                        foreach (var item in course.groups)
                        {
                            Helper.Print($"{item.Name}", ConsoleColor.Yellow);
                        }
                        inputGroup:
                        Helper.Print("Please choose the group which is add the stydent", ConsoleColor.Blue);
                        string ExistGroupName = Console.ReadLine();
                        foreach (var item in course.groups)
                        {
                            
                            if (item.Name == ExistGroupName)
                            {
                                Helper.Print("Include in dtudent name", ConsoleColor.Green);
                                string name = Console.ReadLine();
                                Helper.Print("Include in student surname", ConsoleColor.Green);
                                string surname = Console.ReadLine();
                                AGE:
                                Helper.Print("Include in studetn age", ConsoleColor.Green);
                                string _age = Console.ReadLine();
                                bool isAge = int.TryParse(_age, out int age);
                                if (!isAge)
                                {
                                    Helper.Print("Please include in correctly", ConsoleColor.Red);
                                    goto AGE;
                                }
                                GRADE:
                                Helper.Print("Include in student point", ConsoleColor.Green);
                                string _gr = Console.ReadLine();
                                bool isGrade = int.TryParse(_gr, out int grade);
                                if (!isGrade)
                                {
                                    Helper.Print("Please include in correctly", ConsoleColor.Red);
                                    goto GRADE;
                                }

                                Student student = new Student(name, surname, age, grade);
                                item.studens.Add(student);
                                Helper.Print($"{name} add the group", ConsoleColor.Magenta);
                            }
                        }
                        break;
                    #endregion
                    case 4:
                        #region ViewtheStudent
                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please you are create the group", ConsoleColor.Red);
                            goto case 1;
                        }

                        foreach (var item in course.groups)
                        {
                            Helper.Print($"{item.Name}", ConsoleColor.Yellow);
                        }
                        //grpName:
                        Helper.Print("Please include in the group name which is you are seeing:", ConsoleColor.Green);
                        string grpn = Console.ReadLine();

                        foreach (var item in course.groups)
                        {

                            if (grpn == item.Name)
                            {
                                if (item.studens.Count == 0)
                                {
                                    Helper.Print("Student doesnt exit this group", ConsoleColor.Red);
                                }
                                else
                                {
                                    foreach (var item1 in item.studens)
                                    {
                                        Helper.Print($" Name-{item1.Name}  Surname-{item1.Surname} Age-{item1.Age} Point-{item1.Grade}", ConsoleColor.Yellow);
                                    }
                                }
                            }
                            
                        }

                        break;
                    #endregion
                    case 5:
                        #region SearchStudent

                        Helper.Print("Please enter the st name which is youre searching", ConsoleColor.Green);
                        string stn = Console.ReadLine();

                        foreach (var item in course.groups)
                        {
                            foreach (var item1 in item.studens)
                            {
                                if (stn.ToUpper() == item1.Name.ToUpper())
                                {
                                    Helper.Print($"{item1.Id}  {item1.Name} {item1.Surname}", ConsoleColor.Yellow);
                                }
                                
                            }
                        }

                        break;
                    #endregion
                    case 6:
                        #region deletestudent
                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Pleas create the group", ConsoleColor.Red);
                            goto case 1;
                        }
                        foreach (var item in course.groups)
                        {
                            Helper.Print($"{item.Name}", ConsoleColor.Yellow);
                        }
                        Helper.Print("which group that delete the student", ConsoleColor.blue);
                        string dlt = Console.ReadLine();
                        foreach (var item in course.groups)
                        {
                            if (dlt == item.Name)
                            {
                                foreach (var item1 in item.studens)
                                {
                                    Helper.Print($"Id:{item1.Id} AD:{item1.Name}", ConsoleColor.Yellow);
                                }
                            }
                        }
                        Id:
                        Helper.Print("Please enter the ID", ConsoleColor.Green);

                        string idd = Console.ReadLine();
                        bool isid = int.TryParse(idd, out int id_);
                        if (!isid)
                        {
                            Console.WriteLine("Please include in correctly");
                            goto Id;
                        }
                        foreach (var item in course.groups)
                        {
                            foreach (var item1 in item.studens)
                            {
                                if (item1.Id == id_)
                                {
                                    item.studens.Remove(item1);
                                    Helper.Print($"{item1.Name} Student be deleted", ConsoleColor.Yellow);
                                    break;
                                }
                            }
                        }
                        break;
                    #endregion
                    case 7:
                        #region editstudent
                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please create group", ConsoleColor.Red);
                            goto case 1;
                        }
                        foreach (var item in course.groups)
                        {
                            Helper.Print($"{item.Name}", ConsoleColor.Yellow);
                        }
                        Helper.Print("Which group that you are edit the student?", ConsoleColor.Green);
                        string edt = Console.ReadLine();
                        foreach (var item in course.groups)
                        {

                            if (edt == item.Name)
                            {
                                if (item.studens.Count == 0)
                                {
                                    Helper.Print("Doesnot exit student!,Please add the st", ConsoleColor.Red);
                                    goto case 3;
                                }
                                else
                                {
                                    foreach (var item1 in item.studens)
                                    {
                                        Helper.Print($"Id:{item1.Id} AD:{item1.Name}", ConsoleColor.Yellow);
                                    }
                                }

                            }
                        }
                        idd:
                        Helper.Print("Enter the id", ConsoleColor.Green);
                        string _idd = Console.ReadLine();
                        bool isidd = int.TryParse(_idd, out int idd_);
                        if (!isidd)
                        {
                            Console.WriteLine("Include in correctly");
                            goto idd;
                        }
                        foreach (var item in course.groups)
                        {
                            foreach (var item1 in item.studens)
                            {
                                if (item1.Id == idd_)
                                {
                                    Helper.Print("New name ", ConsoleColor.Green);
                                    string newname = Console.ReadLine();
                                    item1.Name = newname;
                                    Helper.Print("new surname ", ConsoleColor.Green);
                                    string nsrname = Console.ReadLine();
                                    item1.Surname = nsrname;
                                    AGE:
                                    Helper.Print("new age", ConsoleColor.Green);
                                    string _age = Console.ReadLine();
                                    bool isAge = int.TryParse(_age, out int age);
                                    if (!isAge)
                                    {
                                        Helper.Print("include in correctlyn", ConsoleColor.Red);
                                        goto AGE;
                                    }
                                    item1.Age = age;
                                    GRADE:
                                    Helper.Print("new point", ConsoleColor.Green);
                                    string _gr = Console.ReadLine();
                                    bool isGrade = int.TryParse(_gr, out int grade);
                                    if (!isGrade)
                                    {
                                        Helper.Print("include in correctly", ConsoleColor.Red);
                                        goto GRADE;
                                    }
                                    item1.Grade = grade;
                                    Helper.Print($" Edit the student.succesfully", ConsoleColor.Green);
                                    break;
                                }
                                
                            }
                        }
                        break;
                    #endregion
                    default:
                        break;
                }


            }

        }
    }
}
