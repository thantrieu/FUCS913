using System.Collections.Generic;
using System.Data.SqlClient;

namespace L913Exercises2
{
    interface IIOController
    {
        // lưu danh sách sinh viên vào csdl
        void SaveStudentsData(List<Student> students);
        // lưu danh sách môn học vào csdl
        void SaveSubjectsData(List<Subject> subjects);
        // lưu danh sách đăng ký vào csdl
        void SaveRegistersData(List<Register> registers);
        // đọc ra danh sách sinh viên từ csdl
        List<Student> GetStudents();
        // đọc ra danh sách môn học từ csdl
        List<Subject> GetSubjects();
        // đọc ra danh sách đăng ký từ csdl
        List<Register> GetRegisters();
        // tạo kết nối đến cơ sở dữ liệu
        SqlConnection CreateConnection();
        // thêm một sinh viên mới vào csdl
        void InsertStudent(Student student);
        // thêm một môn học mới vào csdl
        void InsertSubject(Subject subject);
        // thêm một bản đăng ký mới vào csdl
        void InsertRegister(Register register);
        // cập nhật bản đăng ký
        void UpdateRegister(Register register);
        // xóa bản đăng ký
        void DeleteRegister(Register register);
        // cập nhật môn học
        void UpdateSubject(Subject subject);
        // xóa môn học
        void DeleteSubject(Subject subject);
        // cập nhật thông tin sinh viên
        void UpdateStudent(Register register);
        // xóa thông tin sinh viên
        void DeleteStudent(Student student);
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
        void UpdateRegisterAutoId();
        // cập nhật mã tự tăng của môn học
        void UpdateSubjectAutoId();
    }
}
