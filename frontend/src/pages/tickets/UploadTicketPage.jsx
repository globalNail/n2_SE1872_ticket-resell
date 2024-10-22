import React, { useState, useContext } from "react"; 
import ticketApi from "../../api/ticketApi";
import { useNavigate } from "react-router-dom";
import useFetchCategories from "../../hooks/useFetchCategories";
import TicketForm from "../../components/tickets/TicketForm";
import { AuthContext } from "../../contexts/AuthContext"; // Import context để lấy thông tin đăng nhập
import UploadTicket from "../../assets/images/uploadticket.jpg";

const UploadTicketPage = () => {
    const { user } = useContext(AuthContext); // Lấy thông tin người dùng đã đăng nhập từ context
    const [formData, setFormData] = useState({
        Barcode: "",
        Price: "",
        Quantity: "",
        SeatNumber: "",
        StartDate: "",
        CategoryId: "",
        PdfFile: null,
        Description: "",
    });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    // Sử dụng custom hook để fetch categories
    const { categories, loadingCategories, errorCategories } = useFetchCategories();

    const handleChange = (e) => {
        const { name, value, files } = e.target;
        if (name === "PdfFile") {
            setFormData((prev) => ({
                ...prev,
                [name]: files[0],
            }));
        } else {
            setFormData((prev) => ({
                ...prev,
                [name]: value,
            }));
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null);

        // Tạo FormData để gửi dữ liệu cùng file
        const data = new FormData();
        data.append("Barcode", formData.Barcode);
        data.append("Price", formData.Price);
        data.append("Quantity", formData.Quantity || "");
        data.append("SeatNumber", formData.SeatNumber || "");
        data.append("StartDate", formData.StartDate || "");
        data.append("SellerId", user.id); // Lấy SellerID từ thông tin đăng nhập
        data.append("CategoryId", formData.CategoryId); // Đảm bảo CategoryId được chọn
        if (formData.PdfFile) {
            data.append("PdfFile", formData.PdfFile);
        }
        // Đặt mặc định Status là 'Pending' nếu status sẽ được cập nhật sau khi kiểm duyệt
        data.append("Status", "Pending");
        data.append("Description", formData.Description || "");

        try {
            await ticketApi.createTicket(data);
            // Điều hướng hoặc thông báo thành công
            navigate("/tickets"); // Điều hướng đến trang danh sách ticket
        } catch (err) {
            setError(err.response?.data?.message || "Error uploading ticket");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="relative">
            {/* Hình ảnh nền */}
            <img 
                src={UploadTicket} 
                alt="Upload Ticket" 
                className="absolute inset-0 w-full h-full object-cover" 
                style={{ zIndex: -1 }} // Đặt z-index thấp hơn để làm nền
            />
            <div className="container mx-auto px-4 py-8 relative z-10"> {/* z-10 để nội dung nằm trên hình ảnh */}
                <h1 className="text-3xl font-bold text-white text-center mt-10">Upload New Ticket</h1>
                <TicketForm
                    formData={formData}
                    handleChange={handleChange}
                    handleSubmit={handleSubmit}
                    loading={loading}
                    error={error}
                    categories={categories}
                    loadingCategories={loadingCategories}
                    errorCategories={errorCategories}
                />
            </div>
        </div>
    );
};

export default UploadTicketPage;
