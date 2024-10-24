import React from "react";
import { Link } from "react-router-dom";

const TicketCard = ({ ticket }) => {
    return (
        <div className="border rounded shadow p-4 flex flex-col max-w-sm mx-auto">
            <div className="mb-4">
                <h3 className="text-2xl font-semibold text-center">{ticket.categoryName || 'Ticket Event'}</h3>
            </div>
            <div className="flex justify-between items-center">
                <p className="text-gray-700">Price:</p>
                <p className="font-bold text-gray-900">${ticket.price.toFixed(2)}</p>
            </div>
            <div className="flex justify-between items-center mt-2">
                <p className="text-gray-700">Quantity:</p>
                <p className="font-bold text-gray-900">{ticket.quantity}</p>
            </div>
            <div className="flex justify-between items-center mt-2">
                <p className="text-gray-700">Seat Number:</p>
                <p className="font-bold text-gray-900">{ticket.seatNumber || 'N/A'}</p>
            </div>
            <div className="flex justify-between items-center mt-2">
                <p className="text-gray-700">Status:</p>
                <p className="font-bold text-green-600">{ticket.status || 'Available'}</p>
            </div>
            <div className="mt-6">
                <Link to={`/checkout/${ticket.ticketId}`}>
                    <button className="w-full bg-blue-500 text-white py-3 px-4 rounded hover:bg-blue-600">
                        Proceed to Checkout
                    </button>
                </Link>
            </div>
        </div>
    );
};

export default TicketCard;
