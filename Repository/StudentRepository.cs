using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentManagement.Context;
using StudentManagement.Contracts;
using StudentManagement.Models;
using System.Data;

namespace StudentManagement.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly DapperContext _context;
        public StudentRepository(DapperContext context)
        {
            _context = context;
        }



        //get Students
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var query = "select * from students";
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>(query);
                return students.ToList();
            }
        }

        //get Student By Id
        public async Task<Student> GetStudentById(int id)
        {
            var query = "select * from students where id=@id";
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryFirstOrDefaultAsync<Student>(query , new {id});
                return students;
            }
        }



        //get Student Leave Percentage

        public async Task<Student> GetLeavePercentage(int id)
        {
            var query = "select fullname,(100-((absence*100)/22)) as absence from students where id=@id";
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryFirstOrDefaultAsync<Student>(query, new { id });
                return students;
            }
        }





        //get Student parent details

        public async Task<IEnumerable<Student>> GetParentDetails()
        {
            var query = "select fullname,parent_name,parent_contact from students";
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>(query);
                return students.ToList();
            }
        }



        // get student by grade wise

        public async Task<IEnumerable<Student>> GetStudentGradeWise()
        {
            var query = "select fullname,grade,semester,department from students order by grade";
            using (var connection = _context.CreateConnection())
            {
                var students = await connection.QueryAsync<Student>(query);
                return students.ToList();
            }
        }


        //delete student by id
        public async Task DeleteStudent(int id)
        {
            var query = "delete from students where id=@id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
                
            }
        }



        //update student details

        public async Task UpdateStudent(int id, Student student)
        {
            var query = "update students set fullname=@fullname,age=@age," +
                "gender=@gender,phonenumber=@phonenumber,emailaddress=@emailaddress," +
                "grade=@grade,absence=@absence,tuitionfee=@tuitionfee,department=@department," +
                "semester=@semester,parent_name=@parent_name,parent_contact=@parent_contact," +
                "username=@username,password=@password   where id=@id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);
            parameters.Add("fullname", student.fullname, DbType.String);
            parameters.Add("age", student.age, DbType.Int32);
            parameters.Add("gender", student.gender, DbType.String);
            parameters.Add("phonenumber", student.phonenumber, DbType.String);
            parameters.Add("emailaddress", student.emailaddress, DbType.String);
            parameters.Add("grade", student.grade, DbType.String);
            parameters.Add("absence", student.absence, DbType.Int32);
            parameters.Add("tuitionfee", student.tuitionfee, DbType.String);
            parameters.Add("department", student.department, DbType.String);
            parameters.Add("semester", student.semester, DbType.Int32);
            parameters.Add("parent_name", student.parent_name, DbType.String);
            parameters.Add("parent_contact", student.parent_contact, DbType.String);
            parameters.Add("username", student.username, DbType.String);
            parameters.Add("password", student.password, DbType.String);
            
            


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }





        //insert student
        public async Task<Student> AddStudent(Student student)
        {
            var procedureName = "insert_student";
            var parameters = new DynamicParameters();
            parameters.Add("fullname", student.fullname, DbType.String);
            parameters.Add("age", student.age, DbType.Int32);
            parameters.Add("gender", student.gender, DbType.String);
            parameters.Add("phonenumber", student.phonenumber, DbType.String);
            parameters.Add("emailaddress", student.emailaddress, DbType.String);
            parameters.Add("grade", student.grade, DbType.String);
            parameters.Add("absence", student.absence, DbType.Int32);
            parameters.Add("tuitionfee", student.tuitionfee, DbType.String);
            parameters.Add("department", student.department, DbType.String);
            parameters.Add("semester", student.semester, DbType.Int32);
            parameters.Add("parent_name", student.parent_name, DbType.String);
            parameters.Add("parent_contact", student.parent_contact, DbType.String);
            parameters.Add("username", student.username, DbType.String);
            parameters.Add("password", student.password, DbType.String);
            
            
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(procedureName,parameters,commandType : CommandType.StoredProcedure);
                return student;

            }
        }

        
    }
}
