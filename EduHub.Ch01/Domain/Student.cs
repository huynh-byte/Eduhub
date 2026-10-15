using System;

namespace EduHub.Ch01.Domain{

    /// <summary>
    /// Sinh viên đăng ký tham dự sự kiện.
    /// </summary>

    public class Student{

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }

        private Student(Guid id, string fullName, string email){
            Id = id;
            FullName = fullName;
            Email = email;
        }

        /// <summary>
        /// Tạo sinh viên mới, kiểm tra họ tên và email.
        /// </summary>

        public static Student Create(string fullName, string email){
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Họ tên không được để trống.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Email không hợp lệ.");

            return new Student(Guid.NewGuid(), fullName.Trim(), email.Trim());
        }

        /// <summary>
        /// Đổi họ tên.
        /// </summary>
        public void UpdateName(string fullName){

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Họ tên không được để trống.");

            FullName = fullName.Trim();
        }
    }
}