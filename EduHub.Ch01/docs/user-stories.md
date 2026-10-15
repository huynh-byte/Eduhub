# User Stories - EduHub

## Sinh viên

**US-01.** Là sinh viên, tôi muốn đăng ký tham dự một sự kiện, để giữ chỗ trước khi sự kiện diễn ra.

- Given sự kiện còn chỗ và chưa quá hạn đăng ký, When tôi đăng ký, Then hệ thống tạo phiếu ở trạng thái Pending
- Given tôi đã có phiếu Pending hoặc Confirmed cho sự kiện này, When tôi đăng ký lần nữa, Then hệ thống từ chối

**US-02.** Là sinh viên, tôi muốn đăng ký vào danh sách chờ khi sự kiện đã hết chỗ, để được nhận chỗ nếu có người huỷ.

- Given sự kiện đã đủ số lượng Confirmed, When tôi đăng ký chờ, Then tôi được thêm vào cuối danh sách chờ
- Given sự kiện vẫn còn chỗ trống, When tôi đăng ký chờ, Then hệ thống từ chối và hướng dẫn đăng ký thường

**US-03.** Là sinh viên, tôi muốn đánh giá sự kiện sau khi tham dự, để ban tổ chức cải thiện những lần sau.

- Given tôi đã được điểm danh tại sự kiện, When tôi gửi đánh giá từ 1 đến 5 sao, Then đánh giá được lưu
- Given tôi chưa được điểm danh tại sự kiện, When tôi gửi đánh giá, Then hệ thống từ chối

## Ban CLB

**US-04.** Là ban CLB, tôi muốn từ chối một phiếu đăng ký không phù hợp, để dành chỗ cho người đủ điều kiện.

- Given phiếu đang Pending, When tôi từ chối và nhập lý do, Then phiếu chuyển sang Rejected và sinh viên nhận được lý do
- Given phiếu đã Confirmed hoặc đã Cancelled, When tôi từ chối, Then hệ thống từ chối thao tác

**US-05.** Là ban CLB, tôi muốn đóng đăng ký sớm khi đủ người, để không nhận thêm phiếu ngoài kế hoạch.

- Given sự kiện đang mở đăng ký, When tôi đóng đăng ký, Then sinh viên không thể tạo phiếu mới
- Given sự kiện đã diễn ra xong, When tôi đóng đăng ký, Then hệ thống từ chối

## Admin

**US-06.** Là admin, tôi muốn tạm khoá một CLB vi phạm quy định, để CLB đó không thể tổ chức sự kiện mới.

- Given CLB đang Active, When tôi khoá và ghi lý do, Then CLB chuyển sang Suspended và không tạo được sự kiện mới
- Given CLB đang Suspended, When ban CLB cố tạo sự kiện, Then hệ thống từ chối