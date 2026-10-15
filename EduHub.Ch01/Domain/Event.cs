using System;
namespace EduHub.Ch01.Domain{
    /// <summary>
    /// Sự kiện do câu lạc bộ tổ chức.
    /// </summary>
    public class Event{
        public Guid Id { get; private set; }
        public Guid ClubId { get; private set; }
        public string Title { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int Capacity { get; private set; }
        public bool IsRegistrationOpen { get; private set; }

        private Event(Guid id, Guid clubId, string title, DateTime startTime, DateTime endTime, int capacity){
            Id = id;
            ClubId = clubId;
            Title = title;
            StartTime = startTime;
            EndTime = endTime;
            Capacity = capacity;
            IsRegistrationOpen = true;
        }

        /// <summary>
        /// Tạo sự kiện mới, kiểm tra tên, sức chứa và thời gian.
        /// </summary>

        public static Event Create(Guid clubId, string title, DateTime startTime, DateTime endTime, int capacity){
            if (clubId == Guid.Empty)
                throw new ArgumentException("Sự kiện phải thuộc một câu lạc bộ.");
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Tên sự kiện không được để trống.");
            if (capacity <= 0)
                throw new ArgumentException("Sức chứa phải lớn hơn 0.");
            if (endTime <= startTime)
                throw new ArgumentException("Thời gian kết thúc phải sau thời gian bắt đầu.");

            return new Event(Guid.NewGuid(), clubId, title.Trim(), startTime, endTime, capacity);
        }

        /// <summary>
        /// Kiểm tra sự kiện đã đủ người chưa.
        /// </summary>

        public bool IsFull(int confirmedCount){
             return confirmedCount >= Capacity;
        }

        /// <summary>
        /// Đăng ký cho sinh viên, không được khi đã đóng đăng ký.
        /// </summary>
        public Registration Register(Guid studentId){
            if (!IsRegistrationOpen)
                throw new InvalidOperationException("Sự kiện đã đóng đăng ký.");

            return Registration.Create(Id, studentId);
        }

        /// <summary>
        /// Đóng đăng ký sớm, không được khi sự kiện đã diễn ra xong.
        /// </summary>

        public void CloseRegistration(){
            if (EndTime < DateTime.Now)
                throw new InvalidOperationException("Sự kiện đã diễn ra xong.");

            IsRegistrationOpen = false;
        }
    }
}