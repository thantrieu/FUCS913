﻿/// <summary>
/// <author>Branium Academy</author>
/// <version>2022.05.30</version>
/// <see cref="Trang chủ" href="https://braniumacademy.net"/>
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace L913Exercises2
{
    class Exercises2
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var studentUtils = new StudentManagermentUtils();
            List<Student> students = new List<Student>();
            List<Subject> subjects = new List<Subject>();
            List<Register> registers = new List<Register>();
            // đọc dữ liệu từ file
            studentUtils.GetStudents(students);
            studentUtils.GetSubjects(subjects);
            studentUtils.GetRegisters(registers);

            if(students.Count == 0 && subjects.Count == 0 && registers.Count == 0)
            {
                studentUtils.CreateFakeStudents(students);
                studentUtils.CreateFakeSubjects(subjects);
                studentUtils.CreateFakeRegisters(registers, students, subjects);
                studentUtils.SaveStudentsData(students);
                studentUtils.SaveSubjectsData(subjects);
                studentUtils.SaveRegistersData(registers);
            } else
            {
                studentUtils.UpdateRegisterAutoId();
                studentUtils.UpdateSubjectAutoId();
            }
            int choice;
            do
            {
                Console.WriteLine("=========================> CÁC CHỨC NĂNG <========================");
                Console.WriteLine("*    01. Thêm mới sinh viên vào danh sách sinh viên.             *");
                Console.WriteLine("*    02. Thêm mới môn học vào danh sách môn học.                 *");
                Console.WriteLine("*    03. Thêm mới bản đăng ký môn học vào danh sách đăng ký.     *");
                Console.WriteLine("*    04. Hiển thị danh sách sinh viên ra màn hình.               *");
                Console.WriteLine("*    05. Hiển thị danh sách môn học ra màn hình.                 *");
                Console.WriteLine("*    06. Hiển thị danh sách đăng ký ra màn hình.                 *");
                Console.WriteLine("*    07. Sắp xếp danh sách sinh viên theo tên a-z.               *");
                Console.WriteLine("*    08. Sắp xếp danh sách môn học theo số tín chỉ giảm dần.     *");
                Console.WriteLine("*    09. Sắp xếp danh sách đăng ký theo thời gian đăng ký.       *");
                Console.WriteLine("*    10. Sắp xếp danh sách đăng ký theo mã sinh viên.            *");
                Console.WriteLine("*    11. Sắp xếp danh sách đăng ký theo mã môn học.              *");
                Console.WriteLine("*    12. Tìm sinh viên theo tên gần đúng.                        *");
                Console.WriteLine("*    13. Tìm môn học theo tên gần đúng.                          *");
                Console.WriteLine("*    14. Tìm danh sách đăng ký theo mã môn học.                  *");
                Console.WriteLine("*    15. Tìm danh sách đăng ký theo mã sinh viên.                *");
                Console.WriteLine("*    16. Sửa tên sinh viên theo mã sinh viên cho trước.          *");
                Console.WriteLine("*    17. Sửa số tiết học theo mã môn học cho trước.              *");
                Console.WriteLine("*    18. Xóa môn học khỏi danh sách môn học.                     *");
                Console.WriteLine("*    19. Xóa sinh viên khỏi danh sách sinh viên.                 *");
                Console.WriteLine("*    20. Xóa bản đăng ký theo mã đăng ký.                        *");
                Console.WriteLine("*    21. Tìm môn học được đăng ký nhiều nhất.                    *");
                Console.WriteLine("*    22. Tìm sinh viên đăng ký nhiều môn học nhất.               *");
                Console.WriteLine("*    23. Tìm các sinh viên đăng ký môn học sớm nhất.             *");
                Console.WriteLine("*    24. Tìm các sinh viên đăng ký môn học muộn nhất.            *");
                Console.WriteLine("*    25. Thoát chương trình.                                     *");
                Console.WriteLine("==================================================================");
                Console.WriteLine("==> Xin mời bạn chọn chức năng:  ");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            var newStudent = studentUtils.CreateStudent(students);
                            if (newStudent != null)
                            {
                                students.Add(newStudent);
                                studentUtils.InsertNewStudentToDB(newStudent);
                                Console.WriteLine("==> Tạo sinh viên thành công!");
                            }
                            else
                            {
                                Console.WriteLine("==> Tạo mới sinh viên thất bại.");
                            }
                        } 
                        catch(InvalidStudentIdException e) { Console.WriteLine(e); }
                        catch (InvalidNameException e) { Console.WriteLine(e); }
                        catch (InvalidPhoneNumberException e) { Console.WriteLine(e); }
                        catch (InvalidEmailException e) { Console.WriteLine(e); }
                        catch (InvalidBirthDateException e) { Console.WriteLine(e); }
                        break;
                    case 2:
                        Subject newSubject = studentUtils.CreateSubject();
                        if (newSubject != null)
                        {
                            subjects.Add(newSubject);
                            studentUtils.InsertNewSubjectToDB(newSubject);
                            Console.WriteLine("==> Tạo môn học thành công. <==");
                        } 
                        else { 
                            Console.WriteLine("Tạo môn học thất bại."); 
                        }
                        break;
                    case 3:
                        if (students.Count > 0 && subjects.Count > 0)
                        {
                            Register newRegister = null;
                            try
                            {
                                newRegister = studentUtils.CreateRegister(students, subjects);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                                continue;
                            }
                            catch(InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                                continue;
                            }
                            if (newRegister != null && newRegister.Subject != null && newRegister.Student != null)
                            {
                                if (!studentUtils.Contains(registers, newRegister))
                                {
                                    registers.Add(newRegister);
                                    studentUtils.InsertNewRegisterToDB(newRegister);
                                    Console.WriteLine($"==> Sinh viên \"{newRegister.Student.StudentId}\" " +
                                        $"đăng ký thành công môn học \"{newRegister.Subject.SubjectId}\". <==");
                                }
                                else
                                {
                                    Console.WriteLine($"==> Lỗi. Sinh viên \"{newRegister.Student.StudentId}\" " +
                                        $"đã đăng ký môn học \"{newRegister.Subject.SubjectId}\" trước đó. <==");
                                }
                            }
                            else if (newRegister.Subject == null)
                            {
                                Console.WriteLine("==> Môn học cần đăng ký không tồn tại. <==");
                            }
                            else if (newRegister.Student == null)
                            {
                                Console.WriteLine("==> Sinh viên cần đăng ký không tồn tại. <==");
                            }
                        }
                        else
                        {
                            if (students.Count == 0)
                            {
                                Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                            }
                            if (subjects.Count == 0)
                            {
                                Console.WriteLine("==> Danh sách môn học rỗng <==");
                            }
                        }
                        break;
                    case 4:
                        if (students.Count > 0)
                        {
                            studentUtils.ShowStudents(students);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 5:
                        if (subjects.Count > 0)
                        {
                            studentUtils.ShowSubjects(subjects);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 6:
                        if (registers.Count > 0)
                        {
                            studentUtils.ShowRegisters(registers);
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 7:
                        if (students.Count > 0)
                        {
                            studentUtils.SortStudentByName(students);
                            Console.WriteLine("==> Sắp xếp hoàn tất. Chọn chức năng 4 để xem kết quả. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 8:
                        if (subjects.Count > 0)
                        {
                            studentUtils.SortSubjectByCredit(subjects);
                            Console.WriteLine("==> Sắp xếp hoàn tất. Chọn chức năng 5 để xem kết quả. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 9:
                        if (registers.Count > 0)
                        {
                            studentUtils.SortRegistersByRegTime(registers);
                            Console.WriteLine("==> Sắp xếp hoàn tất. Chọn chức năng 6 để xem kết quả. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 10:
                        if (registers.Count > 0)
                        {
                            studentUtils.SortRegistersByStudentId(registers);
                            Console.WriteLine("==> Sắp xếp hoàn tất. Chọn chức năng 6 để xem kết quả. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 11:
                        if (registers.Count > 0)
                        {
                            studentUtils.SortRegistersBySubjectId(registers);
                            Console.WriteLine("==> Sắp xếp hoàn tất. Chọn chức năng 6 để xem kết quả. <==");
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 12:
                        try
                        {
                            var searchedStudents = studentUtils.FindStudentsByName();
                            if (searchedStudents.Count > 0)
                            {
                                Console.WriteLine("==> Các sinh viên có tên cần tìm: <==");
                                studentUtils.ShowStudents(searchedStudents);
                            }
                            else
                            {
                                Console.WriteLine("==> Không có sinh viên nào thỏa mãn <==");
                            }
                        }
                        catch (InvalidNameException e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 13:
                        var seachedSubjects = studentUtils.FindSubjectsByName();
                        if(seachedSubjects.Count > 0)
                        {
                            Console.WriteLine("==> Các môn học có tên cần tìm: <==");
                            studentUtils.ShowSubjects(seachedSubjects);
                        } else
                        {
                            Console.WriteLine("==> Không có môn học nào thỏa mãn. <==");
                        }
                        break;
                    case 14:
                        if (registers.Count > 0)
                        {
                            List<Register> result = null;
                            try
                            {
                                result = studentUtils.FindRegisterBySubjectId();
                            }
                            catch (InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            if (result == null || result.Count == 0)
                            {
                                Console.WriteLine("==> Không có kết quả tìm kiếm. <==");
                            }
                            else
                            {
                                Console.WriteLine("==> Kết quả tìm kiếm theo mã môn học: <==");
                                studentUtils.ShowRegisters(result);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 15:
                        if (registers.Count > 0)
                        {
                            try
                            {
                                List<Register> result = null;
                                try
                                {
                                    result = studentUtils.FindRegisterByStudentId();
                                }
                                catch (InvalidStudentIdException e)
                                {
                                    Console.WriteLine(e);
                                }
                                if (result == null || result.Count == 0)
                                {
                                    Console.WriteLine("==> Không có kết quả tìm kiếm. <==");
                                }
                                else
                                {
                                    Console.WriteLine("==> Kết quả tìm kiếm theo mã sinh viên: <==");
                                    studentUtils.ShowRegisters(result);
                                }
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 16:
                        if (students.Count > 0)
                        {
                            try
                            {
                                studentUtils.UpdateStudentInfo(students);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                            catch(InvalidNameException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 17:
                        if (subjects.Count > 0)
                        {
                            try
                            {
                                studentUtils.UpdateSubjectLesson(subjects);
                            }
                            catch (InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 18:
                        if (subjects.Count > 0)
                        {
                            try
                            {
                                studentUtils.RemoveSubject(subjects);
                            }
                            catch (InvalidSubjectIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách môn học rỗng <==");
                        }
                        break;
                    case 19:
                        if (students.Count > 0)
                        {
                            try
                            {
                                studentUtils.RemoveStudent(students);
                            }
                            catch (InvalidStudentIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên rỗng <==");
                        }
                        break;
                    case 20:
                        if (registers.Count > 0)
                        {
                            try
                            {
                                studentUtils.RemoveRegister(registers);
                            }
                            catch (InvalidRegisterIdException e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách sinh viên đăng ký rỗng <==");
                        }
                        break;
                    case 21:
                        if(registers.Count > 0)
                        {
                            studentUtils.FindMostRegistedSubjects();
                        } else
                        {
                            Console.WriteLine("==> Danh sách đăng ký rỗng <==");
                        }
                        break;
                    case 22:
                        if (registers.Count > 0)
                        {
                            studentUtils.FindMostRegistedStudents();
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách đăng ký rỗng <==");
                        }
                        break;
                    case 23:
                        if (registers.Count > 0)
                        {
                            studentUtils.FindEarliestRegistedStudents();
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách đăng ký rỗng <==");
                        }
                        break;
                    case 24:
                        if (registers.Count > 0)
                        {
                            studentUtils.FindLatestRegistedStudents();
                        }
                        else
                        {
                            Console.WriteLine("==> Danh sách đăng ký rỗng <==");
                        }
                        break;
                    case 25:
                        Console.WriteLine("==> Cảm ơn quý khách đã sử dụng dịch vụ! <==");
                        break;
                    default:
                        Console.WriteLine("==> Sai chức năng. Vui lòng chọn lại! <==");
                        break;
                }
            } while (choice != 25);
        }
    }
}
