import React, { useState } from "react";

// Import ảnh vào component
import footballImg from "../assets/images/football.jpg";
import tennisImg from "../assets/images/tennis.jpg";
import basketballImg from "../assets/images/basketball.jpg";
import golfImg from "../assets/images/golf.jpg";
import eventImg from "../assets/images/event.jpg";
import comedyImg from "../assets/images/comedy.jpg";
import travelImg from "../assets/images/travel.jpg";
import showImg from "../assets/images/show.jpg";

function UpTicket() {
    const [selectedCategory, setSelectedCategory] = useState(""); // Lưu danh mục được chọn
    const [barcode, setBarcode] = useState("");
    const [price, setPrice] = useState("");
    const [quantity, setQuantity] = useState(1);
    const [seatNumber, setSeatNumber] = useState("");
    const [pdfFile, setPdfFile] = useState(null);
    const [message, setMessage] = useState("");
    const [uploadedTickets, setUploadedTickets] = useState([]); // Lưu trữ danh sách vé đã upload

    // Tạo danh sách các danh mục với hình ảnh tương ứng
    const categories = [
        { name: "football", image: footballImg },
        { name: "tennis", image: tennisImg },
        { name: "basketball", image: basketballImg },
        { name: "golf", image: golfImg },
        { name: "event", image: eventImg },
        { name: "comedy", image: comedyImg },
        { name: "travel", image: travelImg },
        { name: "show", image: showImg },
    ];

    const handleCategoryClick = (category) => {
        setSelectedCategory(category); // Cập nhật danh mục được chọn
        setMessage(""); // Xóa thông báo trước đó (nếu có)
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        // Kiểm tra các trường không được để trống
        if (
            !barcode ||
            !price ||
            !quantity ||
            !seatNumber ||
            !selectedCategory ||
            !pdfFile
        ) {
            setMessage("Please fill in all required fields.");
            return;
        }

        const ticketData = {
            barcode,
            price,
            quantity,
            seatNumber,
            category: selectedCategory, // Lưu danh mục đã chọn vào dữ liệu vé
            pdfFile: pdfFile.name, // Chỉ lưu tên file PDF để hiển thị, không upload thực sự
            status: "Pending", // Mặc định trạng thái là "Pending"
        };

        // Lưu thông tin vé vào localStorage hoặc state
        let tickets = JSON.parse(localStorage.getItem("tickets")) || [];
        tickets.push(ticketData);
        localStorage.setItem("tickets", JSON.stringify(tickets));

        // Lưu vé vừa upload vào state để hiển thị bảng
        setUploadedTickets([...uploadedTickets, ticketData]);

        // Reset form sau khi upload thành công
        setBarcode("");
        setPrice("");
        setQuantity(1);
        setSeatNumber("");
        setPdfFile(null);
        setSelectedCategory("");
        setMessage("Ticket submitted successfully!");
    };

    const handleFileChange = (e) => {
        setPdfFile(e.target.files[0]);
    };

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-3xl font-bold mb-6">Upload Your Ticket</h1>

            {/* Thông báo thành công hoặc lỗi */}
            {message && <p className="text-green-500">{message}</p>}

            {/* Ticket Categories */}
            <div className="grid grid-cols-4 gap-4 mb-6">
                {categories.map((category, index) => (
                    <div
                        key={index}
                        className={`p-4 border rounded text-center cursor-pointer ${
                            selectedCategory === category.name
                                ? "bg-blue-500 text-white"
                                : "bg-gray-100"
                        }`}
                        onClick={() => handleCategoryClick(category.name)}
                    >
                        {/* Hiển thị ảnh và tên danh mục */}
                        <img
                            src={category.image}
                            alt={category.name}
                            className="w-full h-24 object-cover mb-2"
                        />
                        <p className="font-semibold">
                            {category.name.charAt(0).toUpperCase() +
                                category.name.slice(1)}
                        </p>
                    </div>
                ))}
            </div>

            {/* Form chỉ hiện sau khi người dùng đã chọn danh mục */}
            {selectedCategory && (
                <form onSubmit={handleSubmit} className="space-y-4">
                    <h2 className="text-xl font-bold mb-4">
                        Selected Category:{" "}
                        {selectedCategory.charAt(0).toUpperCase() +
                            selectedCategory.slice(1)}
                    </h2>

                    <div>
                        <label
                            htmlFor="barcode"
                            className="block font-semibold"
                        >
                            Barcode
                        </label>
                        <input
                            type="text"
                            id="barcode"
                            value={barcode}
                            onChange={(e) => setBarcode(e.target.value)}
                            className="border p-2 w-full"
                            required
                        />
                    </div>

                    <div>
                        <label htmlFor="price" className="block font-semibold">
                            Price ($)
                        </label>
                        <input
                            type="number"
                            id="price"
                            value={price}
                            onChange={(e) => setPrice(e.target.value)}
                            className="border p-2 w-full"
                            required
                        />
                    </div>

                    <div>
                        <label
                            htmlFor="quantity"
                            className="block font-semibold"
                        >
                            Quantity
                        </label>
                        <input
                            type="number"
                            id="quantity"
                            value={quantity}
                            onChange={(e) => setQuantity(e.target.value)}
                            className="border p-2 w-full"
                            min="1"
                            required
                        />
                    </div>

                    <div>
                        <label
                            htmlFor="seatNumber"
                            className="block font-semibold"
                        >
                            Seat Number
                        </label>
                        <input
                            type="text"
                            id="seatNumber"
                            value={seatNumber}
                            onChange={(e) => setSeatNumber(e.target.value)}
                            className="border p-2 w-full"
                            required
                        />
                    </div>

                    <div>
                        <label
                            htmlFor="pdfFile"
                            className="block font-semibold"
                        >
                            Upload PDF
                        </label>
                        <input
                            type="file"
                            id="pdfFile"
                            onChange={handleFileChange}
                            accept=".pdf"
                            className="border p-2 w-full"
                            required
                        />
                    </div>

                    <button
                        type="submit"
                        className="bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700"
                    >
                        Submit Ticket
                    </button>
                </form>
            )}

            {/* Hiển thị vé đã upload dưới dạng bảng */}
            {uploadedTickets.length > 0 && (
                <div className="mt-8">
                    <h2 className="text-2xl font-bold mb-4">
                        Uploaded Tickets
                    </h2>
                    <table className="table-auto w-full border-collapse border border-gray-200">
                        <thead>
                            <tr className="bg-gray-100">
                                <th className="border p-2">Barcode</th>
                                <th className="border p-2">Price ($)</th>
                                <th className="border p-2">Quantity</th>
                                <th className="border p-2">Seat Number</th>
                                <th className="border p-2">Category</th>
                                <th className="border p-2">PDF File</th>
                                <th className="border p-2">Status</th>{" "}
                                {/* Cột trạng thái */}
                            </tr>
                        </thead>
                        <tbody>
                            {uploadedTickets.map((ticket, index) => (
                                <tr key={index}>
                                    <td className="border p-2">
                                        {ticket.barcode}
                                    </td>
                                    <td className="border p-2">
                                        {ticket.price}
                                    </td>
                                    <td className="border p-2">
                                        {ticket.quantity}
                                    </td>
                                    <td className="border p-2">
                                        {ticket.seatNumber}
                                    </td>
                                    <td className="border p-2">
                                        {ticket.category}
                                    </td>
                                    <td className="border p-2">
                                        {ticket.pdfFile}
                                    </td>
                                    <td className="border p-2">
                                        {ticket.status}
                                    </td>{" "}
                                    {/* Hiển thị trạng thái */}
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
        </div>
    );
}

export default UpTicket;
