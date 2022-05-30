using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace L913Exercises2
{
    class IOController : IIOController
    {
        public List<Register> GetRegisters()
        {
            List<Register> registers = new List<Register>();
            var conn = CreateConnection();
            conn.Open();
            var sql = "SELECT * FROM Register";
            var subjects = GetSubjects();
            var students = GetStudents();
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var studentId = reader.GetString(1);
                        var subjectId = reader.GetInt32(2);
                        var student = FindStudentById(students, studentId);
                        var subject = FindSubjectById(subjects, subjectId);
                        var regTime = reader.GetDateTime(3);
                        var register = new Register(id, student, subject, regTime);
                        registers.Add(register);
                    }
                }
            }
            conn.Close();
            return registers;
        }

        private Student FindStudentById(List<Student> students, string studentId)
        {
            var index = students.IndexOf(new Student(studentId));
            if (index == -1)
            {
                return null;
            }
            return students[index];
        }

        private Subject FindSubjectById(List<Subject> subjects, int subjectId)
        {
            var index = subjects.IndexOf(new Subject(subjectId));
            if (index == -1)
            {
                return null;
            }
            return subjects[index];
        }

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            var conn = CreateConnection();
            conn.Open();
            var sql = "SELECT * FROM Student";
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var studentId = reader.GetString(0);
                        var fullName = reader.GetString(1);
                        var birthDate = reader.GetDateTime(2);
                        var phoneNumber = reader.GetString(3);
                        var email = reader.GetString(4);
                        var major = reader.GetString(5);
                        Student student = new Student(studentId, fullName,
                            birthDate, email, phoneNumber, major);
                        students.Add(student);
                    }
                }
            }
            conn.Close();
            return students;
        }

        public void UpdateRegisterAutoId()
        {
            var maxId = 10000 - 1;

            var conn = CreateConnection();
            conn.Open();
            var sql = "SELECT MAX(RegisterId) FROM Register";
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        maxId = reader.GetInt32(0);
                    }
                }
            }
            Register.SetAutoId(maxId + 1);
            conn.Close();
        }

        public void UpdateSubjectAutoId()
        {
            var maxId = 11001 - 1;

            var conn = CreateConnection();
            conn.Open();
            var sql = "SELECT MAX(SubjectId) FROM Subject";
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        maxId = reader.GetInt32(0);
                    }
                }
            }
            Subject.SetAutoId(maxId + 1);
            conn.Close();
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjects = new List<Subject>();
            var conn = CreateConnection();
            conn.Open();
            var sql = "SELECT * FROM Subject";
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var subjectId = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var credit = reader.GetInt32(2);
                        var numOfLesson = reader.GetInt32(3);
                        Subject subject = new Subject(subjectId, name, credit, numOfLesson);
                        subjects.Add(subject);
                    }
                }
            }
            conn.Close();
            return subjects;
        }

        public void SaveRegistersData(List<Register> registers)
        {
            var conn = CreateConnection();
            conn.Open();
            var sql = "INSERT INTO Register(StudentId, SubjectId, RegisterTime) " +
                "VALUES(@studentId, @subjectId, @regTime)";
            var command = new SqlCommand(sql, conn);
            command.Parameters.Add("@studentId", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@subjectId", SqlDbType.Int);
            command.Parameters.Add("@regTime", SqlDbType.DateTime);
            try
            {
                foreach (var item in registers)
                {
                    command.Parameters[0].Value = item.Student.StudentId;
                    command.Parameters[1].Value = item.Subject.SubjectId;
                    command.Parameters[2].Value = item.RegisterTime;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("==> Lỗi ghi dữ liệu vào CSDL. <==");
                Console.WriteLine(e);
            }
            conn.Close();
        }

        public void SaveStudentsData(List<Student> students)
        {
            var conn = CreateConnection();
            conn.Open();
            var sql = "INSERT INTO Student(StudentId, FullName, BirthDate, PhoneNumber, Email, Major) " +
                "VALUES(@id, @name, @dob, @phone, @mail, @major)";
            var command = new SqlCommand(sql, conn);
            command.Parameters.Add("@id", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@dob", SqlDbType.DateTime);
            command.Parameters.Add("@phone", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@mail", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@major", SqlDbType.NVarChar, 50);
            try
            {
                foreach (var item in students)
                {
                    command.Parameters[0].Value = item.StudentId;
                    command.Parameters[1].Value = item.FullName.ToString();
                    command.Parameters[2].Value = item.BirthDate;
                    command.Parameters[3].Value = item.PhoneNumber;
                    command.Parameters[4].Value = item.Email;
                    command.Parameters[5].Value = item.Major;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("==> Lỗi ghi dữ liệu vào CSDL. <==");
                Console.WriteLine(e);
            }
            conn.Close();
        }

        public void SaveSubjectsData(List<Subject> subjects)
        {
            var conn = CreateConnection();
            conn.Open();
            var sql = "INSERT INTO Subject(Name, Credit, NumOfLesson) " +
                "VALUES(@name, @credit, @lesson)";
            var command = new SqlCommand(sql, conn);
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@credit", SqlDbType.Int);
            command.Parameters.Add("@lesson", SqlDbType.Int);
            try
            {
                foreach (var item in subjects)
                {
                    command.Parameters[0].Value = item.Name;
                    command.Parameters[1].Value = item.Credit;
                    command.Parameters[2].Value = item.NumOfLesson;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("==> Lỗi ghi dữ liệu vào CSDL. <==");
                Console.WriteLine(e);
            }
            conn.Close();
        }

        public SqlConnection CreateConnection()
        {
            var userName = "sa";
            var password = "123";
            var catalog = "CSDL Exercises2";
            var server = "BraniumAcademy";
            var connString = $"Data Source={server};" +
                $"Initial Catalog={catalog};" +
                $"User ID={userName};" +
                $"Password={password}";
            return new SqlConnection(connString);
        }

        public void InsertStudent(Student student)
        {
            var conn = CreateConnection();
            conn.Open();
            var sql = "INSERT INTO Student(StudentId, FullName, BirthDate, PhoneNumber, Email, Major) " +
                "VALUES(@id, @name, @dob, @phone, @mail, @major)";
            var command = new SqlCommand(sql, conn);
            command.Parameters.Add("@id", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@dob", SqlDbType.DateTime);
            command.Parameters.Add("@phone", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@mail", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@major", SqlDbType.NVarChar, 50);
            try
            {
                command.Parameters[0].Value = student.StudentId;
                command.Parameters[1].Value = student.FullName.ToString();
                command.Parameters[2].Value = student.BirthDate;
                command.Parameters[3].Value = student.PhoneNumber;
                command.Parameters[4].Value = student.Email;
                command.Parameters[5].Value = student.Major;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("==> Lỗi ghi dữ liệu vào CSDL. <==");
                Console.WriteLine(e);
            }
            conn.Close();
        }

        public void InsertSubject(Subject subject)
        {
            var conn = CreateConnection();
            conn.Open();
            var sql = "INSERT INTO Subject(Name, Credit, NumOfLesson) " +
                "VALUES(@name, @credit, @lesson)";
            var command = new SqlCommand(sql, conn);
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@credit", SqlDbType.Int);
            command.Parameters.Add("@lesson", SqlDbType.Int);
            try
            {
                command.Parameters[0].Value = subject.Name;
                command.Parameters[1].Value = subject.Credit;
                command.Parameters[2].Value = subject.NumOfLesson;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("==> Lỗi ghi dữ liệu vào CSDL. <==");
                Console.WriteLine(e);
            }
            conn.Close();
        }

        public void InsertRegister(Register register)
        {
            var conn = CreateConnection();
            conn.Open();
            var sql = "INSERT INTO Register(StudentId, SubjectId, RegisterTime) " +
                "VALUES(@studentId, @subjectId, @regTime)";
            var command = new SqlCommand(sql, conn);
            command.Parameters.Add("@studentId", SqlDbType.NVarChar, 50);
            command.Parameters.Add("@subjectId", SqlDbType.Int);
            command.Parameters.Add("@regTime", SqlDbType.DateTime);
            try
            {
                command.Parameters[0].Value = register.Student.StudentId;
                command.Parameters[1].Value = register.Subject.SubjectId;
                command.Parameters[2].Value = register.RegisterTime;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("==> Lỗi ghi dữ liệu vào CSDL. <==");
                Console.WriteLine(e);
            }
            conn.Close();
        }

        public void UpdateRegister(Register register)
        {
            throw new NotImplementedException();
        }

        public void DeleteRegister(Register register)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Register register)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Student> FindStudentByName(string key)
        {
            List<Student> students = new List<Student>();
            var conn = CreateConnection();
            conn.Open();
            var sql = $"SELECT * FROM Student WHERE FullName LIKE '%{key}%'";
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var studentId = reader.GetString(0);
                        var fullName = reader.GetString(1);
                        var birthDate = reader.GetDateTime(2);
                        var phoneNumber = reader.GetString(3);
                        var email = reader.GetString(4);
                        var major = reader.GetString(5);
                        Student student = new Student(studentId, fullName,
                            birthDate, email, phoneNumber, major);
                        students.Add(student);
                    }
                }
            }
            conn.Close();
            return students;
        }

        public List<Subject> FindSubjectsByName(string key)
        {
            List<Subject> subjects = new List<Subject>();
            var conn = CreateConnection();
            conn.Open();
            var sql = $"SELECT * FROM Subject WHERE Name LIKE '%{key}%'";
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var subjectId = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var credit = reader.GetInt32(2);
                        var numOfLesson = reader.GetInt32(3);
                        Subject subject = new Subject(subjectId, name, credit, numOfLesson);
                        subjects.Add(subject);
                    }
                }
            }
            conn.Close();
            return subjects;
        }

        public List<Register> FindRegisterBySubject(int key)
        {
            List<Register> registers = new List<Register>();
            var conn = CreateConnection();
            conn.Open();
            var sql = $"SELECT * FROM Register WHERE SubjectId = {key}";
            var subjects = GetSubjects();
            var students = GetStudents();
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var studentId = reader.GetString(1);
                        var subjectId = reader.GetInt32(2);
                        var student = FindStudentById(students, studentId);
                        var subject = FindSubjectById(subjects, subjectId);
                        var regTime = reader.GetDateTime(3);
                        var register = new Register(id, student, subject, regTime);
                        registers.Add(register);
                    }
                }
            }
            conn.Close();
            return registers;
        }

        public List<Register> FindRegisterByStudent(string key)
        {
            List<Register> registers = new List<Register>();
            var conn = CreateConnection();
            conn.Open();
            var sql = $"SELECT * FROM Register WHERE StudentId = '{key}'";
            var subjects = GetSubjects();
            var students = GetStudents();
            var command = new SqlCommand(sql, conn);
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var studentId = reader.GetString(1);
                        var subjectId = reader.GetInt32(2);
                        var student = FindStudentById(students, studentId);
                        var subject = FindSubjectById(subjects, subjectId);
                        var regTime = reader.GetDateTime(3);
                        var register = new Register(id, student, subject, regTime);
                        registers.Add(register);
                    }
                }
            }
            conn.Close();
            return registers;
        }

        public List<Student> FindMostRegistedStudent()
        {
            throw new NotImplementedException();
        }

        public List<Subject> FindMostRegistedSubject()
        {
            throw new NotImplementedException();
        }

        public List<Student> FindEarliestRegistedStudent()
        {
            throw new NotImplementedException();
        }

        public List<Student> FindLatestRegistedStudent()
        {
            throw new NotImplementedException();
        }
    }
}
