import React, { useState } from 'react';

function StaffApproval() {
    const [tickets, setTickets] = useState([
        {
            barcode: '123456789',
            price: 50,
            quantity: 2,
            seatNumber: 'A12',
            categoryID: 'VIP',
            status: 'Pending',
        },
        {
            barcode: '987654321',
            price: 75,
            quantity: 1,
            seatNumber: 'B5',
            categoryID: 'General',
            status: 'Pending',
        },
        {
            barcode: '555666777',
            price: 100,
            quantity: 3,
            seatNumber: 'C8',
            categoryID: 'Premium',
            status: 'Pending',
        },
    ]);

    const handleApprove = (index) => {
        let updatedTickets = [...tickets];
        updatedTickets[index].status = 'Approved';
        setTickets(updatedTickets);
    };

    const handleReject = (index) => {
        let updatedTickets = [...tickets];
        updatedTickets[index].status = 'Rejected';
        setTickets(updatedTickets);
    };

    return (
        <div className="container mx-auto p-6">
            <h1 className="text-3xl font-bold mb-6">Ticket Approval Form</h1>
            {tickets.length === 0 ? (
                <p>No tickets pending for approval.</p>
            ) : (
                tickets.map((ticket, index) => (
                    <form key={index} className="bg-white p-6 mb-4 shadow rounded-lg border">
                        <h2 className="text-xl font-semibold mb-2">Ticket #{index + 1}</h2>
                        
                        <div className="mb-4">
                            <label className="block text-gray-700">Barcode:</label>
                            <input
                                type="text"
                                value={ticket.barcode}
                                readOnly
                                className="w-full p-2 border rounded"
                            />
                        </div>

                        <div className="mb-4">
                            <label className="block text-gray-700">Price:</label>
                            <input
                                type="text"
                                value={`$${ticket.price}`}
                                readOnly
                                className="w-full p-2 border rounded"
                            />
                        </div>

                        <div className="mb-4">
                            <label className="block text-gray-700">Quantity:</label>
                            <input
                                type="text"
                                value={ticket.quantity}
                                readOnly
                                className="w-full p-2 border rounded"
                            />
                        </div>

                        <div className="mb-4">
                            <label className="block text-gray-700">Seat Number:</label>
                            <input
                                type="text"
                                value={ticket.seatNumber}
                                readOnly
                                className="w-full p-2 border rounded"
                            />
                        </div>

                        <div className="mb-4">
                            <label className="block text-gray-700">Category:</label>
                            <input
                                type="text"
                                value={ticket.categoryID}
                                readOnly
                                className="w-full p-2 border rounded"
                            />
                        </div>

                        <div className="mb-4">
                            <label className="block text-gray-700">Status:</label>
                            <input
                                type="text"
                                value={ticket.status}
                                readOnly
                                className="w-full p-2 border rounded"
                            />
                        </div>

                        <div className="mt-4 flex space-x-4">
                            <button
                                type="button"
                                className="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
                                onClick={() => handleApprove(index)}
                            >
                                Approve
                            </button>
                            <button
                                type="button"
                                className="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
                                onClick={() => handleReject(index)}
                            >
                                Reject
                            </button>
                        </div>
                    </form>
                ))
            )}
        </div>
    );
}

export default StaffApproval;
