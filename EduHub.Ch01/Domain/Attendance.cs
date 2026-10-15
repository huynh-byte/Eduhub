using System;

namespace EduHub.Ch01.Domain{

    /// <summary>
    /// Bản ghi điểm danh của một phiếu đã Confirmed.
    /// </summary>
    public class Attendance{
        public Guid Id { get; private set; }
        public Guid RegistrationId { get; private set; }
        public DateTime CheckedInAt { get; private set; }

        private Attendance(Guid id, Guid registrationId){
            Id = id;
            RegistrationId = registrationId;
            CheckedInAt = DateTime.Now;
        }

        /// <summary>
        /// Check-in cho phiếu, phiếu phải đang Confirmed.
        /// </summary>

        public static Attendance Create(Registration registration){
            if (registration == null)
                throw new ArgumentNullException(nameof(registration));
            if (registration.Status != Registration.StatusConfirmed)
                throw new InvalidOperationException("Chỉ check-in được phiếu đã Confirmed.");

            return new Attendance(Guid.NewGuid(), registration.Id);
        }

        /// <summary>
        /// Chỉnh lại giờ check-in, không được ở tương lai.
        /// </summary>

        public void AdjustCheckInTime(DateTime newTime){

            if (newTime > DateTime.Now)
                throw new ArgumentException("Giờ check-in không được ở tương lai.");

            CheckedInAt = newTime;
        }
    }
}