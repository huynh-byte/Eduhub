using System;

namespace EduHub.Ch01.Domain{

    /// <summary>
    /// Phiếu đăng ký tham dự sự kiện của một sinh viên.
    /// </summary>

    public class Registration{

        public const string StatusPending = "Pending";
        public const string StatusConfirmed = "Confirmed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRejected = "Rejected";

        public Guid Id { get; private set; }
        public Guid EventId { get; private set; }
        public Guid StudentId { get; private set; }
        public string Status { get; private set; }
        public string RejectReason { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Registration(Guid id, Guid eventId, Guid studentId){

            Id = id;
            EventId = eventId;
            StudentId = studentId;
            Status = StatusPending;
            RejectReason = "";
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Tạo phiếu mới ở trạng thái Pending.
        /// </summary>

        public static Registration Create(Guid eventId, Guid studentId){

            if (eventId == Guid.Empty)
                throw new ArgumentException("Phiếu phải thuộc một sự kiện.");
            if (studentId == Guid.Empty)
                throw new ArgumentException("Phiếu phải thuộc một sinh viên.");

            return new Registration(Guid.NewGuid(), eventId, studentId);
        }


        /// <summary>
        /// Xác nhận phiếu, chỉ được khi đang Pending.
        /// </summary>
        public void Confirm(){
            if (Status != StatusPending)
                throw new InvalidOperationException("Chỉ xác nhận được phiếu đang Pending.");

            Status = StatusConfirmed;
        }

        /// <summary>
        /// Từ chối phiếu kèm lý do, chỉ được khi đang Pending.
        /// </summary>

        public void Reject(string reason){
            if (Status != StatusPending)
                throw new InvalidOperationException("Chỉ từ chối được phiếu đang Pending.");
            if (string.IsNullOrWhiteSpace(reason))
                throw new ArgumentException("Phải ghi lý do từ chối.");

            Status = StatusRejected;
            RejectReason = reason.Trim();
        }

        /// <summary>
        /// Huỷ phiếu đang Pending hoặc Confirmed.
        /// </summary>

        public void Cancel(){
            if (Status != StatusPending && Status != StatusConfirmed)
                throw new InvalidOperationException("Phiếu này không thể huỷ.");

            Status = StatusCancelled;
        }
    }
}