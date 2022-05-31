using System.Collections.Generic;
using System.Data.SqlClient;

namespace L913Exercises2
{
    interface IIOController
    {
        // lưu danh sách sinh viên vào csdl
        bool SaveStudentsData(List<Student> students);
        // lưu danh sách môn học vào csdl
        bool SaveSubjectsData(List<Subject> subjects);
        // lưu danh sách đăng ký vào csdl
        bool SaveRegistersData(List<Register> registers);
        // đọc ra danh sách sinh viên từ csdl
        List<Student> GetStudents();
        // đọc ra danh sách môn học từ csdl
        List<Subject> GetSubjects();
        // đọc ra danh sách đăng ký từ csdl
        List<Register> GetRegisters();
        // tạo kết nối đến cơ sở dữ liệu
        SqlConnection CreateConnection();
        // thêm một sinh viên mới vào csdl
        bool InsertStudent(Student student);
        // thêm một môn học mới vào csdl
        bool InsertSubject(Subject subject);
        // thêm một bản đăng ký mới vào csdl
        bool InsertRegister(Register register);
        // cập nhật bản đăng ký
        bool UpdateRegister(Register register);
        // xóa bản đăng ký
        bool DeleteRegister(Register register);
        // cập nhật môn học
        bool UpdateSubject(Subject subject);
        // xóa môn học
        bool DeleteSubject(Subject subject);
        // cập nhật thông tin sinh viên
        bool UpdateStudent(Student student);
        // xóa thông tin sinh viên
        bool DeleteStudent(Student student);
        // tìm sinh viên theo tên gần đúng
        List<Student> FindStudentByName(string name);
        // tìm môn học theo tên gần đúng
        List<Subject> FindSubjectsByName(string name);
        // tìm bản đăng ký theo môn học
        List<Register> FindRegisterBySubject(int subjectId);
        // tìm bản đăng ký theo mã sinh viên
        List<Register> FindRegisterByStudent(string studentId);
        // tìm sinh viên đăng ký nhiều môn học nhất
        List<Student> FindMostRegistedStudent();
        // tìm môn học được đăng ký nhiều nhất
        List<Subject> FindMostRegistedSubject();
        // tìm sinh viên đăng ký sớm nhất
        List<Student> FindEarliestRegistedStudent();
        // tìm sinh viên đăng ký muộn nhất
        List<Student> FindLatestRegistedStudent();
        // cập nhật mã tự tăng của bản đăng ký
        bool UpdateRegisterAutoId();
        // cập nhật mã tự tăng của môn học
        bool UpdateSubjectAutoId();
    }
}
