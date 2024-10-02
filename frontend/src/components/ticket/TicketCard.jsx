import React from 'react';
import { Link } from 'react-router-dom';

const TicketCard = ({ ticket }) => {
    return (
        <div className="border rounded shadow p-4 flex flex-col">
            <h3 className="text-xl font-semibold mb-2">{ticket.barcode}</h3>
            <p className="text-gray-700">Price: ${ticket.price.toFixed(2)}</p>
            <p className="text-gray-700">Quantity: {ticket.quantity}</p>
            <p className="text-gray-700">Status: {ticket.status}</p>
            <Link to={`/tickets/${ticket.ticketId}`}>
                <button className="mt-auto bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600">
                    View Details
                </button>
            </Link>
        </div>
    );
};

export default TicketCard;
