import React, { useState, useContext } from "react";  
import ticketApi from "../../api/ticketApi";
import { useNavigate } from "react-router-dom";
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
        categoryName: "", // Người dùng nhập vào category
        PdfFile: null,
        Description: "",
    });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const navigate = useNavigate();
         
    const handleChange = (e) => {
        const { name, value, files } = e.target;
        if (name === "PdfFile") {
            const file = files[0];
            // Validate file type (allow PDF, JPG, and JPEG)
            const validFileTypes = ["application/pdf", "image/jpeg", "image/jpg"];
            if (file && validFileTypes.includes(file.type)) {
                setFormData((prev) => ({
                    ...prev,
                    [name]: file,
                }));
            } else {
                setError("Invalid file type. Please upload a PDF, JPG, or JPEG file.");
            }
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
        if (formData.PdfFile) {
            data.append("File", formData.PdfFile);
        }
        // Đặt mặc định Status là 'Pending' nếu status sẽ được cập nhật sau khi kiểm duyệt
         console.log(formData);
        try {
            const response =  await ticketApi.createTicket(formData, data);
            if (response.data ==="Add Successful") {

                // Điều hướng hoặc thông báo thành công
                navigate("/tickets"); // Điều hướng đến trang danh sách ticket
            }
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
                />
            </div>
        </div>
    );
};

export default UploadTicketPage;
