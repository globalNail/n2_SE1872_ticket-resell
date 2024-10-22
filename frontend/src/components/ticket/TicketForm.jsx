// src/components/tickets/TicketForm.jsx
import React from "react";

const TicketForm = ({
    formData,
    handleChange,
    handleSubmit,
    loading,
    error,
    categories,
    loadingCategories,
    errorCategories,
}) => {
    return (
        <div>
            {error && <div className="mb-4 text-red-500">{error}</div>}
            {errorCategories && (
                <div className="mb-4 text-red-500">{errorCategories}</div>
            )}
            <form onSubmit={handleSubmit} className="max-w-lg mx-auto">
                {/* Barcode */}
                <div className="mb-4">
                    <label className="block text-gray-700">
                        Barcode<span className="text-red-500">*</span>
                    </label>
                    <input
                        type="text"
                        name="Barcode"
                        value={formData.Barcode}
                        onChange={handleChange}
                        required
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Price */}
                <div className="mb-4">
                    <label className="block text-gray-700">
                        Price<span className="text-red-500">*</span>
                    </label>
                    <input
                        type="number"
                        name="Price"
                        value={formData.Price}
                        onChange={handleChange}
                        required
                        step="0.01"
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Quantity */}
                <div className="mb-4">
                    <label className="block text-gray-700">Quantity</label>
                    <input
                        type="number"
                        name="Quantity"
                        value={formData.Quantity}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Seat Number */}
                <div className="mb-4">
                    <label className="block text-gray-700">Seat Number</label>
                    <input
                        type="text"
                        name="SeatNumber"
                        value={formData.SeatNumber}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Start Date */}
                <div className="mb-4">
                    <label className="block text-gray-700">Start Date</label>
                    <input
                        type="datetime-local"
                        name="StartDate"
                        value={formData.StartDate}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Seller ID */}
                <div className="mb-4">
                    <label className="block text-gray-700">Seller ID</label>
                    <input
                        type="number"
                        name="SellerId"
                        value={formData.SellerId}
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Category ID (Dropdown) */}
                <div className="mb-4">
                    <label className="block text-gray-700">
                        Category<span className="text-red-500">*</span>
                    </label>
                    {loadingCategories ? (
                        <div className="text-gray-500">
                            Loading categories...
                        </div>
                    ) : (
                        <select
                            name="CategoryId"
                            value={formData.CategoryId}
                            onChange={handleChange}
                            required
                            className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                        >
                            <option value="">Select Category</option>
                            {categories.map((category) => (
                                <option
                                    key={category.CategoryId}
                                    value={category.CategoryId}
                                >
                                    {category.Name}
                                </option>
                            ))}
                        </select>
                    )}
                </div>

                {/* Pdf File */}
                <div className="mb-4">
                    <label className="block text-gray-700">PDF File</label>
                    <input
                        type="file"
                        name="PdfFile"
                        accept=".pdf"
                        onChange={handleChange}
                        className="w-full px-3 py-2 border rounded-md focus:outline-none focus:ring focus:border-blue-300"
                    />
                </div>

                {/* Description */}
                <div className="mb-4">
                    <label className="block text-gray-700">Description</label>
                    <textarea
                        name="Description"
                        value={formData.Description}
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
