import React from "react";
import { Link } from "react-router-dom";

const TicketTable = ({ tickets }) => {
    return (
        <div className="overflow-x-auto">
            <table className="min-w-full bg-white shadow-md rounded-lg overflow-hidden">
                <tbody>
                    {tickets.map((ticket) => {
                        const startDate = new Date(ticket.StartDate);
                        const day = startDate.toLocaleDateString('en-US', { weekday: 'short' }).toUpperCase();
                        const date = startDate.toLocaleDateString('en-US', { month: 'short', day: 'numeric' });
                        const time = startDate.toLocaleTimeString('en-US', { hour: 'numeric', minute: 'numeric', hour12: true });
                        
                        return (
                            <tr key={ticket.ticketId} className="border-b hover:bg-gray-100">
                                {/* Phần hiển thị ngày giờ bên trái */}
                                <td className="py-4 px-6 text-center">
                                    <div className="font-bold text-black-600">{day}</div>
                              
                                    {/* Hiển thị SellerID */}
                                    <div className="text-gray-400 text-sm mt-2">Seller: {ticket.SellerID || "N/A"}</div>
                                </td>
                                {/* Phần hiển thị thông tin sự kiện và nút Tickets */}
                                <td className="py-4 px-6 flex justify-between items-center">
                                    <div>
                                        <div className="font-bold text-lg">{ticket.eventName || "Event Name"}</div>
                                        <div className="text-gray-500">{ticket.venue || "Venue"} - {ticket.location || "Location"}</div>
                                    </div>
                                    <div className="text-right">
                                        <Link to={`/tickets/${ticket.TicketId}`} className="bg-yellow-400 text-black font-bold py-2 px-4 rounded hover:bg-yellow-500">
                                            Tickets
                                        </Link>
                                        {/* Hiển thị giá vé */}
                                        <div className="font-bold text-gray-700 mt-2">
                                            ${typeof ticket.Price === "number" ? ticket.Price.toFixed(2) : "N/A"}
                                        </div>
                                        <div className="text-red-500 text-xs mt-2">Limited seats available!</div>
                                    </div>
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
};

export default TicketTable;
