// src/pages/Tickets/UploadTicketPage.jsx
import React, { useState } from "react";
import ticketApi from "../../api/ticketApi";
import { useNavigate } from "react-router-dom";
import useFetchCategories from "../../hooks/useFetchCategories";
import TicketForm from "../../components/tickets/TicketForm";

const UploadTicketPage = () => {
    const [formData, setFormData] = useState({
        Barcode: "",
        Price: "",
        Quantity: "",
        SeatNumber: "",
        StartDate: "",
        SellerId: "",
        CategoryId: "",
        PdfFile: null,
        Description: "",
    });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const navigate = useNavigate();

    // Sử dụng custom hook để fetch categories
    const { categories, loadingCategories, errorCategories } =
        useFetchCategories();

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
        data.append("SellerId", formData.SellerId || "");
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
        <div className="container mx-auto px-4 py-8">
            <h1 className="text-3xl font-bold mb-6">Upload New Ticket</h1>
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
    );
};

export default UploadTicketPage;
