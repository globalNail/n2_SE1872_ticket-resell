import React from "react";

const TicketForm = ({
    formData,
    handleChange,
    handleSubmit,
    loading,
    error,
}) => {
    return (
        <div>
            {error && <div className="mb-4 text-red-500">{error}</div>}
            <form onSubmit={handleSubmit} className="max-w-lg mx-auto">
                {/* Barcode */}
                <div className="mb-4">
                    <label className="block text-white">
                        Barcode<span className="text-red-500">*</span>
                    </label>
                    <input
                        type="text"
                        name="Barcode"
                        value={formData.barcode}
                        onChange={handleChange}
                        required
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Price */}
                <div className="mb-4">
                    <label className="block text-white">
                        Price<span className="text-red-500">*</span>
                    </label>
                    <input
                        type="number"
                        name="Price"
                        value={formData.price}
                        onChange={handleChange}
                        required
                        step="0.01"
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Quantity */}
                <div className="mb-4">
                    <label className="block text-white">Quantity</label>
                    <input
                        type="number"
                        name="Quantity"
                        value={formData.quantity}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Seat Number */}
                <div className="mb-4">
                    <label className="block text-white">Seat Number</label>
                    <input
                        type="text"
                        name="SeatNumber"
                        value={formData.seatNumber}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Start Date */}
                <div className="mb-4">
                    <label className="block text-white">Start Date</label>
                    <input
                        type="datetime-local"
                        name="StartDate"
                        value={formData.startDate}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Category Name (Text Input) */}
                <div className="mb-4">
                    <label className="block text-white">
                        Category Name<span className="text-red-500">*</span>
                    </label>
                    <input
                        type="text"
                        name="categoryName"
                        value={formData.categoryName}
                        onChange={handleChange}
                        required
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Pdf File */}
                <div className="mb-4">
                    <label className="block text-white">PDF File</label>
                    <input
                        type="file"
                        name="PdfFile"
                        accept=".jpg,.jpeg"
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Description */}
                <div className="mb-4">
                    <label className="block text-white">Description</label>
                    <textarea
                        name="Description"
                        value={formData.description}
                        onChange={handleChange}
                        rows="4"
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    ></textarea>
                </div>

                {/* Submit Button */}
                <div className="mb-4">
                    <button
                        type="submit"
                        disabled={loading}
                        className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 transition-colors"
                    >
                        {loading ? "Uploading..." : "Upload Ticket"}
                    </button>
                </div>
            </form>
        </div>
    );
};

export default TicketForm;
