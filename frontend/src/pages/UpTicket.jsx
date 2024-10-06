import React, { useState } from 'react';

function UpTicket() {
    const [barcode, setBarcode] = useState('');
    const [price, setPrice] = useState('');
    const [quantity, setQuantity] = useState(1);
    const [seatNumber, setSeatNumber] = useState('');
    const [categoryID, setCategoryID] = useState('');
    const [pdfFile, setPdfFile] = useState(null);

    const handleSubmit = (e) => {
        e.preventDefault();
        // Handle form submission logic (e.g., API call to save the ticket details)
        const ticketData = {
            barcode,
            price,
            quantity,
            seatNumber,
            categoryID,
            pdfFile
        };

        console.log(ticketData); // In production, replace with API call
    };

    const handleFileChange = (e) => {
        setPdfFile(e.target.files[0]);
    };

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-3xl font-bold mb-6">Upload Your Ticket</h1>
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label htmlFor="barcode" className="block font-semibold">Barcode</label>
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
                    <label htmlFor="price" className="block font-semibold">Price ($)</label>
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
                    <label htmlFor="quantity" className="block font-semibold">Quantity</label>
                    <input
                        type="number"
                        id="quantity"
                        value={quantity}
                        onChange={(e) => setQuantity(e.target.value)}
                        className="border p-2 w-full"
                        min="1"
                    />
                </div>

                <div>
                    <label htmlFor="seatNumber" className="block font-semibold">Seat Number</label>
                    <input
                        type="text"
                        id="seatNumber"
                        value={seatNumber}
                        onChange={(e) => setSeatNumber(e.target.value)}
                        className="border p-2 w-full"
                    />
                </div>

                <div>
                    <label htmlFor="categoryID" className="block font-semibold">Category</label>
                    <select
                        id="categoryID"
                        value={categoryID}
                        onChange={(e) => setCategoryID(e.target.value)}
                        className="border p-2 w-full"
                        required
                    >
                        <option value="">Select Category</option>
                        <option value="1">Concert</option>
                        <option value="2">Sports</option>
                        <option value="3">Theater</option>
                        {/* Add more categories as needed */}
                    </select>
                </div>

                <div>
                    <label htmlFor="pdfFile" className="block font-semibold">Upload PDF</label>
                    <input
                        type="file"
                        id="pdfFile"
                        onChange={handleFileChange}
                        accept=".pdf"
                        className="border p-2 w-full"
                    />
                </div>

                <button type="submit" className="bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700">
                    Submit Ticket
                </button>
            </form>
        </div>
    );
}

export default UpTicket;
